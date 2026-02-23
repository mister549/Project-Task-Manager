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

        // Konstruktor komponenty, kter� inicializuje ovl�dac� prvky.
        public ProjectTasksUC()
        {
            InitializeComponent();
        }

        // Na��t� seznam v�ech �kol� pro zadan� projekt a zobrazuje je jako karty.
        // Pokud projekt neobsahuje ��dn� �koly, zobraz� odpov�daj�c� zpr�vu.
        // Ka�d� karti�ka �kolu m� klik�n�m oznamovatel, kter� vyvol� ud�lost OnTaskSelected.
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

            // Vytv��� karty �kol� pro ka�d� �kol v projektu a p�id�v� je do panelu.
            foreach (var task in projectTasks)
            {
                TaskCard taskCard = new TaskCard();
                taskCard.SetTaskData(task);
                taskCard.Margin = new Padding(10);

                taskCard.Click += (s, e) => OnTaskSelected?.Invoke(task);

                flpTasks.Controls.Add(taskCard);
            }
        }

        // Obslu�n� program pro kliknut� na tla��tko "Zp�t".
        // Vyvol� ud�lost OnBack pro n�vrat na p�edchoz� obrazovku.
        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke();
        }
    }
}




