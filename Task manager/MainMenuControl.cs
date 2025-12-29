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

        private void MainMenu_Load(object sender, EventArgs e)
        {
            ShowProjectList();
        }

        private void ShowProjectList()
        {
            // 1. Создаем новый экземпляр твоего контрола
            projectsView = new ProjectListControl();

            // 2. Растягиваем его на всю панель pnlContent (бывшая p2)
            projectsView.Dock = DockStyle.Fill;

            // 3. Очищаем панель на всякий случай и добавляем туда наш список
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(projectsView);

            // 4. Загружаем проекты из JSON
            projectsView.LoadProjects();
        }

        private void btnCreateGlobal_Click(object sender, EventArgs e)
        {
            AddProjectForm addForm = new AddProjectForm();

            // If the project was successfully created
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Just refresh the list that is already inside the panel
                projectsView.LoadProjects();
            }
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
