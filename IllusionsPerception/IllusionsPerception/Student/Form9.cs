using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Student
{
    public partial class Form9 : Form
    {
        private readonly int _id = 0;
        public Form9()
        {
            InitializeComponent();
            _id = 2;
            WriteToDataGridView(_id);
        }

        public Form9(int id)
        {
            InitializeComponent();
            _id = id;
            WriteToDataGridView(id);
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
            var count = context.User.Count();
            var user = context.User.ToList();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new IllusionsPerceptionContext();
            var user = context.User.FirstOrDefault(x => x.Id == _id);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FileName = user.Name + " Опыт №1";
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

            var numberExperiment = "Опыт №1\n\n";
            var experimentResult = context.Experiment1Result.Where(x => x.Id_User == _id).ToList();
            result.Append(numberExperiment);
            var str1 = "============================\n";
            var str2 = "|       |      Ошибка      |\n";
            var str3 = "|N подр.|------------------|\n";
            var str4 = "|       |Абс. величина|Знак|\n";
            var str5 = "|--------------------------|\n";
            result.Append(str1);
            result.Append(str2);
            result.Append(str3);
            result.Append(str4);
            result.Append(str5);

            foreach (var res in experimentResult)
            {
                var numberdisplay = res.NumberDisplay.ToString();
                if (numberdisplay.Length == 1)
                {
                    numberdisplay += " ";
                }

                var absoluteValue = res.AbsoluteValue.ToString("##0");
                if (absoluteValue.Length == 1)
                {
                    absoluteValue += "  ";
                }
                if (absoluteValue.Length == 2)
                {
                    absoluteValue += " ";
                }
                var str6 = string.Format("|   {0}  |     {1}     |  {2} |\n",numberdisplay,absoluteValue,res.Sign);
                result.Append(str6);
            }

            result.Append(str1);
            return result.ToString();
        }
    }
}
