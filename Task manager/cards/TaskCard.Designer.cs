namespace Task_manager
{
    partial class Control
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
            TogoTask = new Button();
            SuspendLayout();
            // 
            // TogoTask
            // 
            TogoTask.Location = new Point(19, 18);
            TogoTask.Name = "TogoTask";
            TogoTask.Size = new Size(210, 122);
            TogoTask.TabIndex = 1;
            TogoTask.Text = "Project";
            TogoTask.TextAlign = ContentAlignment.TopCenter;
            TogoTask.UseVisualStyleBackColor = true;
            // 
            // Control
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TogoTask);
            Name = "Control";
            Size = new Size(562, 361);
            ResumeLayout(false);
        }

        #endregion

        private Button TogoTask;
    }
}
