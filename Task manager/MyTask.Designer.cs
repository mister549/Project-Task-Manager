namespace Task_manager
{
    partial class MyTask
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            flpMyTask = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10);
            label1.Size = new Size(973, 70);
            label1.TabIndex = 0;
            label1.Text = "My Tasks";
            // 
            // flpMyTask
            // 
            flpMyTask.Dock = DockStyle.Fill;
            flpMyTask.FlowDirection = FlowDirection.LeftToRight;
            flpMyTask.Name = "flpMyTask";
            flpMyTask.TabIndex = 1;
            flpMyTask.AutoScroll = true;
            // 
            // MyTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpMyTask);
            Controls.Add(label1);
            Name = "MyTask";
            Size = new Size(973, 414);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private FlowLayoutPanel flpMyTask;
    }
}
