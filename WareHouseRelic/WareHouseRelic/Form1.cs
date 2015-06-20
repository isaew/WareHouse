using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            Coin c = new Coin();
            c.DataOutput(listView1);
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

        }

        private void экспортВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void экспортВHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void создатьРезевкуюКопиюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void востановитьРезервнуюКопиюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        //Обработчик окна редактирогвания
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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox.Show(Convert.ToString(treeView1.));
        }
    }
}
