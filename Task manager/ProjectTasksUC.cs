using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Task_manager.Models;

namespace Task_manager
{
    public partial class ProjectTasksUC : UserControl
    {
        private Project _currentProject;
        private User _currentUser;

        public event Action OnBack;
        public event Action<TaskItem> OnTaskSelected;

        public ProjectTasksUC()
        {
            InitializeComponent();
        }

        public void LoadProjectTasks(Project project, User user)
        {
            _currentProject = project;
            _currentUser = user;

            flpTasks.Controls.Clear();

            var projectTasks = DataManager.GetTasksByProjectId(project.Id);

            if (projectTasks.Count == 0)
            {
                Label lblNoTasks = new Label
                {
                    Text = "No tasks in this project",
                    AutoSize = true,
                    Margin = new Padding(10),
                    ForeColor = SystemColors.GrayText,
                    Font = new Font("Arial", 11, FontStyle.Italic)
                };
                flpTasks.Controls.Add(lblNoTasks);
                return;
            }

            foreach (var task in projectTasks)
            {
                TaskCard taskCard = new TaskCard();
                taskCard.SetTaskData(task);
                taskCard.Margin = new Padding(10);

                taskCard.Click += (s, e) => OnTaskSelected?.Invoke(task);

                flpTasks.Controls.Add(taskCard);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke();
        }
    }
}




