using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Task_manager.Models;

namespace Task_manager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ShowLogin();       
        }
        // 1. Метод, который очищает экран и ставит меню
        private void ShowLogin()
        {
            this.Controls.Clear();

            // Сетка 3х3
            TableLayoutPanel table = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 3 };

            // Настройка растяжения сторон (делаем центр)
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            LoginUC login = new LoginUC();
            login.LoginSuccessful += (user) => OpenUserWindow(user);

            table.Controls.Add(login, 1, 1); // Кладем в центр (1,1)
            this.Controls.Add(table);
        }
        private void OpenUserWindow(User user)
        {
            this.Controls.Clear(); // Удаляем LoginUC

            // 2. Создаем Главное Меню и передаем в него юзера
            MainMenuControl menu = new MainMenuControl(user);
            menu.Dock = DockStyle.Fill;

            this.Controls.Add(menu); // Показываем на экране
        }
    }
}
