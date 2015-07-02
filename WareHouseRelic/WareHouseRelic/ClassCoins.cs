using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseRelic
{
    /// <summary>
    /// Создание и манитуляция записями о монетах
    /// </summary>
    class ClassCoins
    {
        #region Конструктор класа
        /// <summary>
        /// Параметризированый конструктор класа ClassCoins
        /// </summary>
        /// <param name="name">Название монеты</param>
        /// <param name="age">Год чеканки</param>
        /// <param name="typeOfMetal">Метал монеты</param>
        /// <param name="letters">Буквенное обозначение монетного двора</param>
        public ClassCoins(string name, int year, string typeOfMetal, string letters)
        {
            Name = name;
            Year = year;
            TypeOfMetal = typeOfMetal;
            Letters = letters;
        }

        /// <summary>
        /// Пустой конструктор экземпляра класа ClassCoins
        /// </summary>
        public ClassCoins()
        {

        }
        #endregion

        #region Свойства класа
        public string Name { get; set; }

        public int Year { get; set; }

        public string TypeOfMetal { get; set; }

        public string Letters { get; set; }
        #endregion

        #region Методы класа
        /// <summary>
        /// Тестовое подключение к БД
        /// </summary>
        public void TestConnectToDb()
        {
            string databaseName = @"..\..\cyber1.db";

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            System.Windows.Forms.MessageBox.Show("Тестовое подключение к базе данных успешно");
            connection.Close();
        }
        
        /// <summary>
        /// Добавление новой записи о монете
        /// </summary>
        /// <param name="name">Название монеты</param>
        /// <param name="age">Год чеканки</param>
        /// <param name="typeOfMetal">Метал монеты</param>
        /// <param name="letters">Буквенное обозначение монетного двора</param>
        public void AddNewCoin(string name, string year, string typeOfMetal, string letters)
        {
            string databaseName = @"..\..\cyber1.db";
            string queryString;

            if (year == "")
            {
                queryString = "INSERT INTO 'example' ('name', 'year', 'type', 'letters') VALUES ('" + name + "', null, '" + typeOfMetal + "', '" + letters + "');";
            }
            else
            {
                queryString = "INSERT INTO 'example' ('name', 'year', 'type', 'letters') VALUES ('" + name + "', '" + year + "', '" + typeOfMetal + "', '" + letters + "');";
            }

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Редактирование записи о экспонате
        /// </summary>
        /// <param name="name">Название монеты</param>
        /// <param name="year">Год чеканки</param>
        /// <param name="typeOfMetal">Метал монеты</param>
        /// <param name="letters">Буквенное обозначение монетного двора</param>
        public void EditCoin(string name, string year, string typeOfMetal, string letters, int id)
        {
            string databaseName = @"..\..\cyber1.db";
            string queryString;

            if (year == "")
            {
                queryString = "update example set name = '" + name + "' where id = " + id + "; update example set year = null where id = " + id + "; update example set type = '" + typeOfMetal + "' where id = " + id + "; update example set letters = '" + letters + "' where id = " + id + ";";
            }
            else
            {
                queryString = "update example set name = '" + name + "' where id = " + id + "; update example set year = '" + year + "' where id = " + id + "; update example set type = '" + typeOfMetal + "' where id = " + id + "; update example set letters = '" + letters + "' where id = " + id + ";";
            }

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        /// <summary>
        /// Удаление записи о монете
        /// </summary>
        /// <param name="name">Идентификатор удаляемой записи</param>
        public void DeleteCoin(int id)
        {
            string databaseName = @"..\..\cyber1.db";
            string queryString = "delete from example where Id = '" + id + "';";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Вывод базы данных в ListVeiw
        /// </summary>
        /// <param name="lv">Экземпляр ListVeiw в который будет происходить вывод базы данных</param>
        /// <param name="queryString">SQL - запрос на получение данных</param>
        public void Getting(ListView lv)
        {
            lv.Items.Clear();

            string databaseName = @"..\..\cyber1.db";
            string queryString = "SELECT * FROM 'example';";

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                string[] str = new string[5];
                while (reader.Read())
                {
                    for (int j = 0; j < 5; j++)
                    {
                        str[j] = Convert.ToString(reader[j]);
                    }

                    ListViewItem lvi = new ListViewItem(str);
                    lv.Items.Add(lvi);
                }
            }
            connection.Close();

            /*string queryString = "SELECT * FROM 'example';";
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                string[] str = new string[5];
 
                str[0] = record["name"].ToString();
                str[1] = record["year"].ToString();
                str[2] = record["type"].ToString();
                str[3] = record["letters"].ToString();
                str[4] = record["id"].ToString();

                ListViewItem lvi = new ListViewItem(str);
                lv.Items.Add(lvi);
            }
            connection.Close();*/
        }
        #endregion
    }
} 