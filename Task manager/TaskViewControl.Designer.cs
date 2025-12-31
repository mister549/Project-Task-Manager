namespace Task_manager
{
    partial class TaskViewControl
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
            chkIsCompleted = new CheckBox();
            SuspendLayout();
            // 
            // chkIsCompleted
            // 
            chkIsCompleted.AutoSize = true;
            chkIsCompleted.Location = new Point(0, 0);
            chkIsCompleted.Name = "chkIsCompleted";
            chkIsCompleted.Size = new Size(101, 24);
            chkIsCompleted.TabIndex = 0;
            chkIsCompleted.Text = "checkBox1";
            chkIsCompleted.UseVisualStyleBackColor = true;
            // 
            // TaskViewControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(chkIsCompleted);
            Name = "TaskViewControl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkIsCompleted;
    }
}
