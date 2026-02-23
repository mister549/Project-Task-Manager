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
    public partial class TaskStepsUC : UserControl
    {
        public event Action OnStepsUpdated;

        // Konstruktor komponenty, který inicializuje ovládací prvky.
        public TaskStepsUC()
        {
            InitializeComponent();
        }

        // Naèítá seznam všech podúkolù (krokù) pro zadaný úkol a vytváøí pro nì zaškrtávací pole.
        // Pokud úkol neobsahuje žádné podúkoly, zobrazí odpovídající zprávu.
        // Každé zaškrtávací pole má posluchaè, který aktualizuje stav podúkolu v úložišti dat.
        public void LoadTaskSteps(TaskItem task)
        {
            flpSteps.Controls.Clear();

            var subTasks = DataManager.GetAllSubTasks().Where(s => s.ParentTaskId == task.Id).ToList();

            if (subTasks.Count == 0)
            {
                Label lblNoSubTasks = new Label
                {
                    Text = "No steps added yet",
                    Margin = new Padding(20, 5, 0, 10),
                    AutoSize = true,
                    ForeColor = SystemColors.GrayText,
                    Font = new Font("Arial", 9, FontStyle.Italic)
                };
                flpSteps.Controls.Add(lblNoSubTasks);
            }
            else
            {
                // Vytváøí zaškrtávací pole pro každý podúkol a nastavuje jejich stav.
                foreach (var sub in subTasks)
                {
                    CheckBox cb = new CheckBox
                    {
                        Text = sub.Description,
                        Checked = sub.IsDone,
                        Width = this.Width - 50,
                        Margin = new Padding(20, 5, 0, 5),
                        Font = new Font("Arial", 9),
                        Tag = sub.Id
                    };

                    cb.CheckedChanged += (s, e) => {
                        DataManager.UpdateSubTaskStatus(sub.Id, cb.Checked);
                        OnStepsUpdated?.Invoke();
                    };

                    flpSteps.Controls.Add(cb);
                }
            }
        }
    }
}
