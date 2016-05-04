using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Teacher
{
    public partial class Form18 : Form
    {
        readonly List<PictureModel> _list = new List<PictureModel>
            {
                new PictureModel { Coefficient = 1.2, Patch = "~/../Resources/1,2левый.jpg", Answer = "Левая"},
                new PictureModel { Coefficient = 1.2, Patch = "~/../Resources/1,2правый.jpg", Answer = "Правая"},
                new PictureModel { Coefficient = 1.4, Patch = "~/../Resources/1,4левый.jpg", Answer = "Левая"},
                new PictureModel { Coefficient = 1.4, Patch = "~/../Resources/1,4правый.jpg", Answer = "Правая"},
                new PictureModel { Coefficient = 1.6, Patch = "~/../Resources/1,6левый.jpg", Answer = "Левая"},
                new PictureModel { Coefficient = 1.6, Patch = "~/../Resources/1,6правый.jpg", Answer = "Правая"},
                new PictureModel { Coefficient = 1.8, Patch = "~/../Resources/1,8левый.jpg", Answer = "Левая"},
                new PictureModel { Coefficient = 1.8, Patch = "~/../Resources/1,8правый.jpg", Answer = "Правая"},
                new PictureModel { Patch = "~/../Resources/равны.jpg", Answer = "Равны"}
            };

        public Form18()
        {
            InitializeComponent();

            var context = new IllusionsPerceptionContext();
            var number = double.Parse(context.Settings.FirstOrDefault(x => x.Name == "Коэфициент").Value);
            OutputOfImage(number);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form13();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var number = comboBox1.SelectedItem.ToString();
            var context = new IllusionsPerceptionContext();
            var model = new Settings() { Id = 6, Name = "Коэфициент", Value = number };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            OutputOfImage(double.Parse(number));
        }

        private void OutputOfImage(double number)
        {
            if (number == 1.2)
            {
                pictureBox1.ImageLocation = _list[0].Patch;
                pictureBox1.Load();
                pictureBox2.ImageLocation = _list[1].Patch;
                pictureBox2.Load();
            }
            if (number == 1.4)
            {
                pictureBox1.ImageLocation = _list[2].Patch;
                pictureBox1.Load();
                pictureBox2.ImageLocation = _list[3].Patch;
                pictureBox2.Load();
            }
            if (number == 1.6)
            {
                pictureBox1.ImageLocation = _list[4].Patch;
                pictureBox1.Load();
                pictureBox2.ImageLocation = _list[5].Patch;
                pictureBox2.Load();
            }
            if (number == 1.8)
            {
                pictureBox1.ImageLocation = _list[6].Patch;
                pictureBox1.Load();
                pictureBox2.ImageLocation = _list[7].Patch;
                pictureBox2.Load();
            }
            label2.Text = number + " левая";
            label3.Text = number + " правая";
        }
    }
}
