namespace Task_manager
{
    partial class TaskCard
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
            lblTaskTitle = new Label();
            SuspendLayout();
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.Location = new Point(103, 34);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(50, 20);
            lblTaskTitle.TabIndex = 0;
            lblTaskTitle.Text = "label1";
            // 
            // TaskCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTaskTitle);
            Name = "TaskCard";
            Size = new Size(250, 130);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaskTitle;
    }
}
