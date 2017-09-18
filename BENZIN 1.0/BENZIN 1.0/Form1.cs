using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BENZIN_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Корпус:";
            label4.Text = "Колеса:";
            label6.Text = "Вартість:";
            label7.Text = "HP";
            label8.Text = "Паливо";

            button1.Text = "🛠";
            button2.Text = "⛽";
            button3.Text = "Поліцейський відділок";

            pictureBox1.Image = Image.FromFile("pic\\road.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            progressBar1.Value = 100;
            progressBar2.Value = 100;


        }
    }
}
