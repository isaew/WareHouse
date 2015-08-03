using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseRelic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.TopNode.Expand(); //Розвертывание первого узла

            ClassCoins c = new ClassCoins(); //Выгрузка БД в основное окно программы
            c.Getting(listView1);            //

            //проверка даты для необходимости создания бекапа
            if (Properties.Settings.Default.BackupCopy)
            {
                TimeSpan tSpan1 = new TimeSpan(Properties.Settings.Default.TimeBetweenBackups, 0, 0, 0);
                TimeSpan tSpan = DateTime.Now.Date - Properties.Settings.Default.LastBackup.Date;

                if (tSpan1 < tSpan)
                {
                    File.Copy(Properties.Settings.Default.PathDatabase, Properties.Settings.Default.PathBackupDatabase + '\\' + "Auto_Backup_" + DateTime.Now.ToString("dd MMMM yyyy") + ".db", true);
                    Properties.Settings.Default.LastBackup = DateTime.Now;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("Test");
                }
            }
        }

        #region Обработчики строки меню
        private void параметрыСтраницыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void предваToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exportFileName = "ExportFileTXT.txt";
            StreamWriter sw = new StreamWriter(exportFileName, true, Encoding.UTF8);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sw.Write(listView1.Items[i].Text + " ");
                sw.Write(listView1.Items[i].SubItems[1].Text + " ");
                sw.Write(listView1.Items[i].SubItems[2].Text + " ");
                sw.WriteLine(listView1.Items[i].SubItems[3].Text + " ");
            }
            sw.Close();

            MessageBox.Show("Экспорт в файл *.txt завершен");
        }

        private void экспортВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exportFileName = "ExportFileCSV.csv";
            StreamWriter sw = new StreamWriter(exportFileName, true, Encoding.UTF8);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sw.Write(listView1.Items[i].Text + ";");
                sw.Write(listView1.Items[i].SubItems[1].Text + ";");
                sw.Write(listView1.Items[i].SubItems[2].Text + ";");
                sw.WriteLine(listView1.Items[i].SubItems[3].Text + ";");
            }
            sw.Close();

            MessageBox.Show("Экспорт в файл *.csv завершен");
        }

        private void экспортВHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exportFileName = "ExportFileHTML " + DateTime.Now.ToString("dd MMMM yyyy") + ".html";

            if (File.Exists(exportFileName))
            {
                if (MessageBox.Show("Такой файл уже существует, желаете его перезаписать?", "Файл существует", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StreamWriter sw = new StreamWriter(exportFileName, false, Encoding.UTF8);

                    sw.Write("<html><head><meta http-equiv ='Content-Type' content ='text/html; charset=utf-8'>");
                    sw.Write("<title>Экспортированые данные WareHouseRelic</title></head><body><p>Данные экспортированы за " + DateTime.Now.ToString("dd MMMM yyyy") + " года.</p>");
                    sw.Write("<table border='1' width='70%' cellpadding='5' align='center'>");
                    sw.Write("<tr><th>Название монеты</th><th>Год выпуска</th><th>Тип метала</th><th>Монетный двор</th></tr>");

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        sw.Write("<tr><td>" + listView1.Items[i].Text + "</td>");
                        sw.Write("<td>" + listView1.Items[i].SubItems[1].Text + "</td>");
                        sw.Write("<td>" + listView1.Items[i].SubItems[2].Text + "</td>");
                        sw.Write("<td>" + listView1.Items[i].SubItems[3].Text + "</td></tr>");
                    }
                    sw.Write("</table></body></html>");

                    sw.Close();
                    MessageBox.Show("Файл перезаписан");
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(exportFileName, true, Encoding.UTF8);

                sw.Write("<html><head><meta http-equiv ='Content-Type' content ='text/html; charset=utf-8'>");
                sw.Write("<title>Экспортированые данные WareHouseRelic</title></head><body><p>Данные экспортированы за " + DateTime.Now.ToString("dd MMMM yyyy") + " года.</p>");
                sw.Write("<table border='1' width='70%' cellpadding='5' align='center'>");
                sw.Write("<tr><th>Название монеты</th><th>Год выпуска</th><th>Тип метала</th><th>Монетный двор</th></tr>");

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sw.Write("<tr><td>" + listView1.Items[i].Text + "</td>");
                    sw.Write("<td>" + listView1.Items[i].SubItems[1].Text + "</td>");
                    sw.Write("<td>" + listView1.Items[i].SubItems[2].Text + "</td>");
                    sw.Write("<td>" + listView1.Items[i].SubItems[3].Text + "</td></tr>");
                }
                sw.Write("</table></body></html>");

                sw.Close();
                MessageBox.Show("Экспорт в файл *.html завершен");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void создатьРезевкуюКопиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.PathBackupDatabase + '\\' + "Backup_" + DateTime.Now.ToString("dd MMMM yyyy") + ".db"))
            {
                if (MessageBox.Show("Такой файл уже существует, желаете его перезаписать?", "Файл существует", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Copy(Properties.Settings.Default.PathDatabase, Properties.Settings.Default.PathBackupDatabase + '\\' + "Backup_" + DateTime.Now.ToString("dd MMMM yyyy") + ".db", true);
                    MessageBox.Show("Создана резервная копия базы данных", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                File.Copy(Properties.Settings.Default.PathDatabase, Properties.Settings.Default.PathBackupDatabase + '\\' + "Backup_" + DateTime.Now.ToString("dd MMMM yyyy") + ".db", true);
                MessageBox.Show("Создана резервная копия базы данных", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void востановитьРезервнуюКопиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Odial = new OpenFileDialog();

            Odial.InitialDirectory = Properties.Settings.Default.PathBackupDatabase;
            Odial.Filter = "All files (*.*)|*.*|База данных SqlIte (*.db)|*.db";
            Odial.FilterIndex = 2;
            Odial.RestoreDirectory = true;
            Odial.ShowDialog();

            if (Odial.FileName != "")
            {
                File.Copy(Odial.FileName, Properties.Settings.Default.PathDatabase, true);
                MessageBox.Show("База данных востановлена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else 
            {
                MessageBox.Show("Файл не был выбран", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStatistics FStat = new FormStatistics();
            FStat.StartPosition = FormStartPosition.CenterParent;
            FStat.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings FSett = new FormSettings();
            FSett.StartPosition = FormStartPosition.CenterParent;
            FSett.ShowDialog();
        }

        private void просмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отправитьОтзывToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSendMail FormSM = new FormSendMail();
            FormSM.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout FAbout = new FormAbout();
            FAbout.ShowDialog();
        }
        #endregion

        #region Обработчики toolStrip
        //Обработчик окна добавления
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormAddCoin fAddC = new FormAddCoin();
            fAddC.StartPosition = FormStartPosition.CenterParent;
            fAddC.Owner = this;
            fAddC.ShowDialog();
        }

        //Обработчик окна редактирования
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                FormEditCoin fEitC = new FormEditCoin();
                fEitC.StartPosition = FormStartPosition.CenterParent;
                fEitC.Owner = this;
                fEitC.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не выбран елемент для редактирования", "Внимание");
            }
        }

        //Обработчик удаления записи
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                ClassCoins c = new ClassCoins();
                c.DeleteCoin(Convert.ToInt16(listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text));

                listView1.Items.Remove(listView1.Items[listView1.SelectedIndices[0]]);
            }
            else
            {
                MessageBox.Show("Не выбран елемент для удаления", "Внимание");
            }
        }

        //Обрамотчик окна карты
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Обработчики событий компонентов формы
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ClassCoins c = new ClassCoins();
            c.Getting(listView1, Convert.ToString(e.Node.Tag));
        }
        #endregion
    }
}
