namespace Task_manager
{
    partial class TaskStepsUC
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
            lblStepsTitle = new Label();
            flpSteps = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblStepsTitle
            // 
            lblStepsTitle.AutoSize = true;
            lblStepsTitle.Dock = DockStyle.Top;
            lblStepsTitle.Font = new Font("Arial", 11F, FontStyle.Bold | FontStyle.Underline);
            lblStepsTitle.Location = new Point(0, 0);
            lblStepsTitle.Name = "lblStepsTitle";
            lblStepsTitle.Padding = new Padding(10, 10, 0, 10);
            lblStepsTitle.Size = new Size(128, 42);
            lblStepsTitle.TabIndex = 0;
            lblStepsTitle.Text = "Task steps:";
            // 
            // flpSteps
            // 
            flpSteps.AutoSize = true;
            flpSteps.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpSteps.Dock = DockStyle.Fill;
            flpSteps.FlowDirection = FlowDirection.TopDown;
            flpSteps.Location = new Point(0, 42);
            flpSteps.Name = "flpSteps";
            flpSteps.Size = new Size(500, 191);
            flpSteps.TabIndex = 1;
            flpSteps.WrapContents = false;
            // 
            // TaskStepsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpSteps);
            Controls.Add(lblStepsTitle);
            Name = "TaskStepsUC";
            Size = new Size(500, 233);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblStepsTitle;
        private FlowLayoutPanel flpSteps;
    }
}
