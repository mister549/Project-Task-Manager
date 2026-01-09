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
    public partial class MainMenuControl : UserControl
    {
        private User _currentUser;

        public MainMenuControl(User user) : this()
        {
            _currentUser = user;
            lblUserGreeting.Text = $"👤 {user.Username}\nLogged In";
            
            // Проверяем роль пользователя для кнопки Create
            btnCreateGlobal.Enabled = user.Role?.Equals("Administrator", StringComparison.OrdinalIgnoreCase) ?? false;
            if (!btnCreateGlobal.Enabled)
            {
                btnCreateGlobal.Text = "Create\n(Admin Only)";
                btnCreateGlobal.BackColor = SystemColors.Control;
                btnCreateGlobal.ForeColor = SystemColors.GrayText;
            }
        }

        public MainMenuControl()
        {
            InitializeComponent();
        }

        private void btnCreateGlobal_Click(object sender, EventArgs e)
        {
            if (!btnCreateGlobal.Enabled)
            {
                MessageBox.Show("Only administrators can create projects and tasks.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlContent.Controls.Clear();
            CreateGlobalUC createUC = new CreateGlobalUC();
            createUC.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(createUC);
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            ProjectListControl projectsView = new ProjectListControl(_currentUser, pnlContent);
            projectsView.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(projectsView);

            projectsView.LoadProjects();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
        }

        private void btnMyTask_Click(object sender, EventArgs e)
        {
            MyTask TaskView = new MyTask(_currentUser);
            TaskView.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(TaskView);

            TaskView.LoadMyTasks();
        }
    }
}
