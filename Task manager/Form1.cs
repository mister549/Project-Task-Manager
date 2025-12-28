using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Task_manager
{
    public partial class MainMenu : Form
    {
        // Создаем переменную для нашего списка на уровне класса
        // ProjectListControl — это твой класс, projectsView — это наше имя для него
        private ProjectListControl projectsView;

        public MainMenu()
        {
            InitializeComponent();

            projectsView = new ProjectListControl();
            projectsView.Dock = DockStyle.Fill; // Это заставит его растянуться на всю pnlContent

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(projectsView);

            projectsView.LoadProjects();
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
    }
}
