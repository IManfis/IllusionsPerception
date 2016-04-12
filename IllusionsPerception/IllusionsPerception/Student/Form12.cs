using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
            WriteToDataGridView();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form6();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void WriteToDataGridView()
        {
            dataGridView1.Rows.Clear();
            var context = new IllusionsPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            var data = context.Experiment2Result.Where(x => x.Id_User == id);

            var row = 0;
            foreach (var result in data)
            {
                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay;

                var correctAnswer = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                correctAnswer.Value = result.CorrectAnswer;

                var testeeResponse = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                testeeResponse.Value = result.TesteeResponse;

                var confidence = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[3];
                confidence.Value = result.Confidence;

                if (result.CorrectAnswer == result.TesteeResponse)
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                }
                row++;
            }

            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
        }
    }
}
