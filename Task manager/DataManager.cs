using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using Task_manager.Models;

namespace Task_manager
{
    public static class DataManager
    {
        private static string projectsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects.json");
        private static string tasksFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.json");
        private static string subTasksFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "subtasks.json");
        private static string userTasksFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usertasks.json");

        private static JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

        // Načítá seznam všech projektů ze souboru projects.json.
        // Pokud soubor neexistuje, vrátí prázdný seznam.
        public static List<Project> GetAllProjects()
        {
            if (!File.Exists(projectsFile)) return new List<Project>();
            string json = File.ReadAllText(projectsFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<Project>>(json) ?? new List<Project>();
        }

        // Uloží nový projekt se zadaným názvem.
        // Automaticky přiřadí nové ID na základě nejvyššího stávajícího ID.
        public static void SaveProject(string name)
        {
            var projects = GetAllProjects();
            int nextId = projects.Count > 0 ? projects.Max(p => p.Id) + 1 : 1;
            projects.Add(new Project { Id = nextId, Name = name });
            File.WriteAllText(projectsFile, System.Text.Json.JsonSerializer.Serialize(projects, _options));
        }

        // Načítá seznam všech úkolů ze souboru tasks.json.
        // Pokud soubor neexistuje, vrátí prázdný seznam.
        public static List<TaskItem> GetAllTasks()
        {
            if (!File.Exists(tasksFile)) return new List<TaskItem>();
            string json = File.ReadAllText(tasksFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

        // Vytváří nový úkol pro zadaný projekt.
        // Přiřadí unikátní ID a automaticky vytváří první podúkol "auto step".
        public static void SaveTask(int projectId, string title)
        {
            var allTasks = GetAllTasks();
            int nextTaskId = allTasks.Count > 0 ? allTasks.Max(t => t.Id) + 1 : 1;

            allTasks.Add(new TaskItem
            {
                Id = nextTaskId,
                ProjectId = projectId,
                Title = title,
                IsCompleted = false
            });
            File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));

            AddSubTask(nextTaskId, "auto step");
        }

        // Vrátí seznam všech úkolů, které patří k zadanému projektu.
        public static List<TaskItem> GetTasksByProjectId(int projectId)
        {
            return GetAllTasks().Where(t => t.ProjectId == projectId).ToList();
        }

        // Kontroluje, zda úkol se zadaným názvem již existuje v daném projektu.
        // Porovnání je citlivé na velikost písmen ignoruje.
        public static bool IsTaskTitleExists(int projectId, string title)
        {
            var allTasks = GetAllTasks();
            return allTasks.Any(t => t.ProjectId == projectId &&
                                     t.Title.Trim().Equals(title.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // Odstraní úkol se zadaným ID ze souboru tasks.json.
        public static void DeleteTask(int taskId)
        {
            var allTasks = GetAllTasks();
            allTasks.RemoveAll(t => t.Id == taskId);
            File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));
        }

        // Aktualizuje vlastnosti existujícího úkolu (název, popis, stav dokončení).
        public static void UpdateTask(TaskItem updatedTask)
        {
            var allTasks = GetAllTasks();
            var task = allTasks.FirstOrDefault(t => t.Id == updatedTask.Id);

            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.IsCompleted = updatedTask.IsCompleted;
                File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));
            }
        }

        // Načítá seznam všech podúkolů ze souboru subtasks.json.
        // Pokud soubor neexistuje, vrátí prázdný seznam.
        public static List<SubTask> GetAllSubTasks()
        {
            if (!File.Exists(subTasksFile)) return new List<SubTask>();
            string json = File.ReadAllText(subTasksFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<SubTask>>(json) ?? new List<SubTask>();
        }

        // Přidá nový podúkol k úkolu se zadaným ID.
        // Automaticky přiřadí nové ID na základě nejvyššího stávajícího ID.
        public static void AddSubTask(int taskId, string description)
        {
            var allSubTasks = GetAllSubTasks();
            int nextId = allSubTasks.Count > 0 ? allSubTasks.Max(s => s.Id) + 1 : 1;

            allSubTasks.Add(new SubTask
            {
                Id = nextId,
                ParentTaskId = taskId,
                Description = description,
                IsDone = false
            });
            File.WriteAllText(subTasksFile, System.Text.Json.JsonSerializer.Serialize(allSubTasks, _options));
        }

        // Aktualizuje stav dokončení podúkolu a kontroluje, zda je nadřazený úkol kompletně hotov.
        public static void UpdateSubTaskStatus(int subTaskId, bool isDone)
        {
            var allSubTasks = GetAllSubTasks();
            var sub = allSubTasks.FirstOrDefault(s => s.Id == subTaskId);
            if (sub == null) return;

            sub.IsDone = isDone;
            File.WriteAllText(subTasksFile, System.Text.Json.JsonSerializer.Serialize(allSubTasks, _options));

            CheckAndUpdateTaskCompletion(sub.ParentTaskId);
        }

        // Kontroluje, zda jsou všechny podúkoly hotovy, a pokud ano, označí nadřazený úkol jako dokončený.
        private static void CheckAndUpdateTaskCompletion(int taskId)
        {
            var allSubTasks = GetAllSubTasks().Where(s => s.ParentTaskId == taskId).ToList();
            var allTasks = GetAllTasks();
            var parentTask = allTasks.FirstOrDefault(t => t.Id == taskId);

            if (parentTask != null)
            {
                parentTask.IsCompleted = allSubTasks.All(s => s.IsDone);
                File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));
            }
        }

        // Načítá seznam všech přiřazení úkolů uživatelům ze souboru usertasks.json.
        // Pokud soubor neexistuje, vrátí prázdný seznam.
        public static List<UserTask> GetAllUserTasks()
        {
            if (!File.Exists(userTasksFile)) return new List<UserTask>();
            string json = File.ReadAllText(userTasksFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<UserTask>>(json) ?? new List<UserTask>();
        }

        // Přiřadí úkol uživateli.
        // Pokud je úkol již přiřazen danému uživateli, nic se neudělá.
        public static void AssignTaskToUser(int userId, int taskId)
        {
            var userTasks = GetAllUserTasks();

            if (userTasks.Any(ut => ut.UserId == userId && ut.TaskId == taskId))
            {
                return;
            }

            int nextId = userTasks.Count > 0 ? userTasks.Max(ut => ut.Id) + 1 : 1;

            userTasks.Add(new UserTask
            {
                Id = nextId,
                UserId = userId,
                TaskId = taskId
            });

            File.WriteAllText(userTasksFile, System.Text.Json.JsonSerializer.Serialize(userTasks, _options));
        }

        // Odstraní přiřazení úkolu od uživatele.
        public static void UnassignTaskFromUser(int userId, int taskId)
        {
            var userTasks = GetAllUserTasks();
            userTasks.RemoveAll(ut => ut.UserId == userId && ut.TaskId == taskId);
            File.WriteAllText(userTasksFile, System.Text.Json.JsonSerializer.Serialize(userTasks, _options));
        }

        // Vrátí seznam ID všech úkolů, které jsou přiřazeny danému uživateli.
        public static List<int> GetUserTaskIds(int userId)
        {
            return GetAllUserTasks()
                .Where(ut => ut.UserId == userId)
                .Select(ut => ut.TaskId)
                .ToList();
        }

        // Kontroluje, zda je specifický úkol přiřazen danému uživateli.
        public static bool IsTaskAssignedToUser(int userId, int taskId)
        {
            return GetAllUserTasks().Any(ut => ut.UserId == userId && ut.TaskId == taskId);
        }
    }
}