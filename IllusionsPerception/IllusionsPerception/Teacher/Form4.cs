using System;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Teacher
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form2();
            nForm.FormClosed += (o, ep) => Close();
            nForm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var context = new IllusionsPerceptionContext();
            var user = context.User;

            var name = textBox1.Text;
            var password = textBox2.Text;

            var admin = user.FirstOrDefault(x => x.Name == name);

            if (admin == null)
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (admin.Password == password && admin.Group == 0)
            {
                var nForm = new Form13();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
            else
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
