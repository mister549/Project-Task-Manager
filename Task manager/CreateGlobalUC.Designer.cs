namespace Task_manager
{
    partial class CreateGlobalUC
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
            txtProjectName = new TextBox();
            btnCreateProject = new Button();
            label2 = new Label();
            txtTaskName = new TextBox();
            lbProjectSelector = new ListBox();
            btnCreateTask = new Button();
            label3 = new Label();
            txtStepInput = new TextBox();
            btnAddStepToList = new Button();
            lbStepsPreview = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(27, 23);
            label1.Name = "label1";
            label1.Size = new Size(81, 28);
            label1.TabIndex = 0;
            label1.Text = "Projects";
            // 
            // txtProjectName
            // 
            txtProjectName.Location = new Point(27, 71);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(209, 27);
            txtProjectName.TabIndex = 1;
            // 
            // btnCreateProject
            // 
            btnCreateProject.Location = new Point(142, 104);
            btnCreateProject.Name = "btnCreateProject";
            btnCreateProject.Size = new Size(94, 29);
            btnCreateProject.TabIndex = 2;
            btnCreateProject.Text = "Create Project";
            btnCreateProject.UseVisualStyleBackColor = true;
            btnCreateProject.Click += btnCreateProject_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(27, 170);
            label2.Name = "label2";
            label2.Size = new Size(56, 28);
            label2.TabIndex = 3;
            label2.Text = "Tasks";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(27, 214);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(209, 27);
            txtTaskName.TabIndex = 4;
            // 
            // lbProjectSelector
            // 
            lbProjectSelector.FormattingEnabled = true;
            lbProjectSelector.Location = new Point(321, 214);
            lbProjectSelector.Name = "lbProjectSelector";
            lbProjectSelector.Size = new Size(150, 104);
            lbProjectSelector.TabIndex = 5;
            // 
            // btnCreateTask
            // 
            btnCreateTask.Location = new Point(142, 247);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.Size = new Size(94, 29);
            btnCreateTask.TabIndex = 6;
            btnCreateTask.Text = "Create Task";
            btnCreateTask.UseVisualStyleBackColor = true;
            btnCreateTask.Click += btnCreateTask_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(33, 298);
            label3.Name = "label3";
            label3.Size = new Size(129, 28);
            label3.TabIndex = 7;
            label3.Text = "Steps for task";
            // 
            // txtStepInput
            // 
            txtStepInput.Location = new Point(27, 348);
            txtStepInput.Name = "txtStepInput";
            txtStepInput.Size = new Size(209, 27);
            txtStepInput.TabIndex = 8;
            // 
            // btnAddStepToList
            // 
            btnAddStepToList.Location = new Point(142, 381);
            btnAddStepToList.Name = "btnAddStepToList";
            btnAddStepToList.Size = new Size(94, 29);
            btnAddStepToList.TabIndex = 9;
            btnAddStepToList.Text = "Add Step";
            btnAddStepToList.UseVisualStyleBackColor = true;
            // 
            // lbStepsPreview
            // 
            lbStepsPreview.FormattingEnabled = true;
            lbStepsPreview.Location = new Point(321, 348);
            lbStepsPreview.Name = "lbStepsPreview";
            lbStepsPreview.Size = new Size(150, 104);
            lbStepsPreview.TabIndex = 10;
            // 
            // CreateGlobalUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbStepsPreview);
            Controls.Add(btnAddStepToList);
            Controls.Add(txtStepInput);
            Controls.Add(label3);
            Controls.Add(btnCreateTask);
            Controls.Add(lbProjectSelector);
            Controls.Add(txtTaskName);
            Controls.Add(label2);
            Controls.Add(btnCreateProject);
            Controls.Add(txtProjectName);
            Controls.Add(label1);
            Name = "CreateGlobalUC";
            Size = new Size(530, 540);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProjectName;
        private Button btnCreateProject;
        private Label label2;
        private TextBox txtTaskName;
        private ListBox lbProjectSelector;
        private Button btnCreateTask;
        private Label label3;
        private TextBox txtStepInput;
        private Button btnAddStepToList;
        private ListBox lbStepsPreview;
    }
}
