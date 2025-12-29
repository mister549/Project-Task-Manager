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
            btnMenu = new Button();
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
            pnlSidebar.Controls.Add(btnMenu);
            pnlSidebar.Controls.Add(btnCreateGlobal);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 768);
            pnlSidebar.TabIndex = 2;
            // 
            // lblUserGreeting
            // 
            lblUserGreeting.AutoSize = true;
            lblUserGreeting.Location = new Point(45, 46);
            lblUserGreeting.Name = "lblUserGreeting";
            lblUserGreeting.Size = new Size(50, 20);
            lblUserGreeting.TabIndex = 4;
            lblUserGreeting.Text = "label1";
            // 
            // btnProjects
            // 
            btnProjects.Location = new Point(45, 413);
            btnProjects.Name = "btnProjects";
            btnProjects.Size = new Size(169, 70);
            btnProjects.TabIndex = 3;
            btnProjects.Text = "Projects";
            btnProjects.UseVisualStyleBackColor = true;
            btnProjects.Click += btnProjects_Click;
            // 
            // btnMyTask
            // 
            btnMyTask.Location = new Point(45, 330);
            btnMyTask.Name = "btnMyTask";
            btnMyTask.Size = new Size(169, 65);
            btnMyTask.TabIndex = 2;
            btnMyTask.Text = "My Task";
            btnMyTask.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            btnMenu.Location = new Point(45, 232);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(169, 69);
            btnMenu.TabIndex = 1;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
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
            pnlSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnProjects;
        private Button btnMyTask;
        private Button btnMenu;
        private Button btnCreateGlobal;
        private Panel pnlContent;
        private Label lblUserGreeting;
    }
}
