using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace BENZIN_1._0
{
    public partial class main_menu : Form
    {

        public main_menu()
        {
            InitializeComponent();
            button2.Click += button2_Click;
            openFileDialog1.Filter = "All files(*.*)|*.*";
        }

        private void main_menu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start_game mf = new start_game(this);
            this.Hide();
            mf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save_game a1;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter bf = new BinaryFormatter();
            a1 = (Save_game)bf.Deserialize(fs);
            fs.Close();
            MessageBox.Show("Завантажено");
            Form1 f1 = new Form1(a1.getS(), a1.getCar(), this);
            this.Hide();
            f1.ShowDialog();
            
        }
    }
}
