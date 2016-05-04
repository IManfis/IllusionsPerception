using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form12 : Form
    {
        private int _id = 0;
        public Form12()
        {
            InitializeComponent();
            var context = new IllusionsPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            WriteToDataGridView(id);
            _id = id;
        }

        public Form12(int id)
        {
            InitializeComponent();
            WriteToDataGridView(id);
            _id = id;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nForm = new Form6();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void WriteToDataGridView(int id)
        {
            dataGridView1.Rows.Clear();
            var context = new IllusionsPerceptionContext();
            
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
                    dataGridView1.Rows[row].Cells[1].Style.BackColor = Color.Green;
                    dataGridView1.Rows[row].Cells[2].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[row].Cells[1].Style.BackColor = Color.Red;
                    dataGridView1.Rows[row].Cells[2].Style.BackColor = Color.Red;
                }
                row++;
            }
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new IllusionsPerceptionContext();
            var user = context.User.FirstOrDefault(x => x.Id == _id);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FileName = user.Name + " Опыт №2";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            var result = new StringBuilder();

            var name = "Имя испытуемого: " + user.Name + "\n";
            var date = "Дата: " + user.Date + "\n";
            var group = "Номер группы: " + user.Group + "\n";

            result.Append(name);
            result.Append(date);
            result.Append(group);
            result.Append(ExperimentResult());

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, result.ToString());
            }
        }

        private string ExperimentResult()
        {
            var context = new IllusionsPerceptionContext();
            var user = context.User.FirstOrDefault(x => x.Id == _id);

            var result = new StringBuilder();

            var numberExperiment = "Опыт №2\n\n";
            var experimentResult = context.Experiment2Result.Where(x => x.Id_User == _id).ToList();
            result.Append(numberExperiment);
            var str1 = "================================================\n";
            var str2 = "| N |Ответ испытуемого|Верный ответ|Уверенность|\n";
            var str3 = "|----------------------------------------------|\n";

            result.Append(str1);
            result.Append(str2);
            result.Append(str3);

            foreach (var res in experimentResult)
            {
                var numberdisplay = res.NumberDisplay.ToString();
                if (numberdisplay.Length == 1)
                {
                    numberdisplay += " ";
                }

                var testeeResponse = res.TesteeResponse;
                if (testeeResponse.Length == 5)
                {
                    testeeResponse += " ";
                }

                var correctAnswer = res.CorrectAnswer;
                if (correctAnswer.Length == 5)
                {
                    correctAnswer += " ";
                }

                var str4 = string.Format("|{0} |     {1}      |   {2}   |     {3}     |\n", numberdisplay, testeeResponse, correctAnswer, res.Confidence);
                result.Append(str4);
            }

            result.Append(str1);
            return result.ToString();
        }
    }
}
