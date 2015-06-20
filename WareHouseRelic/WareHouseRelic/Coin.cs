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
        public void AddNewCoin(string name, string year, string typeOfMetal, string letters)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;
            string queryString = "INSERT INTO CoinTable (ID, NameCoin, YearCoin, TypeMetal, Letters) values('717', '" + name + "', '" + year + "', '" + typeOfMetal + " ', '" + letters + " ')";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);

            /*SqlParameter param = new SqlParameter();

            param.ParameterName = "@Id";
            param.Value = 7;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@NameCoin";
            param.Value = name;
            param.SqlDbType = SqlDbType.NText;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@YearCoin";
            param.Value = age;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@TypeMetal";
            param.Value = typeOfMetal;
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Letters";
            param.Value = queryString;
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);*/
      
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }

        /// <summary>
        /// Редактирование записи о экспонате
        /// </summary>
        /// <param name="name">Название монеты</param>
        /// <param name="year">Год чеканки</param>
        /// <param name="typeOfMetal">Метал монеты</param>
        /// <param name="letters">Буквенное обозначение монетного двора</param>
        public void EditCoin(string name, int year, string typeOfMetal, string letters)
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;
            string queryString = " ";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
        }
        
        /// <summary>
        /// Удаление записи о монете
        /// </summary>
        public void DeleteCoin()
        {
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;
            string queryString = " ";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);

        }

        /// <summary>
        /// Вывод базы данных в ListVeiw
        /// </summary>
        /// <param name="lv">Экземпляр ListVeiw в который будет происходить вывод базы данных</param>
        /// <param name="queryString">SQL - запрос на получение данных</param>
        public void DataOutput(ListView lv)
        {
            lv.Items.Clear();
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;
            string queryString = "SELECT * FROM CoinTable";

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