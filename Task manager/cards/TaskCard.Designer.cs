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
            Label = new Label();
            lblTaskStatus = new Label();
            SuspendLayout();
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblTaskTitle.Location = new Point(10, 15);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(65, 22);
            lblTaskTitle.TabIndex = 0;
            lblTaskTitle.Text = "label1";
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new Font("Arial", 9F);
            Label.Location = new Point(10, 49);
            Label.Name = "Label";
            Label.Size = new Size(54, 17);
            Label.TabIndex = 1;
            Label.Text = "Status:";
            // 
            // lblTaskStatus
            // 
            lblTaskStatus.AutoSize = true;
            lblTaskStatus.Location = new Point(70, 46);
            lblTaskStatus.Name = "lblTaskStatus";
            lblTaskStatus.Size = new Size(50, 20);
            lblTaskStatus.TabIndex = 2;
            lblTaskStatus.Text = "label1";
            // 
            // TaskCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTaskStatus);
            Controls.Add(lblTaskTitle);
            Controls.Add(Label);
            Name = "TaskCard";
            Size = new Size(250, 130);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaskTitle;
        private Label Label;
        private Label lblTaskStatus;
    }
}
