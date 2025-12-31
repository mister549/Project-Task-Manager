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
    public partial class TaskViewControl : UserControl
    {
        public TaskViewControl()
        {
            InitializeComponent();
        }
        // Внутри твоего TaskCard или TaskViewControl
        private TaskItem _task;

        public void SetTaskData(TaskItem task)
        {
            _task = task;

            // 1. Отписываемся от события, чтобы установка значения не вызывала сохранение в файл
            chkIsCompleted.CheckedChanged -= ChkIsCompleted_CheckedChanged;

            // 2. Устанавливаем текущее состояние из модели
            chkIsCompleted.Checked = _task.IsCompleted;

            // 3. Подписываемся обратно
            chkIsCompleted.CheckedChanged += ChkIsCompleted_CheckedChanged; 
        }

        private void ChkIsCompleted_CheckedChanged(object sender, EventArgs e)
        {
            // 4. Как только пользователь нажал на чекбокс, обновляем данные в объекте
            _task.IsCompleted = chkIsCompleted.Checked;

            // 5. СОХРАНЕНИЕ. Поскольку объект _task — это часть списка в памяти, 
            // нам нужно просто пересохранить весь список проектов в JSON.
            var allProjects = DataManager.GetAllProjects();

            // Ищем в списке тот проект, которому принадлежит эта задача, и обновляем его
            // (Если ты работаешь с объектами правильно, они обновятся в списке автоматически, 
            // так как это ссылочный тип данных)

            DataManager.SaveAllData(allProjects);
        }
        private void chkIsCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsCompleted.Checked)
            {
                // Переносим в другой JSON
                DataManager.MoveToCompleted(_task);

                // Сразу убираем карточку с экрана, так как она больше не "активна"
                this.Parent.Controls.Remove(this);

                MessageBox.Show("Задача выполнена и перенесена в архив!");
            }
        }
    }
}
