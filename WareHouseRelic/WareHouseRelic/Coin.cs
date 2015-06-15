using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseRelic
{
    /// <summary>
    /// Создание и манитуляция записями о монетах
    /// </summary>
    class Coin
    {
        #region Конструктор класа
        /// <summary>
        /// Параметризированый конструктор класа Coin
        /// </summary>
        /// <param name="name">Название монеты</param>
        /// <param name="age">Год чеканки</param>
        /// <param name="typeOfMetal">Метал монеты</param>
        /// <param name="letters">Буквенное обозначение монетного двора</param>
        public Coin(string name, int year, string typeOfMetal, string letters)
        {
            Name = name;
            Year = year;
            TypeOfMetal = typeOfMetal;
            Letters = letters;
        }

        /// <summary>
        /// Пустой конструктор экземпляра класа Coin
        /// </summary>
        public Coin()
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
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectionString;
            cn.Open();
            System.Windows.Forms.MessageBox.Show("Тестовое подключение к базе данных успешно");
            cn.Close();
        }
        /// <summary>
        /// Добавление новой записи о монете
        /// </summary>
        /// <param name="name">Название монеты</param>
        /// <param name="age">Год чеканки</param>
        /// <param name="typeOfMetal">Метал монеты</param>
        /// <param name="letters">Буквенное обозначение монетного двора</param>
        public void AddNewCoin(string name, int age, string typeOfMetal, string letters, string queryString)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Редактирование записи о экспонате
        /// </summary>
        /// <param name="name">Название монеты</param>
        /// <param name="age">Год чеканки</param>
        /// <param name="typeOfMetal">Метал монеты</param>
        /// <param name="letters">Буквенное обозначение монетного двора</param>
        public void EditCoin(string name, int age, string typeOfMetal, string letters)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Удаление записи о монете
        /// </summary>
        public void DeleteCoin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Вывод базы данных в ListVeiw
        /// </summary>
        /// <param name="lv">Экземпляр ListVeiw в который будет происходить вывод базы данных</param>
        /// <param name="queryString">SQL - запрос на получение данных</param>
        public void DataOutput(ListView lv, string queryString)
        {
            lv.Items.Clear();
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                string[] sss = new string[4];
                while (dr.Read())
                {
                    for (int j = 0; j < 4; j++)
                    {
                        sss[j] = Convert.ToString(dr[j + 1]);
                    }

                    ListViewItem lvi = new ListViewItem(sss);
                    lv.Items.Add(lvi);
                }
            }
            con.Close();
        }
        #endregion
    }
}