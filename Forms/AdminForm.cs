using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMeister
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            AddQuestionForm addQuestionForm = new AddQuestionForm();
            addQuestionForm.Show();
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            EditQuestionForm editQuestionForm = new EditQuestionForm();
            editQuestionForm.Show();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            DeleteQuestionForm deleteQuestionForm = new DeleteQuestionForm();
            deleteQuestionForm.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsersForm manageUsersForm = new ManageUsersForm();
            manageUsersForm.Show();
        }
    }
}
