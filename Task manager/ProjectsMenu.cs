using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_manager.Models;

namespace Task_manager
{
    public partial class ProjectListControl : UserControl
    {
        public ProjectListControl()
        {
            InitializeComponent();
        }

        public void LoadProjects()
        {
            flpProjects.Controls.Clear();
            var projects = DataManager.GetAllProjects();

            foreach (var project in projects)
            {
                ProjectCard projectCard = new ProjectCard();
                projectCard.SetProjectData(project);

                // Подписываемся на клик по карточке
                projectCard.OnProjectClicked += (selectedProject) =>
                {
                    ShowTasksForProject(selectedProject);
                };

                projectCard.Margin = new Padding(10);
                flpProjects.Controls.Add(projectCard);
            }
        }

        // Метод для отображения задач конкретного проекта
        private void ShowTasksForProject(Project project)
        {
            flpProjects.Controls.Clear();

            Button btnBack = new Button { Text = "<- К проектам", Width = 150, Height = 40 };
            btnBack.Click += (s, e) => LoadProjects();
            flpProjects.Controls.Add(btnBack);

            var projectTasks = DataManager.GetTasksByProjectId(project.Id);

            foreach (var task in projectTasks)
            {
                TaskCard taskCard = new TaskCard();
                taskCard.SetTaskData(task);

                // ПОДПИСЫВАЕМСЯ НА КЛИК ПО ЗАДАЧЕ
                taskCard.Click += (s, e) => ShowTaskDetails(task, project);
                // Если внутри TaskCard есть контролы, подпишись на них тоже или пробрось событие

                flpProjects.Controls.Add(taskCard);
            }
        }
        // В ProjectListControl.cs

        private void ShowTaskDetails(TaskItem task, Project parentProject)
        {
            flpProjects.Controls.Clear();

            // Back Button
            Button btnBack = new Button { Text = "<- Back to tasks", Width = 150, Height = 40, Margin = new Padding(10) };
            btnBack.Click += (s, e) => ShowTasksForProject(parentProject);
            flpProjects.Controls.Add(btnBack);

            // Header Panel
            Panel header = new Panel { Width = flpProjects.Width - 40, Height = 60 };
            Label lblTitle = new Label { Text = "Task: " + task.Title, Font = new Font("Arial", 12, FontStyle.Bold), AutoSize = true, Location = new Point(10, 5) };

            // Пересчитываем статус для отображения
            string statusText = task.IsCompleted ? "Status: COMPLETED" : "Status: IN PROGRESS";
            Label lblStatus = new Label { Text = statusText, Location = new Point(10, 30), AutoSize = true, ForeColor = task.IsCompleted ? Color.Green : Color.OrangeRed };

            header.Controls.Add(lblTitle);
            header.Controls.Add(lblStatus);
            flpProjects.Controls.Add(header);

            // To-Do List Section
            Label lblTodo = new Label { Text = "To-Do List:", Font = new Font("Arial", 10, FontStyle.Underline), AutoSize = true, Margin = new Padding(10, 20, 0, 5) };
            flpProjects.Controls.Add(lblTodo);

            var subTasks = DataManager.GetAllSubTasks().Where(s => s.ParentTaskId == task.Id).ToList();

            foreach (var sub in subTasks)
            {
                CheckBox cb = new CheckBox
                {
                    Text = sub.Description,
                    Checked = sub.IsDone,
                    Width = flpProjects.Width - 50,
                    Margin = new Padding(20, 5, 0, 5)
                };

                cb.CheckedChanged += (s, e) => {
                    DataManager.UpdateSubTaskStatus(sub.Id, cb.Checked);
                    // Перерисовываем экран, чтобы обновить надпись Status
                    ShowTaskDetails(DataManager.GetAllTasks().First(t => t.Id == task.Id), parentProject);
                };

                flpProjects.Controls.Add(cb);
            }

            // Add New To-Do Input
            TextBox txtNewSub = new TextBox { Width = 200, Margin = new Padding(20, 20, 0, 0) };
            Button btnAddSub = new Button { Text = "Add Step", Width = 100 };
            btnAddSub.Click += (s, e) => {
                if (!string.IsNullOrWhiteSpace(txtNewSub.Text))
                {
                    DataManager.AddSubTask(task.Id, txtNewSub.Text);
                    ShowTaskDetails(task, parentProject); // Refresh
                }
            };

            flpProjects.Controls.Add(txtNewSub);
            flpProjects.Controls.Add(btnAddSub);
        }
    }       
}