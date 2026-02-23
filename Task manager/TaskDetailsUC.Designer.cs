namespace Task_manager
{
    partial class TaskDetailsUC
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnBack = new Button();
            lblHeader = new Label();
            lblTitle = new Label();
            lblDescLabel = new Label();
            txtDescription = new TextBox();
            btnSaveDesc = new Button();
            taskStepsUC = new TaskStepsUC();
            contentPanel = new Panel();
            buttonPanel = new Panel();
            btnAssignToMe = new Button();
            btnLeave = new Button();
            contentPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(10, 10);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 40);
            btnBack.TabIndex = 0;
            btnBack.Text = "<- Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(btnBack);
            contentPanel.Controls.Add(lblHeader);
            contentPanel.Controls.Add(lblTitle);
            contentPanel.Controls.Add(lblDescLabel);
            contentPanel.Controls.Add(txtDescription);
            contentPanel.Controls.Add(btnSaveDesc);
            contentPanel.Controls.Add(taskStepsUC);
            contentPanel.Location = new Point(0, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(800, 520);
            contentPanel.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lblHeader.ForeColor = SystemColors.GrayText;
            lblHeader.Location = new Point(10, 60);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(97, 21);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Task Details:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.Location = new Point(10, 85);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 0, 0, 15);
            lblTitle.Size = new Size(0, 45);
            lblTitle.TabIndex = 1;
            // 
            // lblDescLabel
            // 
            lblDescLabel.AutoSize = true;
            lblDescLabel.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblDescLabel.Location = new Point(10, 145);
            lblDescLabel.Name = "lblDescLabel";
            lblDescLabel.Padding = new Padding(0, 5, 0, 0);
            lblDescLabel.Size = new Size(124, 27);
            lblDescLabel.TabIndex = 2;
            lblDescLabel.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(10, 175);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(750, 80);
            txtDescription.TabIndex = 3;
            // 
            // btnSaveDesc
            // 
            btnSaveDesc.BackColor = SystemColors.Control;
            btnSaveDesc.Location = new Point(10, 265);
            btnSaveDesc.Name = "btnSaveDesc";
            btnSaveDesc.Size = new Size(100, 35);
            btnSaveDesc.TabIndex = 4;
            btnSaveDesc.Text = "💾 Save";
            btnSaveDesc.UseVisualStyleBackColor = true;
            btnSaveDesc.Click += btnSaveDesc_Click;
            // 
            // taskStepsUC
            // 
            taskStepsUC.Location = new Point(10, 315);
            taskStepsUC.Name = "taskStepsUC";
            taskStepsUC.Size = new Size(750, 200);
            taskStepsUC.TabIndex = 5;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(btnAssignToMe);
            buttonPanel.Controls.Add(btnLeave);
            buttonPanel.Location = new Point(0, 520);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(800, 70);
            buttonPanel.TabIndex = 6;
            // 
            // btnAssignToMe
            // 
            btnAssignToMe.BackColor = Color.Green;
            btnAssignToMe.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnAssignToMe.ForeColor = Color.White;
            btnAssignToMe.Location = new Point(429, 15);
            btnAssignToMe.Name = "btnAssignToMe";
            btnAssignToMe.Size = new Size(150, 40);
            btnAssignToMe.TabIndex = 7;
            btnAssignToMe.Text = "✓ Assign to me";
            btnAssignToMe.UseVisualStyleBackColor = false;
            btnAssignToMe.Click += btnAssignToMe_Click;
            // 
            // btnLeave
            // 
            btnLeave.BackColor = Color.Red;
            btnLeave.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnLeave.ForeColor = Color.White;
            btnLeave.Location = new Point(585, 15);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(150, 40);
            btnLeave.TabIndex = 8;
            btnLeave.Text = "✕ Leave";
            btnLeave.UseVisualStyleBackColor = false;
            btnLeave.Click += btnLeave_Click;
            // 
            // TaskDetailsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonPanel);
            Controls.Add(contentPanel);
            Name = "TaskDetailsUC";
            Size = new Size(800, 590);
            contentPanel.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Button btnBack;
        private Label lblHeader;
        private Label lblTitle;
        private Label lblDescLabel;
        private TextBox txtDescription;
        private Button btnSaveDesc;
        private TaskStepsUC taskStepsUC;
        private Panel contentPanel;
        private Panel buttonPanel;
        private Button btnAssignToMe;
        private Button btnLeave;
    }
}
