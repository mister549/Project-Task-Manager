namespace Task_manager
{
    partial class MainMenuControl
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
            pnlSidebar = new Panel();
            lblUserGreeting = new Label();
            btnProjects = new Button();
            btnMyTask = new Button();
            btnCreateGlobal = new Button();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = SystemColors.ActiveCaption;
            pnlSidebar.Controls.Add(lblUserGreeting);
            pnlSidebar.Controls.Add(btnProjects);
            pnlSidebar.Controls.Add(btnMyTask);
            pnlSidebar.Controls.Add(btnCreateGlobal);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 768);
            pnlSidebar.TabIndex = 2;
            // 
            // lblUserGreeting
            // 
            lblUserGreeting.BackColor = Color.FromArgb(41, 128, 185);
            lblUserGreeting.Dock = DockStyle.Top;
            lblUserGreeting.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserGreeting.ForeColor = Color.White;
            lblUserGreeting.Location = new Point(0, 0);
            lblUserGreeting.Name = "lblUserGreeting";
            lblUserGreeting.Padding = new Padding(15, 20, 15, 20);
            lblUserGreeting.Size = new Size(250, 80);
            lblUserGreeting.TabIndex = 4;
            lblUserGreeting.Text = "User Profile";
            lblUserGreeting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnProjects
            // 
            btnProjects.Location = new Point(43, 303);
            btnProjects.Name = "btnProjects";
            btnProjects.Size = new Size(169, 70);
            btnProjects.TabIndex = 3;
            btnProjects.Text = "Projects";
            btnProjects.UseVisualStyleBackColor = true;
            btnProjects.Click += btnProjects_Click;
            // 
            // btnMyTask
            // 
            btnMyTask.Location = new Point(45, 223);
            btnMyTask.Name = "btnMyTask";
            btnMyTask.Size = new Size(169, 65);
            btnMyTask.TabIndex = 2;
            btnMyTask.Text = "My Task";
            btnMyTask.UseVisualStyleBackColor = true;
            btnMyTask.Click += btnMyTask_Click;
            // 
            // btnCreateGlobal
            // 
            btnCreateGlobal.Location = new Point(43, 144);
            btnCreateGlobal.Name = "btnCreateGlobal";
            btnCreateGlobal.Size = new Size(171, 64);
            btnCreateGlobal.TabIndex = 0;
            btnCreateGlobal.Text = "Create";
            btnCreateGlobal.UseVisualStyleBackColor = true;
            btnCreateGlobal.Click += btnCreateGlobal_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(250, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(774, 768);
            pnlContent.TabIndex = 3;
            // 
            // MainMenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "MainMenuControl";
            Size = new Size(1024, 768);
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnProjects;
        private Button btnMyTask;
        private Button btnCreateGlobal;
        private Panel pnlContent;
        private Label lblUserGreeting;
    }
}
