using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Task_manager.Models
{
    // Это просто "контейнер" для текста. Здесь НЕТ кнопок и панелей.
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Список задач, привязанных к этому проекту
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}