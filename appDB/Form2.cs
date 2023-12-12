using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appDB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            // СОЕДИНЯЕМСЯ С БАЗОЙ ДАННЫХ
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open(); // ОТКРЫВАЕМ ПОДКЛЮЧЕНИЕ
            string query = "Select * FROM Celler1"; // ВЫПОЛНЯЕМ ЗАПРОС ОТОБРАЖЕНИЯ ВСЕХ ЗАПИСЕЙ

            // СЧИТЫВАЕМ ДАННЫЕ ИЗ БАЗЫ ДАННЫХ
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
                    dataGridView1.Rows.Add(reader["ID"], reader["Специальность"], reader["Номер группы"], reader["Количество обучающихся"]);
                }
            }

            // ЗАКРЫВАЕМ ПОДКЛЮЧЕНИЕ И ВОЗМОЖНОСТЬ ДОАБВЛЕНИЯ ЗАПИСЕЙ
            reader.Close();
            connectiondb.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // УСЛОВИЕ ДЛЯ ВЫБОРА ЗАПИСИ 
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите ОДНУ строку!", "Сообщение.Внимание!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)


            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string special = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string nomer_group = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string colvo = dataGridView1.Rows[index].Cells[3].Value.ToString();

            // ПОДКЛЮЧАЕМСЯ К БАЗЕ ДАННЫХ
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);


            // ОТКРЫВАЕМ ПОДКЮЧЕНИЕ
            connectiondb.Open();
            string query = "INSERT INTO Celler1 VALUES (" + id + ", '" + special + "', '" + nomer_group + "', '" + colvo + "')"; // ЗАПРОС НА ДОБАВЛЕНИЕ
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);

            if (commanddb.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошбика выболнения запроса!", "Ошибка!");
            }
            else
            {
                MessageBox.Show("Данные были добавлены!", "Внимание!");
            }

            // ЗАКРЫВАЕМ ПОДКЛЮЧЕНИЕ
            connectiondb.Close();
        }


        private void button_update_Click(object sender, EventArgs e)
        {
            // УСЛОВИЕ ДЛЯ ВЫБОРА ЗАПИСИ
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите ОДНУ строку!", "Сообщение.Внимание!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string Group = dataGridView1.Rows[index].Cells[1].Value.ToString();

            // ОТКРЫВАЕМ ПОДКЛЮЧЕНИЕ К БАЗЕ ДАННЫХ
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();

            // ЗАПРОС НА ОБНОВЛЕНИЕ ДАННЫХ
            string query = "UPDATE [Celler] " +
                "SET [Группы] = '" + Group + "'," +
                "WHERE [ID] = " + id;

            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);

            if (commanddb.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошбика выболнения запроса!", "Ошибка!");
            }
            else
            {
                MessageBox.Show("Данные были изменены!", "Внимание!");
            }

            // ЗАКРЫВАЕМ ПОДКЛЮЧЕНИЕ
            connectiondb.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            // УСЛОВИЕ ДЛЯ УДАЛЕНИЯ ЗАПИСИ
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

            // ОТКРЫВАЕМ ПОДКЛЮЧЕНИЕ
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();

            // ЗАПРОС НА УДАЛЕНИЕ ЗАПИСИ
            string query = "DELETE FROM Celler1 WHERE ID = " + id;
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

            // ЗАКРЫВАЕМ ПОДКЛЮЧЕНИЕ
            connectiondb.Close();
        }

        private void выходИзБазыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void вернутьсяНаГлавнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void свернутьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void таблицаРиелторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void закрытьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] countrys = new string[] { "Информационные системы и программирование" };
            string[] count = new string[] { "403 ИСП", "303 ИСП", "203 ИСП", "103 ИСП" };
            // Загрузка комбобоксов в столбцы
            LoadComboBoxColumn(dataGridView1, 1, countrys);
            LoadComboBoxColumn(dataGridView1, 2, count);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}