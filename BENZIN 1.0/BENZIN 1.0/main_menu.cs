using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// kostya za ZOSH
namespace BENZIN_1._0
{
    public partial class main_menu : Form
    {

        public main_menu()
        {
            InitializeComponent();
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
    }
}
