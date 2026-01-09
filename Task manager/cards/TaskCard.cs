using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Task_manager.Models;

namespace Task_manager
{
    public partial class TaskCard : UserControl
    {
        public TaskCard()
        {
            InitializeComponent();
            this.Paint += TaskCard_Paint;
        }
        public void SetTaskData(TaskItem task)
        {
            lblTaskTitle.Text = task.Title;

            string statusText = task.IsCompleted ? "COMPLETED" : "IN PROGRESS";
            Color statusColor = task.IsCompleted ? Color.Green : Color.OrangeRed;

            lblTaskStatus.Text = statusText;
            lblTaskStatus.ForeColor = statusColor;
        }
        private void TaskCard_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.Black;
            int borderWidth = 2;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen,
                    0,
                    0,
                    this.Width - 1,
                    this.Height - 1);
            }
        }
    }
}
