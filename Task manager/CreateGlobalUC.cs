using Task_manager.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Task_manager
{
    public partial class CreateGlobalUC : UserControl
    {
        public CreateGlobalUC()
        {
            InitializeComponent();

            // Загружаем список проектов при открытии
            LoadProjectsToSelector();
        }

        // --- ОБЩИЕ МЕТОДЫ ---

        private void LoadProjectsToSelector()
        {
            lbProjectSelector.Items.Clear();
            var projects = DataManager.GetAllProjects();
            foreach (var p in projects)
            {
                lbProjectSelector.Items.Add(p.Name);
            }
        }

        // --- ЛОГИКА ПРОЕКТОВ ---

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            string name = txtProjectName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a project name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DataManager.IsProjectNameExists(name))
            {
                MessageBox.Show($"Project '{name}' already exists!", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Project newProject = new Project { Name = name };
                DataManager.SaveProject(newProject);

                MessageBox.Show($"Project '{name}' created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtProjectName.Clear();
                LoadProjectsToSelector(); // Сразу обновляем список справа
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // --- ЛОГИКА ЗАДАЧ ---

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();

            // Проверяем, выбрал ли пользователь проект в ListBox
            if (lbProjectSelector.SelectedItem == null)
            {
                MessageBox.Show("Please select a project from the list!", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(taskName))
            {
                MessageBox.Show("Please enter a task name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectedProject = lbProjectSelector.SelectedItem.ToString();

                TaskItem newTask = new TaskItem
                {
                    Title = taskName,
                    ProjectName = selectedProject
                };

                DataManager.SaveTask(newTask);

                MessageBox.Show($"Task added to {selectedProject}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaskName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}