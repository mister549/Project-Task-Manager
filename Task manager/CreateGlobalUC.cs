using Task_manager.Models;

namespace Task_manager
{
    public partial class CreateGlobalUC : UserControl
    {
        // Konstruktor komponenty, který inicializuje ovládací prvky a nastavuje obslužné programy událostí.
        // Načítá seznam projektů a registruje posluchače pro změny výběru a kliknutí na tlačítka.
        public CreateGlobalUC()
        {
            InitializeComponent();

            LoadProjectsToSelector();

            lbProjectSelector.SelectedIndexChanged += LbProjectSelector_SelectedIndexChanged;
            btnAddStepToList.Click += BtnAddStepToList_Click;
        }

        // Načítá všechny projekty z úložiště dat a zobrazuje je v seznamu pro výběr.
        // Nastavuje vlastnosti DisplayMember a ValueMember pro správné zobrazení dat.
        private void LoadProjectsToSelector()
        {
            var projects = DataManager.GetAllProjects();

            lbProjectSelector.DataSource = null;
            lbProjectSelector.DataSource = projects;
            lbProjectSelector.DisplayMember = "Name";
            lbProjectSelector.ValueMember = "Id";
            lbProjectSelector.SelectedIndex = -1;
        }

        // Načítá seznam úkolů pro vybraný projekt a zobrazuje je v seznamu náhledu.
        // Pokud není vybrán žádný projekt, seznam zůstane prázdný.
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

        // Obslužný program pro změnu vybraného projektu v seznamu.
        // Zavolá metodu LoadTasksForSelectedProject() k aktualizaci seznamu úkolů.
        private void LbProjectSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasksForSelectedProject();
        }

        // Vytváří nový projekt na základě zadaného názvu.
        // Ověřuje, zda není prázdný a zda již neexistuje projekt se stejným názvem.
        // Pokud je projekt úspěšně vytvořen, aktualizuje seznam projektů.
        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            string name = txtProjectName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a project name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DataManager.GetAllProjects().Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Project '{name}' already exists!", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
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

        // Vytváří nový úkol pro vybraný projekt.
        // Ověřuje, zda je vybrán projekt a zda není prázdné jméno úkolu.
        // Kontroluje, zda úkol se stejným názvem již neexistuje v projektu.
        // Pokud je úkol úspěšně vytvořen, aktualizuje seznam úkolů.
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

                if (DataManager.IsTaskTitleExists(projectId, taskName))
                {
                    MessageBox.Show($"Task '{taskName}' already exists in this project!",
                                    "Duplicate Task", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

        // Přidá nový podúkol (krok) k vybranému úkolu.
        // Ověřuje, zda je vybrán úkol a zda není prázdný popis kroku.
        // Uloží podúkol do úložiště dat.
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

                DataManager.AddSubTask(taskId, stepDescription);

                MessageBox.Show($"Step added to task '{selectedTask.Title}'!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStepInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}