using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form10 : Form
    {
        List<PictureModel> list = new List<PictureModel>
            {
                new PictureModel {Patch = "~/../Resources/левая.jpg", Answer = "Левая"},
                new PictureModel {Patch = "~/../Resources/правая.jpg", Answer = "Правая"},
                new PictureModel {Patch = "~/../Resources/равны.jpg", Answer = "Равны"}
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
            WorkWithForm(_number);
        }

        private void WorkWithForm(int number)
        {
            if (number <= 5)
            {
                label3.Text = number.ToString();
                GetPicture();
                pictureBox1.Update();
                Thread.Sleep(200);
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
                ShowAnswerButton();
            }
            else
            {
                button6.Visible = true;
            }    
        }

        private void GetPicture()
        {
            Random random = new Random();
            int k;
            k = random.Next(1,list.Count + 1);

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
            var nForm = new Form11();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

    }
}
