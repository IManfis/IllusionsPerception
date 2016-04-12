using System;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            var context = new IllusionsPerceptionContext();
            InitializeComponent();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;

            if (context.Experiment1Result.Any(x => x.Id_User == id))
            {
                button3.Enabled = true;
            }
            if (context.Experiment2Result.Any(x => x.Id_User == id))
            {
                button5.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form5();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form7();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var nForm = new Form8();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form9();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
