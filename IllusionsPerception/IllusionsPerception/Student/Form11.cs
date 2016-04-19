using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form11 : Form
    {
        readonly List<PictureModel> _list = new List<PictureModel>
            {
                new PictureModel {Patch = "~/../Resources/левая.jpg", Answer = "Левая"},
                new PictureModel {Patch = "~/../Resources/правая.jpg", Answer = "Правая"},
                new PictureModel {Patch = "~/../Resources/равны.jpg", Answer = "Равны"}
            };

        private int _number = 1;
        private readonly int _number1 = 0;
        private string _rightAnswer = "";
        private string _testeeAnswer = "";
        private int _confidence = 0;
        private bool _continue = false;
        private int _id = 0;
        public Form11()
        {
            InitializeComponent();
            var context = new IllusionsPerceptionContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений2").Value);

            label5.Text = _number1.ToString();
        }

        public Form11(int number, int id)
        {
            var context = new IllusionsPerceptionContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений2").Value);

            label5.Text = _number1.ToString();
            _number = number;
            _continue = true;
            _id = id;
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
            button1.Visible = false;
        }

        private void WorkWithForm(int number)
        {
            if (number <= _number1)
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
            var random = new Random();
            var k = random.Next(1, _list.Count + 1);

            pictureBox1.ImageLocation = _list[k - 1].Patch;
            _rightAnswer = _list[k - 1].Answer;
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
            _testeeAnswer = "Левая";
            HideAnswerButton();
            ShowRadioButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _testeeAnswer = "Равны";
            HideAnswerButton();
            ShowRadioButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _testeeAnswer = "Правая";
            HideAnswerButton();
            ShowRadioButton();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            _confidence = 1;
            WriteToDb();
            _number++;
            HideRadioButton();
            WorkWithForm(_number);
            radioButton1.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            _confidence = 2;
            WriteToDb();
            _number++;
            HideRadioButton();
            WorkWithForm(_number);
            radioButton2.Checked = false;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            _confidence = 3;
            WriteToDb();
            _number++;
            HideRadioButton();
            WorkWithForm(_number);
            radioButton3.Checked = false;
        }

        private void WriteToDb()
        {
            var context = new IllusionsPerceptionContext();

            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;

            context.Experiment2Result.Add(new Experiment2Result
            {
                Id_User = id,
                TesteeResponse = _testeeAnswer,
                CorrectAnswer = _rightAnswer,
                Confidence = _confidence,
                NumberDisplay = _number,
                AllNumberDisplay = _number1
            });
            //context.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_continue)
            {
                var nForm = new Form17(_id);
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
            else
            {
                var nForm = new Form12();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }
    }
}
