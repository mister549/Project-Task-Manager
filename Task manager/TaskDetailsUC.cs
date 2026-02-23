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
    public partial class TaskDetailsUC : UserControl
    {
        private TaskItem _currentTask;
        private User _currentUser;

        public event Action OnBack;
        public event Action OnTaskUpdated;

        // Konstruktor komponenty, který inicializuje ovládací prvky.
        public TaskDetailsUC()
        {
            InitializeComponent();
        }

        // Naèítá detailní informace o úkolu vèetnì názvu, popisu a podúkolù.
        // Nastavuje stavy tlaèítek na základì toho, zda je úkol pøiøazen aktuálnímu uživateli.
        public void LoadTaskDetails(TaskItem task, User user)
        {
            _currentTask = task;
            _currentUser = user;

            // Title
            lblTitle.Text = task.Title;

            // Description
            txtDescription.Text = task.Description ?? "";

            // Load task steps
            taskStepsUC.LoadTaskSteps(task);
            taskStepsUC.OnStepsUpdated += () => OnTaskUpdated?.Invoke();

            // Update button states based on assignment
            UpdateAssignmentButtons();
        }

        // Aktualizuje stavy tlaèítek "Pøiøadit mì" a "Opustit" na základì toho,
        // zda je úkol pøiøazen aktuálnímu uživateli.
        private void UpdateAssignmentButtons()
        {
            if (_currentUser == null || _currentTask == null) return;

            bool isAssigned = DataManager.IsTaskAssignedToUser(_currentUser.Id, _currentTask.Id);

            btnAssignToMe.Enabled = !isAssigned;
            btnLeave.Enabled = isAssigned;
            contentPanel.Enabled = isAssigned;
        }

        // Ukládá aktualizovaný popis úkolu do úložištì dat.
        // Vyvolá událost OnTaskUpdated po úspìšném uložení.
        private void btnSaveDesc_Click(object sender, EventArgs e)
        {
            if (_currentTask != null)
            {
                _currentTask.Description = txtDescription.Text;
                DataManager.UpdateTask(_currentTask);
                OnTaskUpdated?.Invoke();
                MessageBox.Show("Description saved!");
            }
        }

        // Pøiøadí aktuální úkol pøihlášenému uživateli.
        // Aktualizuje stavy tlaèítek a vyvolá událost OnTaskUpdated.
        private void btnAssignToMe_Click(object sender, EventArgs e)
        {
            if (_currentUser != null && _currentTask != null)
            {
                DataManager.AssignTaskToUser(_currentUser.Id, _currentTask.Id);
                MessageBox.Show("Task assigned to you!");
                UpdateAssignmentButtons();
                OnTaskUpdated?.Invoke();
            }
        }

        // Odstraní pøiøazení aktuálního úkolu od pøihlášeného uživatele.
        // Aktualizuje stavy tlaèítek a vyvolá událost OnTaskUpdated.
        private void btnLeave_Click(object sender, EventArgs e)
        {
            if (_currentUser != null && _currentTask != null)
            {
                DataManager.UnassignTaskFromUser(_currentUser.Id, _currentTask.Id);
                MessageBox.Show("You have left the task!");
                UpdateAssignmentButtons();
                OnTaskUpdated?.Invoke();
            }
        }

        // Obslužný program pro kliknutí na tlaèítko "Zpìt".
        // Vyvolá gebeurtenost OnBack pro návrat na pøedchozí obrazovku.
        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke();
        }
    }
}
