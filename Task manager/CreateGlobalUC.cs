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

            // Подписываемся на событие смены выбора проекта
            lbProjectSelector.SelectedIndexChanged += LbProjectSelector_SelectedIndexChanged;
            btnAddStepToList.Click += BtnAddStepToList_Click;
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

            // Убираем автоматический выбор первого проекта
            lbProjectSelector.SelectedIndex = -1;
        }

        private void LoadTasksForSelectedProject()
        {
            lbTasksPreview.DataSource = null;

            if (lbProjectSelector.SelectedItem == null)
            {
                return;
            }

            var selectedProject = (Project)lbProjectSelector.SelectedItem;
            var projectTasks = DataManager.GetTasksByProjectId(selectedProject.Id);

            lbTasksPreview.DataSource = projectTasks;
            lbTasksPreview.DisplayMember = "Title";
            lbTasksPreview.ValueMember = "Id";
        }

        private void LbProjectSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasksForSelectedProject();
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
                lbProjectSelector.SelectedIndex = -1;
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
                LoadTasksForSelectedProject();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // --- ЛОГИКА STEPS (SUBTASKS) ---

        private void BtnAddStepToList_Click(object sender, EventArgs e)
        {
            string stepDescription = txtStepInput.Text.Trim();

            if (lbTasksPreview.SelectedItem == null)
            {
                MessageBox.Show("Please select a task first!", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(stepDescription))
            {
                MessageBox.Show("Please enter a step description!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedTask = (TaskItem)lbTasksPreview.SelectedItem;
                int taskId = selectedTask.Id;

                // Сохраняем подзадачу
                DataManager.AddSubTask(taskId, stepDescription);

                MessageBox.Show($"Step added to task '{selectedTask.Title}'!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStepInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CreateGlobalUC_Load(object sender, EventArgs e)
        {

        }
    }
}