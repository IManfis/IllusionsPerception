using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form10 : Form
    {
        List<PictureModel> list = new List<PictureModel>
            {
                new PictureModel {Patch = "~/../Resources/1,2левый.jpg", Answer = "Левая"},
                new PictureModel {Patch = "~/../Resources/1,2правый.jpg", Answer = "Правая"},
            };

        private int _number = 1;
        public Form10()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form6();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            WorkWithForm(_number);
        }

        private void WorkWithForm(int number)
        {
            var context = new IllusionsPerceptionContext();
            var exposure = int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Экспозиция").Value);
            var delay = int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Задержка").Value);

            Thread.Sleep(delay);
            GetPicture();
            pictureBox1.Update();
            Thread.Sleep(exposure);
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            ShowAnswerButton();
        }

        private void GetPicture()
        {
            var random = new Random();
            var k = random.Next(1,list.Count + 1);

            pictureBox1.ImageLocation = list[k - 1].Patch;
            pictureBox1.Load();
        }

        private void ShowAnswerButton()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void HideAnswerButton()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void ShowRadioButton()
        {
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
        }

        private void HideRadioButton()
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideAnswerButton();
            ShowRadioButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HideAnswerButton();
            ShowRadioButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HideAnswerButton();
            ShowRadioButton();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            _number++;
            HideRadioButton();
            WorkWithForm(_number);
            radioButton1.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            _number++;
            HideRadioButton();
            WorkWithForm(_number);
            radioButton2.Checked = false;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            _number++;
            HideRadioButton();
            WorkWithForm(_number);
            radioButton3.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var context = new IllusionsPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;

            if (context.Experiment2Result.Any(x => x.Id_User == id))
            {
                label3.Visible = true;
            }
            else
            {
                var nForm = new Form11();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }

    }
}
