using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Teacher
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
            WriteToDataGridView1(2);
            WriteToDataGridView2(2);
        }

        public Form15(int id)
        {
            InitializeComponent();
            WriteToDataGridView1(id);
            WriteToDataGridView2(id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form14();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void WriteToDataGridView1(int id)
        {
            dataGridView1.Rows.Clear();
            var context = new IllusionsPerceptionContext();
            var data = context.Experiment1Result.Where(x => x.Id_User == id);

            var row = 0;
            foreach (var result in data)
            {
                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay;

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                providedIncentive.Value = result.AbsoluteValue;

                var sign = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                sign.Value = result.Sign;

                row++;
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];   
            }
        }

        private void WriteToDataGridView2(int id)
        {
            dataGridView2.Rows.Clear();
            var context = new IllusionsPerceptionContext();
            var data = context.Experiment2Result.Where(x => x.Id_User == id);

            var row = 0;
            foreach (var result in data)
            {
                dataGridView2.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay;

                var correctAnswer = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[1];
                correctAnswer.Value = result.CorrectAnswer;

                var testeeResponse = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[2];
                testeeResponse.Value = result.TesteeResponse;

                var confidence = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[3];
                confidence.Value = result.Confidence;

                if (result.CorrectAnswer == result.TesteeResponse)
                {
                    dataGridView2.Rows[row].Cells[1].Style.BackColor = Color.Green;
                    dataGridView2.Rows[row].Cells[2].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView2.Rows[row].Cells[1].Style.BackColor = Color.Red;
                    dataGridView2.Rows[row].Cells[2].Style.BackColor = Color.Red;
                }
                row++;
            }

            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.CurrentCell = dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0];
            }
        }
    }
}
