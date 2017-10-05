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
    public partial class start_game : Form
    {
        public Car vehicle;
        double dengi=500;
        double sloj = 500;
        double cost_rep = 30;
        double cost_ben = 20;
        int kilk_kanistr=0;
        int kilk_instrumentiv=0;
        main_menu menu;

        public start_game(main_menu mn)
        {
            InitializeComponent();
            comboBox1.KeyPress += (sndr, eva) => eva.Handled = true;
            menu = mn;
        }
        public void closeAll()
        {
            menu.Close();
            this.Close();
        }

        private void start_game_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main_menu mm = new main_menu();
            this.Hide();
            mm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) { label3.Text = "500$"; sloj = 500; dengi = 500; cost_ben = 20; cost_rep = 30; kilk_instrumentiv = 0; kilk_kanistr = 0; label11.Text = "Кількість стартовий каністр(" + cost_ben + "$):"; label13.Text = "Кількість стартових інструментів(:" + cost_rep + "$):"; }
            else if (comboBox1.SelectedIndex == 1) { label3.Text = "400$"; sloj = 400; dengi = 400; cost_ben = 25; cost_rep = 35; kilk_instrumentiv = 0; kilk_kanistr = 0; label11.Text = "Кількість стартовий каністр(" + cost_ben + "$):"; label13.Text = "Кількість стартових інструментів(:" + cost_rep + "$):"; }
            else if (comboBox1.SelectedIndex == 2) { label3.Text = "300$"; sloj = 300; dengi = 300; cost_ben = 30; cost_rep = 40; kilk_instrumentiv = 0; kilk_kanistr = 0; label11.Text = "Кількість стартовий каністр(" + cost_ben + "$):"; label13.Text = "Кількість стартових інструментів(:" + cost_rep + "$):"; }
            else { label3.Text = "0$"; dengi = 0; sloj = 0; cost_ben = 600; cost_rep = 600; kilk_instrumentiv = 0; kilk_kanistr = 0; label11.Text = "Кількість стартовий каністр(" + cost_ben + "$):"; label13.Text = "Кількість стартових інструментів(:" + cost_rep + "$):"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                MessageBox.Show("Введіть ім`я сейву.");
            }
            else
            {
                String name_save = textBox1.Text.ToString();
                String complexity = comboBox1.SelectedItem.ToString();

                
                Wheels wh = new Wheels("deloren", 100, 1, 4, 100, 85);
                Corpus corp = new Corpus("deloren", 100, 1, 6, kilk_kanistr,kilk_instrumentiv, 5, 5 );
                vehicle = new Car(wh, corp, 177, 100, dengi);

                Save save = new Save(name_save, complexity);

                Form1 f1 = new Form1(save, vehicle, this);
                this.Hide();
                f1.ShowDialog();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (kilk_kanistr != 0)
            {
                kilk_kanistr--;
                label14.Text = kilk_kanistr.ToString();
                dengi += cost_ben;
                label4.Text = (sloj-dengi).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dengi >= cost_ben)
            {
                kilk_kanistr++;
                label14.Text = kilk_kanistr.ToString();
                dengi -= cost_ben;
                label4.Text = (sloj - dengi).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dengi >= cost_rep)
            {
                kilk_instrumentiv++;
                label15.Text = kilk_instrumentiv.ToString();
                dengi -= cost_rep;
                label4.Text = (sloj - dengi).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (kilk_instrumentiv != 0)
            {
                kilk_instrumentiv--;
                dengi += cost_rep;
                label15.Text = kilk_instrumentiv.ToString();
                label4.Text = (sloj - dengi).ToString();
            }
        }
    }
}
