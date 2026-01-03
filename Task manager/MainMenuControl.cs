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
        // Создаем переменную для нашего списка на уровне класса
        // ProjectListControl — это твой класс, projectsView — это наше имя для него
        private ProjectListControl projectsView;
        private User _currentUser;
        public MainMenuControl(User user) : this()
        {
            _currentUser = user;

            lblUserGreeting.Text = $"Hi, {user.Username}!";
        }

        public MainMenuControl()
        {
            InitializeComponent();
        }

        private void btnCreateGlobal_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            CreateGlobalUC createUC = new CreateGlobalUC();
            createUC.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(createUC);
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            projectsView = new ProjectListControl();
            projectsView.Dock = DockStyle.Fill; // Это заставит его растянуться на всю pnlContent

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(projectsView);

            projectsView.LoadProjects();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
        }
    }
}
