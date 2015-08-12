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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.PathDatabase;
            textBox2.Text = Properties.Settings.Default.PathBackupDatabase;
            textBox3.Text = Properties.Settings.Default.PathExportFile;
            checkBox1.Checked = Properties.Settings.Default.BackupCopy;
            textBox4.Text = Convert.ToString(Properties.Settings.Default.TimeBetweenBackups);

            if (checkBox1.Checked)
            {
                textBox4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PathDatabase = textBox1.Text;
            Properties.Settings.Default.PathBackupDatabase = textBox2.Text;
            Properties.Settings.Default.PathExportFile = textBox3.Text;
            Properties.Settings.Default.BackupCopy = checkBox1.Checked;
            Properties.Settings.Default.TimeBetweenBackups = Convert.ToInt16(textBox4.Text);
            Properties.Settings.Default.Save();

            
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog Odial = new OpenFileDialog();

            Odial.InitialDirectory = @"..\..\cyber1.db";
            Odial.Filter = "All files (*.*)|*.*|База данных SqlIte (*.db)|*.db";
            Odial.FilterIndex = 2;
            Odial.RestoreDirectory = true;
            Odial.ShowDialog();

            if(Odial.FileName != "")
            {
                textBox1.Text = Odial.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Fdial = new FolderBrowserDialog();

            Fdial.RootFolder = Environment.SpecialFolder.UserProfile;
            Fdial.ShowNewFolderButton = true;
            Fdial.ShowDialog();

            MessageBox.Show(Fdial.SelectedPath);

            if (Fdial.SelectedPath != "")
            {
                textBox2.Text = Fdial.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Fdial = new FolderBrowserDialog();

            Fdial.RootFolder = Environment.SpecialFolder.UserProfile;
            Fdial.ShowNewFolderButton = true;
            Fdial.ShowDialog();

            MessageBox.Show(Fdial.SelectedPath);

            if (Fdial.SelectedPath != "")
            {
                textBox3.Text = Fdial.SelectedPath;
            }
        }
    }
}
