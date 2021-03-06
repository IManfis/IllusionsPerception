﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form8 : Form
    {
        private int _number = 1;
        private int _number1 = 1;
        private bool _continue = false;
        private int _id = 0;
        public Form8()
        {
            var context = new IllusionsPerceptionContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений1").Value);
            InitializeComponent();
            label3.Text = _number.ToString();
            label5.Text = _number1.ToString();
        }

        public Form8(int number, int id)
        {
            var context = new IllusionsPerceptionContext();
            _number1 = int.Parse(context.Settings.First(x => x.Name == "Предъявлений1").Value);
            InitializeComponent();
            _number = number;
            _continue = true;
            _id = id;
            label3.Text = _number.ToString();
            label5.Text = _number1.ToString();
        }

        bool isDown;
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {

            isDown = true;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            var c = sender as Control;
            if (isDown)
            {
                if (MousePosition.X > 100 + this.DesktopLocation.X && MousePosition.X < 639 + this.DesktopLocation.X)
                {
                    c.Location = this.PointToClient(new Point(MousePosition.X, 306 + this.DesktopLocation.Y));
                }
                else if (MousePosition.X < 102 + this.DesktopLocation.X)
                {
                    c.Location = this.PointToClient(new Point(103 + this.DesktopLocation.X, 306 + this.DesktopLocation.Y));
                }
                else if (MousePosition.X > 638 + this.DesktopLocation.X)
                {
                    c.Location = this.PointToClient(new Point(636 + this.DesktopLocation.X, 306 + this.DesktopLocation.Y));
                }

            }
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var x = button3.Location.X;
            var y = button3.Location.Y;

            if (x < 102)
            {
                button3.Location = this.PointToClient(new Point(103 + this.DesktopLocation.X, 306 + this.DesktopLocation.Y));
            }
            else
            {
                button3.Location = new Point(x - 1, y);
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var x = button3.Location.X;
            var y = button3.Location.Y;

            if (x > 626)
            {
                button3.Location = this.PointToClient(new Point(636 + this.DesktopLocation.X, 306 + this.DesktopLocation.Y));
            }
            else
            {
                button3.Location = new Point(x + 1, y);
            }
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            var nForm = new Form6();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var context = new IllusionsPerceptionContext();

            var count = context.User.Count();
            var user = context.User.ToList();
            _id = user[count - 1].Id;

            if (_number > _number1)
            {
                button4.Enabled = false;
                button6.Visible = true;
            }
            else
            {
                var length = 590;
                var center = length / 2;
                var value = center - button3.Location.X + 49;
                var absoluteValue = 0;
                var sign = "";
                if (value < 0)
                {
                    absoluteValue = Math.Abs(value);
                    sign = "-";
                }
                else
                {
                    absoluteValue = value;
                    sign = "+";
                }

                context.Experiment1Result.Add(new Experiment1Result
                {
                    Id_User = _id,
                    AbsoluteValue = absoluteValue,
                    Sign = sign,
                    NumberDisplay = _number,
                    AllNumberDisplay = _number1
                });
                context.SaveChanges();
                _number++;
                if (_number == _number1 + 1)
                {
                    button4.Enabled = false;
                    button6.Visible = true;
                }
                else
                {
                    label3.Text = _number.ToString();   
                }
                button3.Location = new Point(new Random().Next(103, 636), 280);
            }
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
                var nForm = new Form9(_id);
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }
    }
}
