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

        // Konstruktor komponenty, který inicializuje ovládací prvky.
        public ProjectListControl()
        {
            InitializeComponent();
        }

        // Konstruktor, který inicializuje komponentu a nastavuje aktuálního uživatele a obsah panelu.
        public ProjectListControl(User user, Panel contentPanel) : this()
        {
            _currentUser = user;
            _contentPanel = contentPanel;
        }

        // Načítá seznam všech projektů a vytváří pro ně kartičky.
        // Každá kartička má klikáním oznamovatel, který zobrazí úkoly příslušného projektu.
        public void LoadProjects()
        {
            flpProjects.Controls.Clear();
            var projects = DataManager.GetAllProjects();

            // Vytváří karty projektů pro každý projekt a přidává je do panelu.
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

        // Zobrazuje seznam úkolů pro vybraný projekt.
        // Umožňuje uživateli vrátit se na seznam projektů nebo vybrat úkol pro zobrazení detailů.
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

        // Zobrazuje detailní informace o vybraném úkolu.
        // Umožňuje uživateli vrátit se na seznam úkolů projektu nebo aktualizovat úkol.
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