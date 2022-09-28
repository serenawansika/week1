using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormDBReserve
{
    public partial class Form8 : Form
    {
        // menu photo slide
        public Form8()
        {
            InitializeComponent();
        }
        int count = 0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (count < 3)
            {
                pictureBox4.Image = imageList1.Images[count];
                count++;

            }
            else
            {
                count = 0;
            }
        }
        // menu photo slide
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (count < 3)
            {
                pictureBox5.Image = imageList2.Images[count];
                count++;

            }
            else
            {
                count = 0;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (count < 3)
            {
                pictureBox6.Image = imageList3.Images[count];
                count++;

            }
            else
            {
                count = 0;
            }
        }
        // link view menu
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sawsamsaicatering.com/wp-content/uploads/2022/01/STD-Buffet-No-Price_SawSamSai_2021.pdf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sawsamsaicatering.com/wp-content/uploads/2022/02/0_Cocktail-Wedding-Promotion_Sawsamsai_2021.pdf");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sawsamsaicatering.com/wp-content/uploads/2022/02/Chinese-Table-Price_SawSamSai_2021-NEW.pdf");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();

            this.Hide();

            f8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            this.Hide();

            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            this.Hide();
            f10.Show();
        }
    }
}
