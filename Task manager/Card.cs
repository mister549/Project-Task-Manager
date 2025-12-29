using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task_manager 
{
    public partial class ProjectCard : UserControl
    {
        public ProjectCard()
        {
            InitializeComponent();

            // Настроим внешний вид программно, чтобы наверняка
            this.BorderStyle = BorderStyle.FixedSingle; // Рамка, чтобы видеть границы
            this.BackColor = Color.White;
    }
        public void SetProjectData(string name)
        {
            lblProjectName.Text = name;
        }
    }
}