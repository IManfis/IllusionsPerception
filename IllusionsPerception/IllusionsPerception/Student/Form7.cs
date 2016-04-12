using System.Drawing;
using System.Windows.Forms;

namespace IllusionsPerception.Student
{
    public partial class Form7 : Form
    {
        private int _number = 1;
        public Form7()
        {
            InitializeComponent();
            label3.Text = _number.ToString();
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
                if (Control.MousePosition.X > 100 + this.DesktopLocation.X && Control.MousePosition.X < 639 + this.DesktopLocation.X)
                {
                    c.Location = this.PointToClient(new Point(Control.MousePosition.X, 310 + this.DesktopLocation.Y));
                }
                else if (Control.MousePosition.X < 102 + this.DesktopLocation.X)
                {
                    c.Location = this.PointToClient(new Point(103 + this.DesktopLocation.X, 310 + this.DesktopLocation.Y));
                }
                else if (Control.MousePosition.X > 638 + this.DesktopLocation.X)
                {
                    c.Location = this.PointToClient(new Point(636 + this.DesktopLocation.X, 310 + this.DesktopLocation.Y));
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
                button3.Location = this.PointToClient(new Point(103 + this.DesktopLocation.X, 310 + this.DesktopLocation.Y));
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
                button3.Location = this.PointToClient(new Point(636 + this.DesktopLocation.X, 310 + this.DesktopLocation.Y));
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
            _number++;
            if (_number > 5)
            {
                button4.Enabled = false;
                button6.Visible = true;
            }
            else
            {
                label3.Text = _number.ToString();
            }
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            var nForm = new Form8();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
