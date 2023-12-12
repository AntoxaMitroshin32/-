using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace appDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void обПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
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
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null)

            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string group = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string nabor = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string Name_diciplina = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string semstr1 = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string vid1 = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string semestr2 = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string vid2 = dataGridView1.Rows[index].Cells[7].Value.ToString();


            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();
            string query = "INSERT INTO Client1 VALUES (" + id + ", '" + group + "', '" + nabor + "', '" + Name_diciplina + "', '" + semstr1 + "', '" + vid1 + "', '" + semestr2 + "', '" + vid2 + "') ";
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

        private void button_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите ОДНУ строку!", "Сообщение.Внимание!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null)
            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string Name = dataGridView1.Rows[index].Cells[1].Value.ToString();

            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();
            string query = "UPDATE Client SET [Наименование] = '" + " WHERE [ID] = " + id;
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);

            if (commanddb.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошбика выболнения запроса!", "Ошибка!");
            }
            else
            {
                MessageBox.Show("Данные были изменены!", "Внимание!");
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
            string query = "DELETE FROM Client WHERE ID = " + id;
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

            connectiondb.Close();
        }

        private void свернутьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void таблицаРиелторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void закрытьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] countrys = new string[] { "Информационные системы и программирование" };
            string[] count = new string[] { "2020-2024", "2021-2025", "2022-2026", "2023-2027" };
            string[] counta = new string[] { "МДК.01.01 Разработка программных модулей", "МДК.01.02 Поддержка и тестирование программных модулей", "МДК.01.03 Разработка мобильных приложений", "МДК.01.04 Системное программирование" };
            string[] countr = new string[] { "Дифференцированный зачет", "Дифференцированный экзамен", "Зачет", "Экзамен", "Дифференцированный зачет/экзамен", "Зачет/экзамен" };
            string[] countra = new string[] { "Дифференцированный зачет", "Дифференцированный экзамен", "Зачет", "Экзамен", "Дифференцированный зачет/экзамен", "Зачет/экзамен" };
            // Загрузка комбобоксов в столбцы
            LoadComboBoxColumn(dataGridView1, 1, countrys);
            LoadComboBoxColumn(dataGridView1, 2, count);
            LoadComboBoxColumn(dataGridView1, 3, counta);
            LoadComboBoxColumn(dataGridView1, 5, countr);
            LoadComboBoxColumn(dataGridView1, 7, countra);
        }
        private void LoadComboBoxColumn(DataGridView dataGridView, int columnIndex, string[] items)
        {
            var oldcol = dataGridView.Columns[columnIndex];
            var newcol = new DataGridViewComboBoxColumn();
            newcol.HeaderText = oldcol.HeaderText;
            newcol.Name = oldcol.Name;
            newcol.DataSource = items;
            newcol.DataPropertyName = oldcol.DataPropertyName;
            dataGridView.Columns.RemoveAt(columnIndex);
            dataGridView.Columns.Insert(columnIndex, newcol);
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

        private void button_connect_Click_1(object sender, EventArgs e)
        {
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();
            string query = "Select * FROM Client1";
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
                    dataGridView1.Rows.Add(reader["ID"], reader["Специальность"], reader["Набор"], reader["Наименование дисциплины"], reader["1 семестр часы"], reader["Вид зачета1"], reader["2 семестр часы"], reader["Вид зачета2"]);
                }
            }

            reader.Close();
            connectiondb.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
