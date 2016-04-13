using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Teacher
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
            WriteInformation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form13();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var number = int.Parse(textBox2.Text);

            if (number < 5 || number > 30)
            {
                label17.Visible = true;
                textBox2.Text = "";
            }
            else
            {
                var context = new IllusionsPerceptionContext();
                var model = new Settings() {Id = 1, Name = "Предъявлений1", Value = number.ToString()};

                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();

                WriteInformation();
                textBox2.Text = "";
            }
        }

        private void WriteInformation()
        {
            var context = new IllusionsPerceptionContext();
            label12.Text = context.Settings.First(x => x.Name == "Предъявлений1").Value;
            label13.Text = context.Settings.First(x => x.Name == "Предъявлений2").Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var number = int.Parse(textBox1.Text);
            
            if (number < 5 || number > 30)
            {
                label1.Visible = true;
                textBox2.Text = "";
            }
            else
            {
                var context = new IllusionsPerceptionContext();
                var model = new Settings() { Id = 2, Name = "Предъявлений2", Value = number.ToString() };

                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();

                WriteInformation();
                textBox1.Text = "";
            }
        }
    }
}
