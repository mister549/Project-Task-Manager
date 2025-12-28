namespace Task_manager
{
    partial class AddProjectForm : Form
    {
        private void InitializeComponent()
        {
            txtProjectName = new TextBox();
            saveButton = new Button();
            SuspendLayout();
            // 
            // txtProjectName
            // 
            txtProjectName.Location = new Point(33, 29);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(208, 27);
            txtProjectName.TabIndex = 0;
            // 
            // saveButton
            // 
            saveButton.DialogResult = DialogResult.OK;
            saveButton.Location = new Point(93, 62);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 1;
            saveButton.Text = "save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // AddProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 103);
            Controls.Add(saveButton);
            Controls.Add(txtProjectName);
            Name = "AddProjectForm";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

     

        private TextBox txtProjectName;
        private Button saveButton;
    }
}