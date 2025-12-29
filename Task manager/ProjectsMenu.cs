using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_manager
{
    public partial class ProjectListControl : UserControl
    {
        public ProjectListControl()
        {
            InitializeComponent();
        }

        public void LoadProjects()
        {
            // 1. Очищаем панель, чтобы при обновлении проекты не дублировались визуально
            flpProjects.Controls.Clear();

            // 2. Получаем актуальный список проектов из нашего DataManager
            var projects = DataManager.GetAllProjects();

            // 3. Бежим циклом по списку и создаем карточки
            foreach (var project in projects)
            {
                // Создаем экземпляр твоей карточки
                ProjectCard card = new ProjectCard();

                // Передаем название проекта внутрь карточки
                card.SetProjectData(project.Name);

                // Можно задать отступы, чтобы карточки не прилипали друг к другу
                card.Margin = new System.Windows.Forms.Padding(10);

                // Добавляем готовую карточку в FlowLayoutPanel
                flpProjects.Controls.Add(card);
            }
        }
    }
}
