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
    public partial class MainMenuControl : UserControl
    {
        private User _currentUser;

        // Konstruktor, který inicializuje komponentu a nastavuje údaje uživatele.
        // Ověřuje roli uživatele a podle toho povoluje nebo zakazuje tlačítko "Vytvořit".
        public MainMenuControl(User user) : this()
        {
            _currentUser = user;
            lblUserGreeting.Text = $"👤 {user.Username}\nLogged In";
            
            // Проверяем роль пользователя для кнопки Create
            btnCreateGlobal.Enabled = user.Role?.Equals("Administrator", StringComparison.OrdinalIgnoreCase) ?? false;
            if (!btnCreateGlobal.Enabled)
            {
                btnCreateGlobal.Text = "Create\n(Admin Only)";
                btnCreateGlobal.BackColor = SystemColors.Control;
                btnCreateGlobal.ForeColor = SystemColors.GrayText;
            }
        }

        // Výchozí konstruktor, který inicializuje komponenty formuláře.
        public MainMenuControl()
        {
            InitializeComponent();
        }

        // Tento metod se spustí při kliknutí na tlačítko "Vytvořit globální".
        // Nejprve zkontroluje, zda je tlačítko povoleno (pouze pro administrátory).
        // Pokud není povoleno, zobrazí varovnou zprávu o odmítnutí přístupu.
        // Pokud je povoleno, vymaže obsah panelu a načte formulář CreateGlobalUC.
        private void btnCreateGlobal_Click(object sender, EventArgs e)
        {
            if (!btnCreateGlobal.Enabled)
            {
                MessageBox.Show("Only administrators can create projects and tasks.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlContent.Controls.Clear();
            CreateGlobalUC createUC = new CreateGlobalUC();
            createUC.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(createUC);
        }

        // Tento metod se spustí při kliknutí na tlačítko "Projekty".
        // Vymaže obsah panelu a načte seznam projektů pro aktuálního uživatele.
        // Poté zavolá metod LoadProjects() k načtení dat projektů.
        private void btnProjects_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            ProjectListControl projectsView = new ProjectListControl(_currentUser, pnlContent);
            projectsView.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(projectsView);

            projectsView.LoadProjects();
        }

        // Tento metod se spustí při kliknutí na tlačítko "Menu".
        // Vymaže obsah panelu a vrátí aplikaci do výchozího stavu.
        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
        }

        // Tento metod se spustí při kliknutí na tlačítko "Moje Úkoly".
        // Vymaže obsah panelu a načte seznam úkolů přiřazených aktuálnímu uživateli.
        // Poté zavolá metod LoadMyTasks() k načtení dat úkolů.
        private void btnMyTask_Click(object sender, EventArgs e)
        {
            MyTask TaskView = new MyTask(_currentUser);
            TaskView.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(TaskView);

            TaskView.LoadMyTasks();
        }
    }
}
