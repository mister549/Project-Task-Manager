using System;
using System.Collections.Generic;
using System.IO;                // Для работы с файлами
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;         // Для работы с JSON (нужно установить NuGet!)
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

        // --- РАБОТА С ПРОЕКТАМИ ---

        public static List<Project> GetAllProjects()
        {
            if (!File.Exists(projectsFile)) return new List<Project>();
            string json = File.ReadAllText(projectsFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<Project>>(json) ?? new List<Project>();
        }

        public static void SaveProject(string name)
        {
            var projects = GetAllProjects();

            // Генерируем ID (Max + 1)
            int nextId = projects.Count > 0 ? projects.Max(p => p.Id) + 1 : 1;

            projects.Add(new Project { Id = nextId, Name = name });
            File.WriteAllText(projectsFile, System.Text.Json.JsonSerializer.Serialize(projects, _options));
        }

        // --- РАБОТА С ЗАДАЧАМИ ---

        public static List<TaskItem> GetAllTasks()
        {
            if (!File.Exists(tasksFile)) return new List<TaskItem>();
            string json = File.ReadAllText(tasksFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
        public static void SaveTask(int projectId, string title)
        {
            var allTasks = GetAllTasks();
            int nextTaskId = allTasks.Count > 0 ? allTasks.Max(t => t.Id) + 1 : 1;

            allTasks.Add(new TaskItem
            {
                Id = nextTaskId,
                ProjectId = projectId,
                Title = title,
                IsCompleted = false // Изначально не выполнена
            });
            File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));

            // АВТОМАТИЧЕСКИЙ ПЕРВЫЙ TO-DO
            AddSubTask(nextTaskId, "auto step");
        }
        public static List<TaskItem> GetTasksByProjectId(int projectId)
        {
            return GetAllTasks().Where(t => t.ProjectId == projectId).ToList();
        }
        public static bool IsTaskTitleExists(int projectId, string title)
        {
            var allTasks = GetAllTasks();
            // Ищем задачу, у которой совпадает и ID проекта, и название (без учета регистра)
            return allTasks.Any(t => t.ProjectId == projectId &&
                                     t.Title.Trim().Equals(title.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        // --- Удаление задачи ---
        public static void DeleteTask(int taskId)
        {
            var allTasks = GetAllTasks();
            allTasks.RemoveAll(t => t.Id == taskId);
            File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));
        }
        public static void UpdateTask(TaskItem updatedTask)
        {
            var allTasks = GetAllTasks();
            var task = allTasks.FirstOrDefault(t => t.Id == updatedTask.Id);

            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.IsCompleted = updatedTask.IsCompleted;
                // Сохраняем обновленный список всех задач
                File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));
            }
        }
        public static List<SubTask> GetAllSubTasks()
        {
            if (!File.Exists(subTasksFile)) return new List<SubTask>();
            string json = File.ReadAllText(subTasksFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<SubTask>>(json) ?? new List<SubTask>();
        }
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
        public static void UpdateSubTaskStatus(int subTaskId, bool isDone)
        {
            var allSubTasks = GetAllSubTasks();
            var sub = allSubTasks.FirstOrDefault(s => s.Id == subTaskId);
            if (sub == null) return;

            sub.IsDone = isDone;
            File.WriteAllText(subTasksFile, System.Text.Json.JsonSerializer.Serialize(allSubTasks, _options));

            // Проверяем все подзадачи этого родителя
            CheckAndUpdateTaskCompletion(sub.ParentTaskId);
        }

        private static void CheckAndUpdateTaskCompletion(int taskId)
        {
            var allSubTasks = GetAllSubTasks().Where(s => s.ParentTaskId == taskId).ToList();
            var allTasks = GetAllTasks();
            var parentTask = allTasks.FirstOrDefault(t => t.Id == taskId);

            if (parentTask != null)
            {
                // Задача выполнена, ТОЛЬКО если все подзадачи выполнены
                parentTask.IsCompleted = allSubTasks.All(s => s.IsDone);
                File.WriteAllText(tasksFile, System.Text.Json.JsonSerializer.Serialize(allTasks, _options));
            }
        }

        // --- РАБОТА С UserTask ---

        public static List<UserTask> GetAllUserTasks()
        {
            if (!File.Exists(userTasksFile)) return new List<UserTask>();
            string json = File.ReadAllText(userTasksFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<UserTask>>(json) ?? new List<UserTask>();
        }

        public static void AssignTaskToUser(int userId, int taskId)
        {
            var userTasks = GetAllUserTasks();

            // Проверяем, не назначена ли уже эта задача этому пользователю
            if (userTasks.Any(ut => ut.UserId == userId && ut.TaskId == taskId))
            {
                return; // Уже назначена
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

        public static void UnassignTaskFromUser(int userId, int taskId)
        {
            var userTasks = GetAllUserTasks();
            userTasks.RemoveAll(ut => ut.UserId == userId && ut.TaskId == taskId);
            File.WriteAllText(userTasksFile, System.Text.Json.JsonSerializer.Serialize(userTasks, _options));
        }

        public static List<int> GetUserTaskIds(int userId)
        {
            return GetAllUserTasks()
                .Where(ut => ut.UserId == userId)
                .Select(ut => ut.TaskId)
                .ToList();
        }

        public static bool IsTaskAssignedToUser(int userId, int taskId)
        {
            return GetAllUserTasks().Any(ut => ut.UserId == userId && ut.TaskId == taskId);
        }
    }
}