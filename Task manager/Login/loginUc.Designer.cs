namespace Task_manager
{
    partial class LoginUC
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1024, 768);
            panel1.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(41, 128, 185);
            lblTitle.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(62, 74);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(908, 126);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Project Task Manager";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.BackColor = Color.FromArgb(41, 128, 185);
            lblSubtitle.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblSubtitle.ForeColor = Color.FromArgb(200, 220, 240);
            lblSubtitle.Location = new Point(200, 200);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(624, 50);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Organize your work efficiently";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(41, 128, 185);
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(250, 310);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(52, 152, 219);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(250, 350);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Enter your username";
            txtUsername.Size = new Size(524, 39);
            txtUsername.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(41, 128, 185);
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.ForeColor = Color.White;
            label2.Location = new Point(250, 420);
            label2.Name = "label2";
            label2.Size = new Size(116, 32);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(52, 152, 219);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(250, 460);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(524, 39);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 204, 113);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(350, 560);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(324, 60);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 128, 185);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(lblSubtitle);
            Controls.Add(panel1);
            Name = "LoginUC";
            Size = new Size(1024, 768);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}
