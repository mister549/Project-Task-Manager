using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using Task_manager.Models;

namespace Task_manager
{

    public partial class LoginUC : UserControl
    {
        // Событие, которое оповестит главную форму об успешном входе
        public event Action<User> LoginSuccessful;

        public LoginUC()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string jsonPath = "users.json";

            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Файл данных не найден!");
                return;
            }

            var jsonData = File.ReadAllText(jsonPath);
            var users = JsonSerializer.Deserialize<List<User>>(jsonData);

            // Ищем пользователя
            var user = users.FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);

            if (user != null)
            {
                // Вызываем событие и передаем объект пользователя
                LoginSuccessful?.Invoke(user);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
