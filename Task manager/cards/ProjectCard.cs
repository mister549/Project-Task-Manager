using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using Task_manager.Models;

namespace Task_manager 
{
    public partial class ProjectCard : UserControl
    {
        public ProjectCard()
        {
            InitializeComponent(); // БЕЗ ЭТОГО flpProjects ВСЕГДА БУДЕТ NULL
            this.Paint += Card_Paint;
        }
        public Project ProjectData { get; private set; }

        // Событие, которое мы вызовем при клике
        public event Action<Project> OnProjectClicked;

        public void SetProjectData(Project project)
        {
            ProjectData = project;
            lblProjectName.Text = project.Name;

            // Важно: подписываем и саму карту, и Label на клик
            this.Click += Card_Click;
            lblProjectName.Click += Card_Click;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            // Когда кликнули по карточке, уведомляем список и передаем данные проекта
            OnProjectClicked?.Invoke(ProjectData);
        }
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            // Настраиваем цвет и толщину рамки
            Color borderColor = Color.Black;
            int borderWidth = 2;

            // Создаем ручку (Pen) для рисования. Используем 'using', чтобы очистить ресурсы.
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Рисуем прямоугольник по внутреннему краю контрола
                // Вычитаем 1 из ширины и высоты, чтобы правая и нижняя границы не обрезались
                e.Graphics.DrawRectangle(pen,
                    0,
                    0,
                    this.Width - 1,
                    this.Height - 1);
            }
        }
    }
}