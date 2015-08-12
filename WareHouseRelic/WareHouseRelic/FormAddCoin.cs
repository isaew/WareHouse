using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            if (textBox1.Text != "")
            {
                ClassCoins c = new ClassCoins();
                c.AddNewCoin(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text);

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
            else
            {
                MessageBox.Show("Поля для ввода не заполнены", "Внимание");
            }
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

        //Обработчик выбора 1 фотографии
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            oDialog.Filter = "Изображение (*.jpeg, *.jpg , *.png)|*.jpeg; *.jpg; *.png";

            if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int NewWidth = 200;
                int MaxHeight = 200;

                System.Drawing.Image FullSizeImage = System.Drawing.Image.FromFile(oDialog.FileName);
                if (FullSizeImage.Width <= NewWidth)
                {
                    NewWidth = FullSizeImage.Width;
                }
                int NewHeight = FullSizeImage.Height * NewWidth / FullSizeImage.Width;
                if (NewHeight > MaxHeight)
                {
                    NewWidth = FullSizeImage.Width * MaxHeight / FullSizeImage.Height;
                    NewHeight = MaxHeight;
                }
                pictureBox1.Image = FullSizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
                FullSizeImage.Dispose();
                ///////////////////////////////////


            }
        }

        //Обработчик выбора 2 фотографии
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            oDialog.Filter = "Изображение (*.jpeg, *.jpg , *.png)|*.jpeg; *.jpg; *.png";

            if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int NewWidth = 200;
                int MaxHeight = 200;

                System.Drawing.Image FullSizeImage = System.Drawing.Image.FromFile(oDialog.FileName);
                if (FullSizeImage.Width <= NewWidth)
                {
                    NewWidth = FullSizeImage.Width;
                }
                int NewHeight = FullSizeImage.Height * NewWidth / FullSizeImage.Width;
                if (NewHeight > MaxHeight)
                {
                    NewWidth = FullSizeImage.Width * MaxHeight / FullSizeImage.Height;
                    NewHeight = MaxHeight;
                }
                pictureBox2.Image = FullSizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
                FullSizeImage.Dispose();
            }
        }
    }
}
