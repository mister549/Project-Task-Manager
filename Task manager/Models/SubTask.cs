using System;
using System.Collections.Generic;
using System.Text;

namespace Task_manager.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public int ParentTaskId { get; set; } // Ссылка на основную задачу
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
