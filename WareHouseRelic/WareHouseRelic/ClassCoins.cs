using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
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
            
            //string databaseName = @"..\..\cyber1.db";
            string databaseName = Properties.Settings.Default.PathDatabase;

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
        public void AddNewCoin(string name, string year, string typeOfMetal, string letters, Image img1, Image img2)
        {
            string databaseName = Properties.Settings.Default.PathDatabase;
            string queryString;

            if (year == "")
            {
                queryString = "INSERT INTO 'example' ('name', 'year', 'type', 'letters', 'image1', 'image2') VALUES ('" + name + "', null, '" + typeOfMetal + "', '" + letters + "', @0, @1);";
            }
            else
            {
                queryString = "INSERT INTO 'example' ('name', 'year', 'type', 'letters', 'image1', 'image2') VALUES ('" + name + "', '" + year + "', '" + typeOfMetal + "', '" + letters + "', @0, @1);";
            }      

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            SQLiteCommand command = new SQLiteCommand(queryString, connection);

                Image photo = new Bitmap(img1);
                MemoryStream ms = new MemoryStream();
                photo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] pic = ms.ToArray();
                SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
                param.Value = pic;
                command.Parameters.Add(param);
                ///
                photo = new Bitmap(img2);
                ms = new MemoryStream();
                photo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                pic = ms.ToArray();
                param = new SQLiteParameter("@1", System.Data.DbType.Binary);
                param.Value = pic;
                command.Parameters.Add(param);
                

            connection.Open();
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
        public void EditCoin(string name, string year, string typeOfMetal, string letters, int id, Image img1, Image img2)
        {
            string databaseName = Properties.Settings.Default.PathDatabase;
            string queryString;

            if (year == "")
            {
                //queryString = "update example set name = '" + name + "' where id = " + id + "; update example set year = null where id = " + id + "; update example set type = '" + typeOfMetal + "' where id = " + id + "; update example set letters = '" + letters + "' where id = " + id + ";";
                queryString = "update example set name = '" + name + "' where id = " + id + "; update example set year = null where id = " + id + "; update example set type = '" + typeOfMetal + "' where id = " + id + "; update example set letters = '" + letters + "' where id = " + id + "; update example set image1 = @0 where id = " + id + "; update example set image2 = @1 where id = " + id + ";";
            }
            else
            {
                //queryString = "update example set name = '" + name + "' where id = " + id + "; update example set year = '" + year + "' where id = " + id + "; update example set type = '" + typeOfMetal + "' where id = " + id + "; update example set letters = '" + letters + "' where id = " + id + ";";
                queryString = "update example set name = '" + name + "' where id = " + id + "; update example set year = null where id = " + id + "; update example set type = '" + typeOfMetal + "' where id = " + id + "; update example set letters = '" + letters + "' where id = " + id + "; update example set image1 = @0 where id = " + id + "; update example set image2 = @1 where id = " + id + ";";
            }

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(queryString, connection);

            Image photo = new Bitmap(img1);
            MemoryStream ms = new MemoryStream();
            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] pic = ms.ToArray();
            SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
            param.Value = pic;
            command.Parameters.Add(param);
            ///
            photo = new Bitmap(img2);
            ms = new MemoryStream();
            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            pic = ms.ToArray();
            param = new SQLiteParameter("@1", System.Data.DbType.Binary);
            param.Value = pic;
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
            connection.Close();
        }
        
        /// <summary>
        /// Удаление записи о монете
        /// </summary>
        /// <param name="name">Идентификатор удаляемой записи</param>
        public void DeleteCoin(int id)
        {
            string databaseName = Properties.Settings.Default.PathDatabase;
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
        public void Getting(ListView lv)
        {
            lv.Items.Clear();

            string databaseName = Properties.Settings.Default.PathDatabase;
            string queryString = "SELECT * FROM example;";

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
            connection.Dispose();
        }

        /// <summary>
        /// Вывод базы данных в ListVeiw
        /// </summary>
        /// <param name="lv">Экземпляр ListVeiw в который будет происходить вывод базы данных</param>
        /// <param name="queryString">SQL - запрос на получение данных</param>
        public void Getting(ListView lv, string queryString)
        {
            lv.Items.Clear();

            string databaseName = Properties.Settings.Default.PathDatabase;
            //string databaseName = @"..\..\cyber1.db";

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
            connection.Dispose();
        }

        public void Getting(ListView lv, PictureBox pb1, PictureBox pb2)
        {
            string query = "SELECT image1, image2 FROM example WHERE ID='" + lv.Items[lv.SelectedIndices[0]].SubItems[4].Text + "';";
            string databaseName = Properties.Settings.Default.PathDatabase;

            SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            try
            {
                IDataReader rdr = cmd.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        byte[] pic = (System.Byte[])rdr[0];
                        MemoryStream ms = new MemoryStream(pic, 0, pic.Length);
                        ms.Write(pic, 0, pic.Length);
                        pb1.Image = new Bitmap(ms);

                        pic = (System.Byte[])rdr[1];
                        ms = new MemoryStream(pic, 0, pic.Length);
                        ms.Write(pic, 0, pic.Length);
                        pb2.Image = new Bitmap(ms);
                    }
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            con.Close();
        }

        public string GettingStatistics(string queryString)
        {
            string databaseName = Properties.Settings.Default.PathDatabase;
            string resulQuery = "0";

            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    resulQuery = Convert.ToString(reader[0]);
                }
            }
            connection.Close();
            connection.Dispose();

            return resulQuery;
        }
        #endregion
    }
} 