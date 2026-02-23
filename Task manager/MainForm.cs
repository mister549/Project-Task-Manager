using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Task_manager.Models;

namespace Task_manager
{
    public partial class MainForm : Form
    {
        // Konstruktor hlavního formuláře, který inicializuje komponentu a zobrazuje přihlašovací obrazovku.
        public MainForm()
        {
            InitializeComponent();
            ShowLogin();       
        }

        // Vytváří a zobrazuje přihlašovací formulář v centru okna pomocí TableLayoutPanel.
        // Po úspěšném přihlášení uživatele se spustí metod OpenUserWindow().
        private void ShowLogin()
        {
            this.Controls.Clear();

     
            TableLayoutPanel table = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 3 };

    
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            LoginUC login = new LoginUC();
            login.LoginSuccessful += (user) => OpenUserWindow(user);

            table.Controls.Add(login, 1, 1); 
            this.Controls.Add(table);
        }

        // Odstraní přihlašovací formulář a zobrazí hlavní nabídku aplikace s údaji přihlášeného uživatele.
        private void OpenUserWindow(User user)
        {
            this.Controls.Clear(); 

            
            MainMenuControl menu = new MainMenuControl(user);
            menu.Dock = DockStyle.Fill;

            this.Controls.Add(menu); 
        }
    }
}
