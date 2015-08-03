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
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            ClassCoins c = new ClassCoins();
            label2.Text = c.GettingStatistics("SELECT COUNT(id) FROM 'example';");
            label4.Text = c.GettingStatistics("SELECT COUNT(id) FROM 'example' WHERE year > '1682' AND year < '1917';");
            label6.Text = c.GettingStatistics("SELECT COUNT(id) FROM 'example' WHERE year > '1921' AND year < '1991';");
            label8.Text = c.GettingStatistics("SELECT COUNT(id) FROM 'example'  WHERE year > '1991';");
        }
    }
}
