using System;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form6 : Form
    {
        private int _id = 0;
        public Form6()
        {
            InitializeComponent();
            var context = new IllusionsPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            _id = id;

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
            var context = new IllusionsPerceptionContext();

            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;

            if (context.Experiment1Result.Any(x => x.Id_User == id))
            {
                label3.Visible = true;
            }
            else
            {
                var nForm = new Form8();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();   
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form9(_id);
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var nForm = new Form10();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var context = new IllusionsPerceptionContext();

            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;

            if (context.Experiment2Result.Any(x => x.Id_User == id))
            {
                label4.Visible = true;
            }
            else
            {
                var nForm = new Form11();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form12(_id);
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
