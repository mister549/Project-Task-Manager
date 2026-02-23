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
        public event Action<User> LoginSuccessful;

        public LoginUC()
        {
            InitializeComponent();
        }
        // Tento metod se spustí při kliknutí na tlačítko přihlášení.
        // Ověří údaje uživatele tím, že je porovná se souborem users.json.
        // Pokud je uživatel nalezen, vyvolá událost LoginSuccessful s příslušným uživatelem.
        // V opačném případě zobrazí chybovou zprávu.
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string jsonPath = "users.json";

            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("User data file not found!");
                return;
            }

            var jsonData = File.ReadAllText(jsonPath);
            var users = JsonSerializer.Deserialize<List<User>>(jsonData);

            var user = users.FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);

            if (user != null)
            {
                LoginSuccessful?.Invoke(user);
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
