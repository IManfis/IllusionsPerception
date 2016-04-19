using System;
using System.Linq;
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
            var context = new IllusionsPerceptionContext();
            label4.Visible = false;
            label5.Visible = false;
            var name = textBox1.Text;
            var groupNumber = int.Parse(textBox2.Text);
            var user = context.User.ToList();
            var number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений1").Value);
            var number2 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений2").Value);

            if (user.Any(x => x.Name == name &&
                user.Any(m => m.Group == groupNumber)))
            {
                var id = user.First(x => x.Name == name).Id;

                if (context.Experiment1Result.Count(x => x.Id_User == id) == number1 &&
                    context.Experiment2Result.Count(x => x.Id_User == id) == number2)
                {
                    label6.Visible = true;
                }
                else
                {
                    var result = MessageBox.Show("У Вас есть незавершенные опыты, хотите продолжить?", "Незавершенные опыты", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        var nForm = new Form17(id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                context.User.Add(new User { Name = name, Group = groupNumber, Date = DateTime.Now });
                //context.SaveChanges();

                label4.Visible = true;
                button3.Visible = true;  
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
