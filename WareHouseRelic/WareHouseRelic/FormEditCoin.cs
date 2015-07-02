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
    public partial class FormEditCoin : Form
    {
        public FormEditCoin()
        {
            InitializeComponent();
        }

        private void FormEditCoin_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

            int i = main.listView1.SelectedIndices[0];
            textBox1.Text = main.listView1.Items[i].Text;
            textBox2.Text = main.listView1.Items[i].SubItems[1].Text;
            comboBox1.Text = main.listView1.Items[i].SubItems[2].Text;
            textBox3.Text = main.listView1.Items[i].SubItems[3].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            int i = main.listView1.SelectedIndices[0];
            int id = Convert.ToInt16(main.listView1.Items[main.listView1.SelectedIndices[0]].SubItems[4].Text);

            ClassCoins c = new ClassCoins();
            c.EditCoin(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, id);

            if (main != null)
            {
                main.listView1.Items[i].Text = textBox1.Text;
                main.listView1.Items[i].SubItems[1].Text = textBox2.Text;
                main.listView1.Items[i].SubItems[2].Text = comboBox1.Text;
                main.listView1.Items[i].SubItems[3].Text = textBox3.Text;
            }
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassOutText.EnterLettersAndNumbers(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassOutText.EnterOnlyNumbers(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassOutText.EnterOnlyLettersCyrillicAlphabet(e);
        }
    }
}
