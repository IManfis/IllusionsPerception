using System;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form2();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            var name = textBox1.Text;
            var groupNumber = 0;
            if (textBox2.Text != "")
            {
                groupNumber = int.Parse(textBox2.Text);   
            }

            if (name != "" && groupNumber != 0)
            {
                var context = new IllusionsPerceptionContext();
                context.User.Add(new User { Name = name, Group = groupNumber, Date = DateTime.Now });
                //context.SaveChanges();

                label4.Visible = true;
                button3.Visible = true;   
            }
            else
            {
                label5.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form5();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
