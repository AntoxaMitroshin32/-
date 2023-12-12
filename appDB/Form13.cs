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
    public partial class Form13 : Form
    {
        public Form13()
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
            string query = "Select * FROM 1yspevaemostMatematika";
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
                    dataGridView1.Rows.Add(reader["ID"], reader["Группа"], reader["Фамилия Студента"], reader["Предмет"], reader["Средний балл"], reader["Итоговая оценка"]);
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
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null)
            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string group = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string Surname = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string predmet = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string sredOcenka = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string itogOcenka = dataGridView1.Rows[index].Cells[5].Value.ToString();


            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            OleDbConnection connectiondb = new OleDbConnection(connection);

            connectiondb.Open();
            string query = "INSERT INTO 1yspevaemostMatematika VALUES (" + id + ", '" + group + "', '" + Surname + "', '" + predmet + "',  '" + sredOcenka + "', " + itogOcenka + ") ";
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
            string query = "DELETE FROM 1yspevaemostMatematika WHERE ID = " + id;
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

        private void Form13_Load(object sender, EventArgs e)
        {
            string[] countrys = new string[] { "403 ИСП", "303 ИСП", "203 ИСП", "103 ИСП" };
            string[] count = new string[] { "МДК.01.01 Разработка программных модулей", "МДК.01.02 Поддержка и тестирование программных модулей", "МДК.01.03 Разработка мобильных приложений", "МДК.01.04 Системное программирование" };
            // Загрузка комбобоксов в столбцы
            LoadComboBoxColumn(dataGridView1, 1, countrys);
            LoadComboBoxColumn(dataGridView1, 3, count);
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
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Проверяем, является ли ячейка DataGridViewComboBoxCell
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn &&
            e.Context == DataGridViewDataErrorContexts.Commit)
            {
                // Отключаем исключение, чтобы предотвратить появление окна ошибки
                e.ThrowException = false;

                // Очищаем значение ячейки, чтобы избежать сохранения некорректного значения
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                dataGridView1.DataError += dataGridView1_DataError;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
