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
    // В файле ProjectsMenu.cs
    public partial class ProjectListControl : UserControl
    {
        public ProjectListControl()
        {
            InitializeComponent(); // БЕЗ ЭТОГО flpProjects ВСЕГДА БУДЕТ NULL
        }
        public void LoadProjects()
            {
                flpProjects.Controls.Clear();
                var projects = DataManager.GetAllProjects();        

                foreach (var project in projects)
                {
                    ProjectCard projectCard = new ProjectCard();
                    projectCard.SetProjectData(project); // Передаем объект проекта целиком

                    // ПОДПИСЫВАЕМСЯ на клик по этой карточке
                    projectCard.OnProjectClicked += (selectedProject) =>
                    {
                        ShowTasksForProject(selectedProject); // Переходим к задачам
                    };

                    projectCard.Margin = new Padding(10);
                    flpProjects.Controls.Add(projectCard);
                }
            }

            // Метод для отображения задач конкретного проекта
            private void ShowTasksForProject(Project project)
            {
                flpProjects.Controls.Clear();

                // 1. Добавляем кнопку "Назад", чтобы вернуться к проектам
                Button btnBack = new Button { Text = "<- Back", Width = 150, Height = 40 };
                btnBack.Click += (s, e) => LoadProjects(); // Просто перезагружаем проекты
                flpProjects.Controls.Add(btnBack);

                // 2. Добавляем задачи проекта
                if (project.Tasks != null && project.Tasks.Count > 0)
                {
                    foreach (var task in project.Tasks)
                    {
                        TaskCard taskCard = new TaskCard();
                        taskCard.SetTaskData(task); // Передаем данные задачи
                        flpProjects.Controls.Add(taskCard);
                    }
                }
                else
                {
                    // Сообщение, если задач нет
                    Label emptyLabel = new Label { Text = "This project hasnt task", AutoSize = true };
                    flpProjects.Controls.Add(emptyLabel);
                }
            }
    }
}
