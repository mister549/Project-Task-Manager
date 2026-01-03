using Task_manager.Models;

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
            // Получаем список объектов
            var projects = DataManager.GetAllProjects();

            // Привязываем данные правильно
            lbProjectSelector.DataSource = null; // Сброс
            lbProjectSelector.DataSource = projects;
            lbProjectSelector.DisplayMember = "Name"; // Что видит пользователь
            lbProjectSelector.ValueMember = "Id";    // Что мы получаем в коде
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

            // В новом DataManager проверка имени может быть внутри Save или здесь
            if (DataManager.GetAllProjects().Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Project '{name}' already exists!", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Используем новый метод сохранения (передаем только имя)
                DataManager.SaveProject(name);

                MessageBox.Show($"Project '{name}' created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtProjectName.Clear();
                LoadProjectsToSelector();
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

            if (lbProjectSelector.SelectedItem == null)
            {
                MessageBox.Show("Please select a project!", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(taskName))
            {
                MessageBox.Show("Please enter a task name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedProject = (Project)lbProjectSelector.SelectedItem;
                int projectId = selectedProject.Id;

                // --- НОВАЯ ПРОВЕРКА НА ДУБЛИКАТЫ ---
                if (DataManager.IsTaskTitleExists(projectId, taskName))
                {
                    MessageBox.Show($"Task '{taskName}' already exists in this project!",
                                    "Duplicate Task", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Прерываем выполнение, задача не сохранится
                }

                // Если проверки прошли, сохраняем
                DataManager.SaveTask(projectId, taskName);

                MessageBox.Show($"Task added to {selectedProject.Name}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaskName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}