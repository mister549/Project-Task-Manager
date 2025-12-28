namespace Task_manager
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnCreateGlobal = new Button();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = SystemColors.ActiveCaption;
            pnlSidebar.Controls.Add(btnCreateGlobal);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 721);
            pnlSidebar.TabIndex = 1;
            // 
            // btnCreateGlobal
            // 
            btnCreateGlobal.Location = new Point(43, 144);
            btnCreateGlobal.Name = "btnCreateGlobal";
            btnCreateGlobal.Size = new Size(171, 64);
            btnCreateGlobal.TabIndex = 0;
            btnCreateGlobal.Text = "Create project";
            btnCreateGlobal.UseVisualStyleBackColor = true;
            btnCreateGlobal.Click += btnCreateGlobal_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(250, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(756, 721);
            pnlContent.TabIndex = 2;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "MainMenu";
            StartPosition = FormStartPosition.Manual;
            Text = "Project";
            WindowState = FormWindowState.Maximized;
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlContent;
        private Button btnCreateGlobal;
    }
}
