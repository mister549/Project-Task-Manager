namespace Task_manager
{
    partial class ProjectCard
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
            lblProjectName = new Label();
            SuspendLayout();
            // 
            // lblProjectName
            // 
            lblProjectName.AutoSize = true;
            lblProjectName.Location = new Point(100, 30);
            lblProjectName.Name = "lblProjectName";
            lblProjectName.Size = new Size(50, 20);
            lblProjectName.TabIndex = 0;
            lblProjectName.Text = "label1";
            // 
            // ProjectCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblProjectName);
            Cursor = Cursors.Default;
            Name = "ProjectCard";
            Size = new Size(250, 130);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProjectName;
    }
}
