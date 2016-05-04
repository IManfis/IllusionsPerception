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

        private void button4_Click(object sender, EventArgs e)
        {
            var number = comboBox1.SelectedItem.ToString();
            var context = new IllusionsPerceptionContext();
            var model = new Settings() { Id = 1, Name = "Предъявлений1", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            WriteInformation();
        }

        private void WriteInformation()
        {
            var context = new IllusionsPerceptionContext();
            label12.Text = context.Settings.First(x => x.Name == "Предъявлений1").Value;
            label13.Text = context.Settings.First(x => x.Name == "Предварительная").Value;
            label16.Text = context.Settings.First(x => x.Name == "Контрольная").Value;
            label14.Text = context.Settings.First(x => x.Name == "Экспозиция").Value + " мс.";
            label18.Text = context.Settings.First(x => x.Name == "Задержка").Value + " мс.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var number = comboBox2.SelectedItem.ToString();
            var context = new IllusionsPerceptionContext();
            var model = new Settings() { Id = 2, Name = "Предварительная", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            WriteInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var number = comboBox4.SelectedItem.ToString();
            var context = new IllusionsPerceptionContext();
            var model = new Settings() { Id = 4, Name = "Экспозиция", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            WriteInformation();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var number = comboBox5.SelectedItem.ToString();
            var context = new IllusionsPerceptionContext();
            var model = new Settings() { Id = 5, Name = "Задержка", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            WriteInformation();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var number = comboBox3.SelectedItem.ToString();
            var context = new IllusionsPerceptionContext();
            var model = new Settings() { Id = 3, Name = "Контрольная", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            WriteInformation();
        }
    }
}