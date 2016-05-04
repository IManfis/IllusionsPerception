using System;
using System.Linq;
using System.Windows.Forms;
using IllusionsPerception.Model;

namespace IllusionsPerception.Teacher
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            WriteToDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form13();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void WriteToDataGridView()
        {
            dataGridView1.Rows.Clear();
            var context = new IllusionsPerceptionContext();
            var data = context.User;

            var row = 0;
            foreach (var result in data.Where(result => result.Group != null))
            {
                if (result.Name != "admin")
                {
                    dataGridView1.Rows.Add();
                    var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                    numberDisplay.Value = row + 1;

                    var providedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                    providedIncentive.Value = result.Name;

                    var groupNumber = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                    groupNumber.Value = result.Group;

                    var id = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[3];
                    id.Value = result.Id;

                    row++;   
                }
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];   
            }
        }

        private void Form14_Activated(object sender, EventArgs e)
        {
            WriteToDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            var context = new IllusionsPerceptionContext();
            var model = new User { Id = id };

            var result = MessageBox.Show("Вы уверены, что хотите удалить данного студента?", "Удаление студента", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                context.User.Attach(model);
                context.User.Remove(model);
                context.SaveChanges();

                WriteToDataGridView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            var nForm = new Form15(id);
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}
