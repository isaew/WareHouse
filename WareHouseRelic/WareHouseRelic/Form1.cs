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
            c.TestConnectToDb();
            c.DataOutput(listView1, "SELECT * FROM CoinTable");
            c.AddNewCoin("qwerty", 2000, "ytreq", "qazxsw", "INSERT INTO CoinTable (ID, NameCoin) values('6', 'Rublшл')");
            c.DataOutput(listView1, "SELECT * FROM CoinTable");
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

        }

        private void просмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отправитьОтзывToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
