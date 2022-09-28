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
   
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1=new Form1();

            this.Hide();

            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4= new Form4();

            this.Hide();

            f4.Show();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }
        int count = 0;  
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < 6)
            { 
                pictureBox1.Image =  imageList1.Images[count];
                count++;

            }
            else
            {
                count = 0;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (count < 5)
            {
                pictureBox2.Image = imageList2.Images[count];
                count++;

            }
            else
            {
                count = 0;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (count < 6)
            {
                pictureBox3.Image = imageList3.Images[count];
                count++;

            }
            else
            {
                count = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            this.Hide();

            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                Form8 f8 = new Form8();

                this.Hide();

                f8.Show();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            this.Hide();
            f10.Show();
        }
    }
    }

