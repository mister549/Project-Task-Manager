namespace Task_manager
{
    partial class ProjectTasksUC
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
            pnlHeader = new Panel();
            lblTasksHeader = new Label();
            pnlTasksContainer = new Panel();
            flpTasks = new FlowLayoutPanel();
            SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlTasksContainer.SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(800, 120);
            pnlHeader.TabIndex = 0;
            pnlHeader.Controls.Add(lblTasksHeader);
            pnlHeader.Controls.Add(btnBack);
            // 
            // btnBack
            // 
            btnBack.Location = new Point(10, 10);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 40);
            btnBack.TabIndex = 0;
            btnBack.Text = "<- Back to projects";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblTasksHeader
            // 
            lblTasksHeader.AutoSize = false;
            lblTasksHeader.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTasksHeader.Location = new Point(10, 50);
            lblTasksHeader.Name = "lblTasksHeader";
            lblTasksHeader.Padding = new Padding(0, 8, 0, 8);
            lblTasksHeader.Size = new Size(780, 60);
            lblTasksHeader.TabIndex = 1;
            lblTasksHeader.Text = "Tasks in Project";
            lblTasksHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTasksContainer
            // 
            pnlTasksContainer.AutoScroll = true;
            pnlTasksContainer.Dock = DockStyle.Fill;
            pnlTasksContainer.Location = new Point(0, 120);
            pnlTasksContainer.Name = "pnlTasksContainer";
            pnlTasksContainer.Size = new Size(800, 445);
            pnlTasksContainer.TabIndex = 2;
            pnlTasksContainer.Controls.Add(flpTasks);
            // 
            // flpTasks
            // 
            flpTasks.AutoSize = true;
            flpTasks.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpTasks.FlowDirection = FlowDirection.LeftToRight;
            flpTasks.Location = new Point(0, 0);
            flpTasks.Name = "flpTasks";
            flpTasks.Size = new Size(0, 0);
            flpTasks.TabIndex = 0;
            flpTasks.WrapContents = true;
            // 
            // ProjectTasksUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlTasksContainer);
            Controls.Add(pnlHeader);
            Name = "ProjectTasksUC";
            Size = new Size(800, 565);
            pnlHeader.ResumeLayout(false);
            pnlTasksContainer.ResumeLayout(false);
            pnlTasksContainer.PerformLayout();
            ResumeLayout(false);
        }

        private Button btnBack;
        private Panel pnlHeader;
        private Label lblTasksHeader;
        private Panel pnlTasksContainer;
        private FlowLayoutPanel flpTasks;
    }
}
