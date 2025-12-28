using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task_manager
{
    public partial class AddProjectForm : Form
    {
        public AddProjectForm()
        {
            InitializeComponent();
        }
        public string NewProjectName => txtProjectName.Text;

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = txtProjectName.Text.Trim();

            // Проверка на пустое поле
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a project name!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на дубликаты
            if (DataManager.IsProjectNameExists(name))
            {
                MessageBox.Show($"Project with the name '{name}' already exists! Please choose a different name.",
                                "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Project newProject = new Project { Name = name };
                DataManager.SaveProject(newProject);

                MessageBox.Show($"Project '{name}' has been successfully created!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }  
}
