using System.Windows.Forms;

namespace Task_manager
{
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
            Control myScreen = new Control();

            ContentPanel.Controls.Add(myScreen);
        }

        
    }
}
