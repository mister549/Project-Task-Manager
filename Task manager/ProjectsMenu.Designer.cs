namespace Task_manager
{
    partial class ProjectListControl
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
            label1 = new Label();
            flpProjects = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10);
            label1.Size = new Size(150, 61);
            label1.TabIndex = 2;
            label1.Text = "Projects";
            // 
            // flpProjects
            // 
            flpProjects.AutoScroll = true;
            flpProjects.Dock = DockStyle.Fill;
            flpProjects.Location = new Point(0, 61);
            flpProjects.Name = "flpProjects";
            flpProjects.Size = new Size(560, 299);
            flpProjects.TabIndex = 3;
            // 
            // ProjectListControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpProjects);
            Controls.Add(label1);
            Name = "ProjectListControl";
            Size = new Size(560, 360);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private FlowLayoutPanel flpProjects;
    }
}
