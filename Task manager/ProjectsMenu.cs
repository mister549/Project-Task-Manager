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
        private User _currentUser;
        private Panel _contentPanel;

        public ProjectListControl()
        {
            InitializeComponent();
        }

        public ProjectListControl(User user, Panel contentPanel) : this()
        {
            _currentUser = user;
            _contentPanel = contentPanel;
        }

        public void LoadProjects()
        {
            flpProjects.Controls.Clear();
            var projects = DataManager.GetAllProjects();

            foreach (var project in projects)
            {
                ProjectCard projectCard = new ProjectCard();
                projectCard.SetProjectData(project);

                projectCard.OnProjectClicked += (selectedProject) =>
                {
                    ShowProjectTasks(selectedProject);
                };

                projectCard.Margin = new Padding(10);
                flpProjects.Controls.Add(projectCard);
            }
        }

        private void ShowProjectTasks(Project project)
        {
            _contentPanel.Controls.Clear();

            ProjectTasksUC projectTasksUC = new ProjectTasksUC();
            projectTasksUC.LoadProjectTasks(project, _currentUser);
            projectTasksUC.Dock = DockStyle.Fill;

            projectTasksUC.OnBack += () => 
            {
                _contentPanel.Controls.Clear();
                _contentPanel.Controls.Add(this);
                LoadProjects();
            };
            projectTasksUC.OnTaskSelected += (task) => ShowTaskDetails(task, project);

            _contentPanel.Controls.Add(projectTasksUC);
        }

        private void ShowTaskDetails(TaskItem task, Project parentProject)
        {
            _contentPanel.Controls.Clear();

            TaskDetailsUC taskDetailsUC = new TaskDetailsUC();
            taskDetailsUC.LoadTaskDetails(task, _currentUser);
            taskDetailsUC.Dock = DockStyle.Fill;

            taskDetailsUC.OnBack += () => ShowProjectTasks(parentProject);
            taskDetailsUC.OnTaskUpdated += () =>
            {
                _contentPanel.Controls.Clear();
                ShowTaskDetails(DataManager.GetAllTasks().First(t => t.Id == task.Id), parentProject);
            };

            _contentPanel.Controls.Add(taskDetailsUC);
        }
    }       
}