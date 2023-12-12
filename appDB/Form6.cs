using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace appDB
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        
        private void вернутьсяНаГлавнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(); 
            f.Show();
            this.Hide();
        }
        // Обработчик нажатия на кнопку "Загрузить таблицу"
        private void button_connect_Click(object sender, EventArgs e)
        {
            // Строка подключения к базе данных
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            // Создание объекта подключения к базе данных
            OleDbConnection connectiondb = new OleDbConnection(connection);

            // Открытие соединения с базой данных
            connectiondb.Open();
            // Запрос на выбор всех записей из таблицы
            string query = "Select * FROM 1matematika";
            // Создание объекта команды с запросом и подключением
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);
            // Выполнение запроса и получение результата в виде объекта чтения данных
            OleDbDataReader reader = commanddb.ExecuteReader();

            // Проверка наличия данных в результатах запроса
            if (reader.HasRows == false)
            {
                // Вывод сообщения об ошибке, если данные не были загружены
                MessageBox.Show("Данные не были загружены", "Ошибка!"); 
            }
            else
            {
                // Цикл для чтения каждой записи из результата запроса
                while (reader.Read())
                {
                    // Добавление данных из записи в таблицу dataGridView1
                    dataGridView1.Rows.Add(reader["ID"], reader["Группа"], reader["Фамилия Студента"], reader["Предмет"], reader["Оценка1"], reader["Вид работы1"], reader["Оценка2"], reader["Вид работы2"], reader["Оценка3"], reader["Вид работы3"], reader["Оценка4"], reader["Вид работы4"], reader["Оценка5"], reader["Вид работы5"], reader["Средний балл"]); 
                }
            }
            // Установка обработчика события ошибки данных в таблице dataGridView1
            dataGridView1.DataError += dataGridView1_DataError;
        }
        // Обработчик нажатия на кнопку "Добавить данные"
        private void button_add_Click(object sender, EventArgs e)
        {
            // Проверка выбранной строки в таблице
            if (dataGridView1.SelectedRows.Count != 1)
            {
                // Вывод сообщения об ошибке, если не выбрана одна строка
                MessageBox.Show("Выберите ОДНУ строку!", "Сообщение.Внимание!"); 
                return;
            }
            // Получение индекса выбранной строки
            int index = dataGridView1.SelectedRows[0].Index;
            // Проверка заполненности всех ячеек выбранной строки
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null ||
                dataGridView1.Rows[index].Cells[8].Value == null ||
                dataGridView1.Rows[index].Cells[9].Value == null ||
                dataGridView1.Rows[index].Cells[10].Value == null ||
                dataGridView1.Rows[index].Cells[11].Value == null ||
                dataGridView1.Rows[index].Cells[12].Value == null ||
                dataGridView1.Rows[index].Cells[13].Value == null ||
                dataGridView1.Rows[index].Cells[13].Value == null) 


            {
                // Вывод сообщения об ошибке, если не все данные заполнены
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }
            // Получение значений из ячеек выбранной строки
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string group = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string FIO = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string predmet = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string Ocenka1 = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string Vid1 = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string Ocenka2 = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string Vid2 = dataGridView1.Rows[index].Cells[7].Value.ToString();
            string Ocenka3 = dataGridView1.Rows[index].Cells[8].Value.ToString();
            string Vid3 = dataGridView1.Rows[index].Cells[9].Value.ToString();
            string Ocenka4 = dataGridView1.Rows[index].Cells[10].Value.ToString();
            string Vid4 = dataGridView1.Rows[index].Cells[11].Value.ToString();
            string Ocenka5 = dataGridView1.Rows[index].Cells[12].Value.ToString();
            string Vid5 = dataGridView1.Rows[index].Cells[13].Value.ToString();
            string srednOcenka = dataGridView1.Rows[index].Cells[14].Value.ToString();

            // Устанавливаем строку подключения к базе данных
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            // Создаем экземпляр объекта для подключения к базе данных
            OleDbConnection connectiondb = new OleDbConnection(connection);
            // Открываем подключение к базе данных
            connectiondb.Open();
            // Создаем строку запроса для добавления данных в базу
            string query = "INSERT INTO 1matematika VALUES (" + id + ", '" + group + "', '" + FIO + "', '" + predmet + "', " + Ocenka1 + ", '" + Vid1 + "', " + Ocenka2 + ", '" + Vid2 + "', " + Ocenka3 + ", '" + Vid3 + "', " + Ocenka4 + ", '" + Vid4 + "', " + Ocenka5 + ", '" + Vid5 + "', '" + srednOcenka + "') ";
            // Создаем экземпляр объекта OleDbCommand для выполнения запроса
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);
            // Выполняем запрос и получаем количество обновленных строк
            int rowsUpdated = commanddb.ExecuteNonQuery();
            
            if (rowsUpdated != 1)
            {
                MessageBox.Show("Ошбика выболнения запроса!", "Ошибка!");
            }
            else
            {
                MessageBox.Show("Данные были добавлены!", "Внимание!");
            }
            // Закрываем подключение к базе данных
            connectiondb.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите ОДНУ строку!", "Сообщение.Внимание!");
                return;
            }
            // Получаем индекс выбранной строки в DataGridView
            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены, проверьте правильность введенных данных!", "Внимание!");
                return;
            }
            // Получаем значение ячейки с ID выбранной строки
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();


            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
            // Создаем экземпляр объекта для подключения к базе данных
            OleDbConnection connectiondb = new OleDbConnection(connection);
            // Открываем подключение к базе данных
            connectiondb.Open();
            // Создаем строку запроса для удаления данных из базы
            string query = "DELETE FROM 1matematika WHERE ID = " + id;
            // Создаем экземпляр объекта OleDbCommand для выполнения запроса
            OleDbCommand commanddb = new OleDbCommand(query, connectiondb);

            if (commanddb.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошбика выболнения запроса!", "Ошибка!");
            }
            else
            {
                MessageBox.Show("Данные были удалены!", "Внимание!");
                // Удаляем выбранную строку из DataGridView
                dataGridView1.Rows.RemoveAt(index);

            }
            // Закрываем подключение к базе данных
            connectiondb.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n, nrow;
            Double result, result1;
            String s;
            // Получаем количество строк в DataGridView
            nrow = dataGridView1.RowCount;
            for (int i = 0; i < nrow; i++)
            {
                // Инициализируем переменную sum нулевым значением
                int sum = 0;
                if (dataGridView1.Rows[i].Cells[4].Value != null)
                {
                    // Если значение ячейки с индексом 4 не равно null, то прибавляем его к сумме
                    s = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    n = int.Parse(s);
                    sum += n;
                }
                if (dataGridView1.Rows[i].Cells[6].Value != null)
                {
                    // Если значение ячейки с индексом 6 не равно null, то прибавляем его к сумме
                    s = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    n = int.Parse(s);
                    sum += n;
                }
                if (dataGridView1.Rows[i].Cells[8].Value != null)
                {
                    // Если значение ячейки с индексом 8 не равно null, то прибавляем его к сумме
                    s = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    n = int.Parse(s);
                    sum += n;
                }
                if (dataGridView1.Rows[i].Cells[10].Value != null)
                {
                    // Если значение ячейки с индексом 10 не равно null, то прибавляем его к сумме
                    s = dataGridView1.Rows[i].Cells[10].Value.ToString();
                    n = int.Parse(s);
                    sum += n;
                }
                if (dataGridView1.Rows[i].Cells[12].Value != null)
                {
                    // Если значение ячейки с индексом 12 не равно null, то прибавляем его к сумме
                    s = dataGridView1.Rows[i].Cells[12].Value.ToString();
                    n = int.Parse(s);
                    sum += n;
                }
                result = sum; // Присваивание переменной result значения sum
                result1 = Math.Round(result / 5, 2); // Присваивание переменной result1 значения результат деления result на 5 с округлением до 2 знака после запятой
                dataGridView1.Rows[i].Cells[14].Value = result1.ToString(); // Присваивание ячейке с индексом 14 значения result1 в виде строки
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            string[] countrys = new string[] { "403 ИСП", "303 ИСП", "203 ИСП", "103 ИСП" }; // Создание массива строк countrys
            string[] count = new string[] { "МДК.01.01 Разработка программных модулей", "МДК.01.02 Поддержка и тестирование программных модулей", "МДК.01.03 Разработка мобильных приложений", "МДК.01.04 Системное программирование" }; // Создание массива строк count
            string[] coun = new string[] { "КР", "ДЗ", "СР", "РУ" }; // Создание массива строк coun
            // Загрузка комбо-боксов в DataGridView
            LoadComboBoxColumn(dataGridView1, 1, countrys);
            LoadComboBoxColumn(dataGridView1, 3, count);
            LoadComboBoxColumn(dataGridView1, 5, coun);
            LoadComboBoxColumn(dataGridView1, 7, coun);
            LoadComboBoxColumn(dataGridView1, 9, coun);
            LoadComboBoxColumn(dataGridView1, 11, coun);
            LoadComboBoxColumn(dataGridView1, 13, coun);
        }
        // Метод для заполнения комбо-бокса в указанной колонке DataGridView
        private void LoadComboBoxColumn(DataGridView dataGridView, int columnIndex, string[] items)
        {
            // Получение старой колонки
            var oldcol = dataGridView.Columns[columnIndex];
            // Создание новой колонки комбо-бокса
            var newcol = new DataGridViewComboBoxColumn();
            newcol.HeaderText = oldcol.HeaderText;
            newcol.Name = oldcol.Name;
            newcol.DataSource = items;
            newcol.DataPropertyName = oldcol.DataPropertyName;
            // Удаление старой колонки и вставка новой
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
    }
}