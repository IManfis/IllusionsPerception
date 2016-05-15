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

        private int _number = 1;
        private readonly int _number1 = 0;
        private string _rightAnswer = "";
        private string _testeeAnswer = "";
        private int _confidence = 0;
        private bool _continue = false;
        private double _coefficient = 0;
        private int _id = 0;
        private int _count1 = 0;
        private int _count2 = 0;
        public Form11()
        {
            InitializeComponent();
            var context = new IllusionsPerceptionContext();
            _count1 = int.Parse(context.Settings.First(x => x.Name == "Предварительная").Value);
            _count2 = int.Parse(context.Settings.First(x => x.Name == "Контрольная").Value);
            _coefficient = double.Parse(context.Settings.FirstOrDefault(x => x.Name == "Коэфициент").Value);

            _number1 = _count1 + _count2;
            label5.Text = _number1.ToString();
        }

        public Form11(int number, int id)
        {
            var context = new IllusionsPerceptionContext();
            _count1 = int.Parse(context.Settings.First(x => x.Name == "Предварительная").Value);
            _count2 = int.Parse(context.Settings.First(x => x.Name == "Контрольная").Value);
            _coefficient = double.Parse(context.Settings.FirstOrDefault(x => x.Name == "Коэфициент").Value);

            _number1 = _count1 + _count2;
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
                label3.Text = _number.ToString();
                var context = new IllusionsPerceptionContext();
                var exposure = int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Экспозиция").Value);
                var delay = int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Задержка").Value);

                Thread.Sleep(delay);
                GetPicture(number);
                pictureBox1.Update();
                Thread.Sleep(exposure);
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
                ShowAnswerButton();
            }
            else
            {
                button6.Visible = true;
            }
        }

        private void GetPicture(int number)
        {
            if (number <= _count1)
            {
                var random = new Random();
                var k = random.Next(1, 3);

                if (_coefficient == 1.2)
                {
                    if (k == 1)
                    {
                        pictureBox1.ImageLocation = _list[0].Patch;
                        _rightAnswer = _list[0].Answer;
                        pictureBox1.Load();
                    }
                    else
                    {
                        pictureBox1.ImageLocation = _list[1].Patch;
                        _rightAnswer = _list[1].Answer;
                        pictureBox1.Load();
                    }
                }
                if (_coefficient == 1.4)
                {
                    if (k == 1)
                    {
                        pictureBox1.ImageLocation = _list[2].Patch;
                        _rightAnswer = _list[2].Answer;
                        pictureBox1.Load();
                    }
                    else
                    {
                        pictureBox1.ImageLocation = _list[3].Patch;
                        _rightAnswer = _list[3].Answer;
                        pictureBox1.Load();
                    }
                }
                if (_coefficient == 1.6)
                {
                    if (k == 1)
                    {
                        pictureBox1.ImageLocation = _list[4].Patch;
                        _rightAnswer = _list[4].Answer;
                        pictureBox1.Load();
                    }
                    else
                    {
                        pictureBox1.ImageLocation = _list[5].Patch;
                        _rightAnswer = _list[5].Answer;
                        pictureBox1.Load();
                    }
                }
                if (_coefficient == 1.8)
                {
                    if (k == 1)
                    {
                        pictureBox1.ImageLocation = _list[6].Patch;
                        _rightAnswer = _list[6].Answer;
                        pictureBox1.Load();
                    }
                    else
                    {
                        pictureBox1.ImageLocation = _list[7].Patch;
                        _rightAnswer = _list[7].Answer;
                        pictureBox1.Load();
                    }
                }   
            }
            else
            {
                pictureBox1.ImageLocation = _list[8].Patch;
                _rightAnswer = _list[8].Answer;
                pictureBox1.Load();
            }
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
            _id = user[count - 1].Id;

            context.Experiment2Result.Add(new Experiment2Result
            {
                Id_User = _id,
                TesteeResponse = _testeeAnswer,
                CorrectAnswer = _rightAnswer,
                Confidence = _confidence,
                NumberDisplay = _number,
                AllNumberDisplay = _number1
            });
            context.SaveChanges();
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
                var nForm = new Form12(_id);
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }
    }
}
