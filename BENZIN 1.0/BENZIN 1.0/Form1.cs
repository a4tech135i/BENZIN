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
        public Car vehicle;

        public Form1()
        {
            InitializeComponent();
            Wheels wh = new Wheels("deloren", 100, 1, 4, 100, 85);
            Corpus corp = new Corpus("deloren", 100, 1, 6, 5, 5);
            vehicle = new Car(wh,corp,177,100,100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Корпус:";
            label4.Text = "Колеса:";
            label6.Text = "Паливо:";

            label2.Text = "Гроші:";
            label3.Text = vehicle.getMoney() + "$";

            label5.Text = "Швидкість:";
            label7.Text = vehicle.getSpeed() + "km/h";
            

            button1.Text = "🛠";
            button2.Text = "⛽";
            button3.Text = "На заправку";

            pictureBox1.Image = Image.FromFile("pic\\giphy.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            progressBar1.Value = vehicle.getCorpus().getHP();
            progressBar2.Value = vehicle.getWheels().getHP();
            progressBar3.Value = vehicle.getFuel();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = !pictureBox1.Enabled;
        }
    }
}
