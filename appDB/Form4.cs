using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace appDB
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void вернутьсяНаГлавнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void закрытьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();
            string query = "Select * FROM stud";
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);
            OleDbDataReader reader = commanddb.ExecuteReader();

            if (reader.HasRows == false)
            {
                MessageBox.Show("Данные не были загружены", "Ошибка!");
            }
            else
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["ID"], reader["Группы"], reader["ФИО Студента"]);
                }
            }

            reader.Close();
            connectiondb.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите ОДНУ строку!", "Сообщение.Внимание!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null)
            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string Group = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string FIO = dataGridView1.Rows[index].Cells[2].Value.ToString();


            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();
            string query = "INSERT INTO stud VALUES (" + id + ", '" + Group + "', '" + FIO + "') ";
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);

            if (commanddb.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошбика выболнения запроса!", "Ошибка!");
            }
            else
            {
                MessageBox.Show("Данные были добавлены!", "Внимание!");
            }

            connectiondb.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите ОДНУ строку!", "Сообщение.Внимание!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();


            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();
            string query = "DELETE FROM stud WHERE ID = " + id;
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);

            if (commanddb.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошбика выболнения запроса!", "Ошибка!");
            }
            else
            {
                MessageBox.Show("Данные были удалены!", "Внимание!");
                dataGridView1.Rows.RemoveAt(index);

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Комбокс
            string[] countrys = new string[] { "403 ИСП", "303 ИСП", "203 ИСП", "103 ИСП" };
            var oldcol = dataGridView1.Columns[1];
            var newcol = new DataGridViewComboBoxColumn();
            newcol.HeaderText = oldcol.HeaderText;
            newcol.Name = oldcol.Name;
            newcol.DataSource = countrys;
            newcol.DataPropertyName = oldcol.DataPropertyName;
            dataGridView1.Columns.RemoveAt(1);
            dataGridView1.Columns.Insert(1, newcol);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell is DataGridViewComboBoxCell)
            {
                dataGridView1.BeginEdit(false);
                (dataGridView1.EditingControl as DataGridViewComboBoxEditingControl).DroppedDown = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
