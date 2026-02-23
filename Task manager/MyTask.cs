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
    public partial class MyTask : UserControl
    {
        private User _currentUser;

        // Konstruktor komponenty, který inicializuje ovládací prvky.
        public MyTask()
        {
            InitializeComponent();
        }

        // Konstruktor, který inicializuje komponentu a nastavuje aktuálního uživatele.
        public MyTask(User user) : this()
        {
            _currentUser = user;
        }

        // Načítá seznam všech úkolů přiřazených aktuálnímu uživateli a zobrazuje je jako karty.
        // Pokud uživatel není přihlášen nebo nemá žádné úkoly, zobrazí odpovídající zprávu.
        public void LoadMyTasks()
        {
            flpMyTask.Controls.Clear();

            if (_currentUser == null)
            {
                Label lblNoUser = new Label
                {
                    Text = "User not logged in",
                    AutoSize = true,
                    Margin = new Padding(10),
                    ForeColor = Color.Red
                };
                flpMyTask.Controls.Add(lblNoUser);
                return;
            }

            var assignedTaskIds = DataManager.GetUserTaskIds(_currentUser.Id);

            if (assignedTaskIds.Count == 0)
            {
                Label lblNoTasks = new Label
                {
                    Text = "No tasks assigned to you",
                    AutoSize = true,
                    Margin = new Padding(10),
                    ForeColor = SystemColors.GrayText,
                    Font = new Font("Arial", 11, FontStyle.Italic)
                };
                flpMyTask.Controls.Add(lblNoTasks);
                return;
            }

            var allTasks = DataManager.GetAllTasks();
            var myTasks = allTasks.Where(t => assignedTaskIds.Contains(t.Id)).ToList();

            // Vytváří karty úkolů pro každý přiřazený úkol a přidává je do panelu.
            foreach (var task in myTasks)
            {
                TaskCard taskCard = new TaskCard();
                taskCard.SetTaskData(task);
                taskCard.Margin = new Padding(10);

                taskCard.Click += (s, e) => ShowTaskDetails(task);

                flpMyTask.Controls.Add(taskCard);
            }
        }

        // Zobrazuje detailní informace o vybraném úkolu.
        // Umožňuje uživateli vrátit se na seznam úkolů nebo aktualizovat úkol.
        private void ShowTaskDetails(TaskItem task)
        {
            flpMyTask.Controls.Clear();

            TaskDetailsUC taskDetailsUC = new TaskDetailsUC();
            taskDetailsUC.LoadTaskDetails(task, _currentUser);

            taskDetailsUC.OnBack += () => LoadMyTasks();
            taskDetailsUC.OnTaskUpdated += () =>
            {
                flpMyTask.Controls.Clear();
                ShowTaskDetails(DataManager.GetAllTasks().First(t => t.Id == task.Id));
            };

            flpMyTask.Controls.Add(taskDetailsUC);
        }
    }
}
