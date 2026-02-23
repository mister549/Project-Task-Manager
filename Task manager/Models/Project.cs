using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Task_manager.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}