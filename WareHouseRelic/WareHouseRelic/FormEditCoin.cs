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
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.YandexSatelliteMap;
            gMapControl1.Position = new GMap.NET.PointLatLng(Properties.Settings.Default.PositionLat, Properties.Settings.Default.PositionLng);
            gMapControl1.DragButton = MouseButtons.Left;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            Form1 main = this.Owner as Form1;

            int i = main.listView1.SelectedIndices[0];
            textBox1.Text = main.listView1.Items[i].Text;
            textBox2.Text = main.listView1.Items[i].SubItems[1].Text;
            comboBox1.Text = main.listView1.Items[i].SubItems[2].Text;
            textBox3.Text = main.listView1.Items[i].SubItems[3].Text;
            pictureBox1.Image = main.pictureBox1.Image;
            pictureBox2.Image = main.pictureBox2.Image;
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
            }
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            int i = main.listView1.SelectedIndices[0];
            int id = Convert.ToInt16(main.listView1.Items[i].SubItems[4].Text);

            ClassCoins c = new ClassCoins();
            c.EditCoin(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, id, pictureBox1.Image, pictureBox2.Image);

            if (main != null)
            {
                main.listView1.Items[i].Text = textBox1.Text;
                main.listView1.Items[i].SubItems[1].Text = textBox2.Text;
                main.listView1.Items[i].SubItems[2].Text = comboBox1.Text;
                main.listView1.Items[i].SubItems[3].Text = textBox3.Text;

                main.pictureBox1.Image = pictureBox1.Image;
                main.pictureBox2.Image = pictureBox2.Image;
            }
            this.Close();
        }


    }
}
