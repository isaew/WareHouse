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
    public partial class FormAddCoin : Form
    {
        public FormAddCoin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Coin c = new Coin();
            c.AddNewCoin(textBox1.Text, Convert.ToInt16(textBox2.Text), comboBox1.Text, textBox3.Text);

            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                main.listView1.Items.Add(textBox1.Text);
                main.listView1.Items[main.listView1.Items.Count - 1].SubItems.Add(textBox2.Text);
                main.listView1.Items[main.listView1.Items.Count - 1].SubItems.Add(comboBox1.Text);
                main.listView1.Items[main.listView1.Items.Count - 1].SubItems.Add(textBox3.Text);
            }       
            this.Close();
        }
    }
}
