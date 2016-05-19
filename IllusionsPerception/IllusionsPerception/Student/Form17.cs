using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form17 : Form
    {
        private int _id = 0;
        public Form17()
        {
            InitializeComponent();
        }

        public Form17(int id)
        {
            InitializeComponent();
            WriteData(id);
        }

        private void WriteData(int id)
        {
            _id = id;
            var context = new IllusionsPerceptionContext();
            var experimentResult = context.Experiment1Result.Where(x => x.Id_User == id).ToList();

            if (experimentResult.Count != 0)
            {
                var rez = experimentResult[experimentResult.Count - 1];

                dataGridView1.Rows.Add();

                var name = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[0];
                name.Value = "Опыт №1";

                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[1];
                numberDisplay.Value = rez.NumberDisplay.ToString();

                var allNumberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[2];
                allNumberDisplay.Value = rez.AllNumberDisplay.ToString();
                if (rez.NumberDisplay == rez.AllNumberDisplay)
                {
                    dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                }   
            }
            else
            {
                dataGridView1.Rows.Add();

                var name = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[0];
                name.Value = "Опыт №1";

                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[1];
                numberDisplay.Value = 0.ToString();

                var allNumberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[2];
                allNumberDisplay.Value = context.Settings.FirstOrDefault(x => x.Name == "Предъявлений1").Value;
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Red;
            }

            var experimentResult1 = context.Experiment2Result.Where(x => x.Id_User == id).ToList();

            if (experimentResult1.Count != 0)
            {
                var rez1 = experimentResult1[experimentResult1.Count - 1];

                dataGridView1.Rows.Add();

                var name1 = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[0];
                name1.Value = "Опыт №2";

                var numberDisplay1 = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[1];
                numberDisplay1.Value = rez1.NumberDisplay.ToString();

                var allNumberDisplay1 = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[2];
                allNumberDisplay1.Value = rez1.AllNumberDisplay.ToString();

                if (rez1.NumberDisplay == rez1.AllNumberDisplay)
                {
                    dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Red;
                }   
            }
            else
            {
                dataGridView1.Rows.Add();

                var name = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[0];
                name.Value = "Опыт №2";

                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[1];
                numberDisplay.Value = 0.ToString();

                var allNumberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[2];
                allNumberDisplay.Value = int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Предварительная").Value) 
                    + int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Контрольная").Value);
                dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form3();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;

            var context = new IllusionsPerceptionContext();
            var name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var experimentResult = context.Experiment1Result.Where(x => x.Id_User == _id).ToList();
            var experimentResult1 = context.Experiment2Result.Where(x => x.Id_User == _id).ToList();

            var count = int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Предъявлений1").Value);
            var count1 = int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Предварительная").Value)
                         + int.Parse(context.Settings.FirstOrDefault(x => x.Name == "Контрольная").Value);

            Experiment1Result rez = new Experiment1Result();
            if (experimentResult.Count != 0)
            {
                rez = experimentResult[experimentResult.Count - 1];    
            }
            else
            {
                rez.NumberDisplay = 0;
                rez.AllNumberDisplay = count;
            }

            Experiment2Result rez1 = new Experiment2Result();
            if (experimentResult1.Count != 0)
            {
                rez1 = experimentResult1[experimentResult1.Count - 1];
            }
            else
            {
                rez1.NumberDisplay = 0;
                rez1.AllNumberDisplay = count1;
            }

            switch (name)
            {
                case "Опыт №1":
                    if (rez.NumberDisplay == rez.AllNumberDisplay)
                    {
                        label2.Visible = true;
                        break;
                    }
                    else
                    {
                        var nForm = new Form8(rez.NumberDisplay + 1, _id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                case "Опыт №2":
                    if (rez1.NumberDisplay == rez1.AllNumberDisplay)
                    {
                        label2.Visible = true;
                        break;
                    }
                    else
                    {
                        var nForm = new Form11(rez1.NumberDisplay + 1, _id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form6();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
