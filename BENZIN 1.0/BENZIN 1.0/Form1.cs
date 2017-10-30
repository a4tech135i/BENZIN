using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace BENZIN_1._0
{
    public partial class Form1 : Form
    {
        public Car vehicle;
        public Save save;
        bool runing,broke;
        start_game start;
        main_menu menu;
        bool stance;
        public Form1(Save save1, Car vehicle1, start_game strt)
        {
            InitializeComponent();
            save = save1;
            vehicle = vehicle1;
            this.Text = "Назва сейву: " + save.getName() + " Складність: " + save.getComplexity();
            //Wheels wh = new Wheels("deloren", 100, 1, 4, 100, 85);
            //Corpus corp = new Corpus("deloren", 100, 1, 6, 5, 5);
            //vehicle = new Car(wh,corp,177,100,100);
            comboBox1.KeyPress += (sndr, eva) => eva.Handled = true;
            start = strt;
            menu = null;
            stance = false;
         }
        public Form1(Save save1, Car vehicle1, main_menu m)
        {
            InitializeComponent();
            save = save1;
            vehicle = vehicle1;
            this.Text = "Назва сейву: " + save.getName() + " Складність: " + save.getComplexity();
            //Wheels wh = new Wheels("deloren", 100, 1, 4, 100, 85);
            //Corpus corp = new Corpus("deloren", 100, 1, 6, 5, 5);
            //vehicle = new Car(wh,corp,177,100,100);

            comboBox1.KeyPress += (sndr, eva) => eva.Handled = true;
            stance = false;
            menu = m;
        }
        private void playSound(string path)
        {
            System.Media.SoundPlayer player =
                new System.Media.SoundPlayer();
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }

        public void loging(string message, int damage)
        {
            richTextBox1.AppendText( message + damage + " одиниць пошкодження!\n");
            richTextBox1.ScrollToCaret();
        }

        public void logging(string message)
        {
            richTextBox1.AppendText(message + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            runing = false;
            broke = false;
            label1.Text = "Корпус:";
            label4.Text = "Колеса:";
            label6.Text = "Паливо:";

            label2.Text = "Гроші:";
            label3.Text = Math.Round(vehicle.getMoney()) + "$";

            label5.Text = "Швидкість:";
            label7.Text = vehicle.getSpeed() + "km/h";

            label8.Text = "Журнал:";

            label9.Text = "Ремонтних наборів:" + vehicle.getCorpus().getRepairKits();
            label10.Text = "Каністр:" + vehicle.getCorpus().getFuelTanks();
            

            button1.Text = "";
            button2.Text = "";
            button3.Text = "На заправку";

            pictureBox1.Image = Image.FromFile("pic\\giphy.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "deloren")
                pictureBox2.Image = Image.FromFile("pic\\deloren-deloren.png");
            if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "zaporojec")
                pictureBox2.Image = Image.FromFile("pic\\deloren-zaporojec.png");
            if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "deloren")
                pictureBox2.Image = Image.FromFile("pic\\zaporojec-deloren.png");
            if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "zaporojec")
                pictureBox2.Image = Image.FromFile("pic\\zaporojec-zaporojec.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            comboBox1.Items.Add("Корпус");
            comboBox1.Items.Add("Колеса");
            comboBox1.SelectedIndex = 0;


            newProgressBar1.Value = vehicle.getCorpus().getHP();
            newProgressBar2.Value = vehicle.getWheels().getHP();
            newProgressBar3.Value = vehicle.getFuel();

            newProgressBar1.Maximum = 100;
            newProgressBar2.Maximum = 100;
            newProgressBar3.Maximum = vehicle.getMaxFuel();

            pictureBox1.Enabled = false;
            
            timer1.Interval = 1000;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (broke && vehicle.getFuel() != 0) logging("Ваша машина зламана і не може продовжувати рух.");
            else if (broke && vehicle.getFuel() == 0) logging("Ваш паливний бак порожній і ви не можете продовжувати рух.");
            else
            {
                if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "deloren")
                    pictureBox2.Image = Image.FromFile("pic\\deloren-deloren.png");
                if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "zaporojec")
                    pictureBox2.Image = Image.FromFile("pic\\deloren-zaporojec.png");
                if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "deloren")
                    pictureBox2.Image = Image.FromFile("pic\\zaporojec-deloren.png");
                if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "zaporojec")
                    pictureBox2.Image = Image.FromFile("pic\\zaporojec-zaporojec.png");
                if (button3.Text != "На дорогу")
                {
                    if (e.KeyCode == Keys.W)
                    {
                        if (!runing)
                        {
                            runing = true;
                            timer1.Start();
                            pictureBox1.Enabled = true;

                        }
                        label7.Text = vehicle.speedUp().ToString() + "km/h";
                        if (vehicle.getSpeed() != vehicle.getMaxSpeed()) timer1.Interval -= 3;
                    }
                    else if (e.KeyCode == Keys.S)
                    {
                        label7.Text = vehicle.speedDown().ToString() + "km/h";
                        if (vehicle.getSpeed() == 0)
                        {
                            timer1.Stop();
                            runing = false;
                            pictureBox1.Enabled = false;
                        }
                        else timer1.Interval += 3;
                    }
                    else if (e.KeyCode == Keys.E)
                    {
                        //System.Media.SystemSounds.Beep.Play();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int[] log=vehicle.move();
            if (log[0] > 0) loging("Ви наїхали на єнота! Ваші колеса отримали ", log[0]);
            if (log[1] > 0) loging("Єнот покусав колеса! Ваші колеса отримали ", log[1]);
            if (log[2] > 0) loging("Ви збили барана! Ваш корпус отримав ", log[2]);
            if (log[3] > 0) loging("Баран буцнув бампер! Ваш корпус отримав ", log[3]);
            

            if (vehicle.getWheels().getHP() <= 0)
            {
                if (vehicle.getCorpus().getRepairKits() != 0) logging("Ваші колеса зламались! Відремонтуйте їх.");
                else
                {
                    logging("Ваші колеса зламались! Ваш шлях закінчується тут...");
                    button3.Enabled = false;
                    playSound("sounds\\OHNO.wav");
                }
                if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "deloren")
                    pictureBox2.Image = Image.FromFile("pic\\deloren-deloren-broken.png");
                if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "zaporojec")
                    pictureBox2.Image = Image.FromFile("pic\\deloren-zaporojec-broken.png");
                if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "deloren")
                    pictureBox2.Image = Image.FromFile("pic\\zaporojec-deloren-broken.png");
                if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "zaporojec")
                    pictureBox2.Image = Image.FromFile("pic\\zaporojec-zaporojec-broken.png");
                pictureBox1.Enabled = false;
                broke = true;
                runing = false;
                label7.Text = vehicle.stop().ToString()+"km/h";
                timer1.Stop();
            }
            if (vehicle.getCorpus().getHP() <= 0)
            {
                if (vehicle.getCorpus().getRepairKits() != 0) logging("Ваш корпус зламався! Відремонтуйте його.");
                else
                {
                    logging("Ваші колеса зламались! Ваш шлях закінчується тут...");
                    button3.Enabled = false;
                    playSound("sounds\\OHNO.wav");
                }
                if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "deloren")
                    pictureBox2.Image = Image.FromFile("pic\\deloren-deloren-broken.png");
                if (vehicle.getCorpus().getName() == "deloren" && vehicle.getWheels().getName() == "zaporojec")
                    pictureBox2.Image = Image.FromFile("pic\\deloren-zaporojec-broken.png");
                if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "deloren")
                    pictureBox2.Image = Image.FromFile("pic\\zaporojec-deloren-broken.png");
                if (vehicle.getCorpus().getName() == "zaporojec" && vehicle.getWheels().getName() == "zaporojec")
                    pictureBox2.Image = Image.FromFile("pic\\zaporojec-zaporojec-broken.png");
                pictureBox1.Enabled = false;
                broke = true;
                runing = false;
                label7.Text = vehicle.stop().ToString() + "km/h";
                timer1.Stop();
            }
            if (vehicle.getFuel() == 0)
            {
                if (vehicle.getCorpus().getFuelTanks() != 0) logging("У вас закінчилось пальне! Заправте паливний бак.");
                else
                {
                    logging("У вас закінчилось пальне! Ваш шлях закінчується тут...");
                    button3.Enabled = false;
                    playSound("sounds\\OHNO.wav");
                }

                
                pictureBox1.Enabled = false;
                broke = true;
                runing = false;
                label7.Text = vehicle.stop().ToString() + "km/h";
                timer1.Stop();
            }

            label3.Text = Math.Round(vehicle.getMoney()).ToString() + "$";

            newProgressBar1.Value = vehicle.getCorpus().getHP();
            newProgressBar2.Value = vehicle.getWheels().getHP();
            newProgressBar3.Value = vehicle.getFuel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (stance)
            {
                try
                {
                    vehicle.buyRepairKit();
                    label9.Text = "Ремонтних наборів:" + vehicle.getCorpus().getRepairKits();
                    label3.Text = Math.Round(vehicle.getMoney()).ToString() + "$";
                    vehicle.repairWheels();
                    vehicle.repairCorpus();
                    newProgressBar1.Value = vehicle.getCorpus().getHP();
                    newProgressBar2.Value = vehicle.getWheels().getHP();
                    logging("Ви купили ремонтний комплект. В подарунок ви отримали повний ремонт автомобіля!");
                    broke = false;
                }
                catch (Exception exc)
                {
                    if (exc.Message == "noPlaceForKit")
                        logging("У вас немає місця для ще одного ремонтного набору");
                }
            }
            else
            {
                if (vehicle.getCorpus().getRepairKits() != 0)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            if (vehicle.getCorpus().getHP() == 100)
                            {
                                logging("Корпус не потребує ремонту!");
                                return;
                            }
                            else
                            {
                                vehicle.getCorpus().repair(20);
                                vehicle.getCorpus().useRepairKit();
                                newProgressBar1.Value = vehicle.getCorpus().getHP();
                                logging("Ви відремонтували корпус за допомогою ремонтного набору");
                                if (broke && vehicle.getCorpus().getHP() == 0 && vehicle.getWheels().getHP() != 0 && vehicle.getFuel() != 0) broke = false;
                                else if (broke && vehicle.getCorpus().getRepairKits() == 0) logging("Ви використали всі ремонтні набори! Ваш шлях закінчується тут...");
                            }
                            break;
                        case 1:
                            if (vehicle.getWheels().getHP() == 100)
                            {
                                logging("Колеса не потребують ремонту!");
                                return;
                            }
                            else
                            {
                                vehicle.getWheels().repair(20);
                                vehicle.getCorpus().useRepairKit();
                                newProgressBar2.Value = vehicle.getWheels().getHP();
                                logging("Ви відремонтували колеса за допомогою ремонтного набору");
                                if (broke && vehicle.getWheels().getHP() != 0 && vehicle.getCorpus().getHP() != 0 && vehicle.getFuel() != 0) broke = false;
                                else if (broke && vehicle.getCorpus().getRepairKits() == 0) logging("Ви використали всі ремонтні набори! Ваш шлях закінчується тут...");
                            }
                            break;
                    }
                    label9.Text = "Ремонтних наборів:" + vehicle.getCorpus().getRepairKits();

                }
                else logging("У вас немає ремонтних наборів!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stance)
            {
                try
                {
                    vehicle.buyFuelTank();
                    label10.Text = "Каністр:" + vehicle.getCorpus().getFuelTanks();
                    label3.Text = Math.Round(vehicle.getMoney()).ToString() + "$";
                    vehicle.refuel();
                    newProgressBar3.Value = vehicle.getFuel();
                    logging("Ви купили Каністру з бензином. В подарунок ви отримали заправку бака!");
                    broke = false;
                }
                catch (Exception exc)
                {
                    if (exc.Message == "noPlaceForTank")
                        logging("У вас немає місця для ще однієї каністри");
                }

            }
            else
            {
                if (vehicle.getCorpus().getFuelTanks() != 0)
                {
                    if (vehicle.getFuel() == vehicle.getMaxFuel())
                    {
                        logging("Паливний пак повний!");
                        return;
                    }
                    else
                    {
                        vehicle.refuelFromTank();
                        newProgressBar3.Value = vehicle.getFuel();
                        logging("Ви заправились з каністри з бензином.");
                        if (broke && vehicle.getWheels().getHP() != 0 && vehicle.getCorpus().getHP() != 0 && vehicle.getFuel() != 0) broke = false;
                    }
                    label10.Text = "Каністр:" + vehicle.getCorpus().getFuelTanks();
                }
                else logging("У вас немає каністр з бензином!");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (start != null)
                start.closeAll();
            else menu.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            stance = !stance;
            label11.Visible = stance;
            label12.Visible = stance;
            comboBox1.Visible = !stance;
            if (stance)
            {
                button3.Text = "На дорогу";
                label7.Text = vehicle.stop().ToString() + "km/h";
                timer1.Stop();
                runing = false;
                pictureBox1.Image = Image.FromFile("pic\\gasStation.jpg");
                pictureBox1.Enabled = false;
            }
            else
            {
                button3.Text = "На заправку";
                pictureBox1.Image = Image.FromFile("pic\\giphy.gif");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Save_game a = new Save_game(vehicle,save);
            if (a.getCar().getFuel() == 0 || a.getCar().getCorpus().getHP() == 0 || a.getCar().getWheels().getHP() == 0)
            {
                MessageBox.Show("Ви не можете зберегти гру, якщо ваша машина не може рухатись!");
                return;
            }
            FileStream fs = new FileStream(a.getS().getName() + ".data", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, a);
            MessageBox.Show("Збережено");
            fs.Close();
        }

    }
}
