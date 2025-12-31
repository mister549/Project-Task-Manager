using System;
using System.Collections.Generic;
using System.IO;                // Для работы с файлами
using System.Linq;
using System.Text.Json;
using System.Xml;
using Newtonsoft.Json;         // Для работы с JSON (нужно установить NuGet!)
using Task_manager.Models;
    
namespace Task_manager
    {
    public static class DataManager
    {
        // Путь к файлу (создастся в папке с программой)
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects_database.json");
        private static string completedPath = "completed_tasks.json";


        public static void SaveProject(Project project)
        {
            string filePath = "projects_database.json";
            List<Project> projects;

            // 1. Проверяем, существует ли файл. Если да — читаем его.
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                // Десериализуем (превращаем JSON обратно в List)
                projects = System.Text.Json.JsonSerializer.Deserialize<List<Project>>(existingJson) ?? new List<Project>();
            }
            else
            {
                // Если файла нет — создаем пустой список
                projects = new List<Project>();
            }

            // 2. Добавляем наш новый проект в список
            projects.Add(project);

            // 3. Сохраняем весь список обратно
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(projects, options);
            File.WriteAllText(filePath, jsonString);
        }
        public static bool IsProjectNameExists(string name)
        {
            if (!File.Exists(filePath)) return false;

            try
            {
                string json = File.ReadAllText(filePath);
                var projects = System.Text.Json.JsonSerializer.Deserialize<List<Project>>(json);

                return projects?.Any(p => p.Name.Trim().Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)) ?? false;
            }
            catch (Exception ex)
            {
                // Ошибка при чтении файла
                MessageBox.Show($"Error reading database: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static List<Project> GetAllProjects()
        {
            if (!File.Exists(filePath)) return new List<Project>();

            try
            {
                string json = File.ReadAllText(filePath);
                return System.Text.Json.JsonSerializer.Deserialize<List<Project>>(json) ?? new List<Project>();
            }
            catch
            {
                return new List<Project>();
            }
        }
        public static void SaveTask(TaskItem task)
        {
            string filePath = "projects_database.json";

            // 1. Загружаем все проекты
            List<Project> projects = GetAllProjects();

            // 2. Ищем проект, имя которого совпадает с именем проекта в задаче
            var targetProject = projects.FirstOrDefault(p => p.Name == task.ProjectName);

            if (targetProject != null)
            {
                // 3. Если списка задач еще нет (null), создаем его
                if (targetProject.Tasks == null)
                    targetProject.Tasks = new List<TaskItem>();

                // 4. Добавляем задачу в проект
                targetProject.Tasks.Add(task);

                // 5. Сериализуем и сохраняем обновленный список проектов
                var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
                string jsonString = System.Text.Json.JsonSerializer.Serialize(projects, options);
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                throw new Exception("Проект не найден!");
            }
        }
            public static void SaveAllData(List<Project> projects)
        {
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(projects, options);
            File.WriteAllText(filePath, jsonString);
        }   
    public static void MoveToCompleted(TaskItem task)
        {
            // 1. Загружаем все проекты
            var projects = GetAllProjects();

            // 2. Ищем проект и удаляем из него задачу
            var project = projects.FirstOrDefault(p => p.Name == task.ProjectName);
            if (project != null)
            {
                var taskToRemove = project.Tasks.FirstOrDefault(t => t.Title == task.Title);
                if (taskToRemove != null)
                {
                    project.Tasks.Remove(taskToRemove);
                }
            }

            // 3. Сохраняем обновленный список проектов (уже без этой задачи)
            SaveAllData(projects);

            // 4. Загружаем список УЖЕ выполненных задач из второго файла
            List<TaskItem> completedTasks = new List<TaskItem>();
            if (File.Exists(completedPath))
            {
                string json = File.ReadAllText(completedPath);
                completedTasks = System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }

            // 5. Добавляем нашу задачу в архив
            task.IsCompleted = true;
            completedTasks.Add(task);

            // 6. Сохраняем архив обратно в файл
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(completedPath, System.Text.Json.JsonSerializer.Serialize(completedTasks, options));
        }

        // Метод для получения всех выполненных задач (для отдельной вкладки)
        public static List<TaskItem> GetCompletedTasks()
        {
            if (!File.Exists(completedPath)) return new List<TaskItem>();
            string json = File.ReadAllText(completedPath);
            return System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }

}