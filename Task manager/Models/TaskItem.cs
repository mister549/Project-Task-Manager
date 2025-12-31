namespace Task_manager.Models
{
    public class TaskItem
    {
        // Название задачи
        public string Title { get; set; }

        // Имя проекта, к которому привязана задача
        public string ProjectName { get; set; }

        // Можно добавить дополнительные поля
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
