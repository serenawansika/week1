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
using System.Configuration;



namespace WinFormDBReserve
{
    
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=reserve;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form6(string name, string lastname)
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = databaseConnection();
                string selectQuery = "SELECT * FROM bank";
                conn.Open();
                MySqlCommand command = new MySqlCommand(selectQuery,conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  comboBank.Items.Add(reader.GetString("bankname"));
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void image1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string d = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string t = dateTimePicker2.Value.ToString("hh:mm");
            string bank = comboBank.Text.ToString();
            string sql = "INSERT INTO payment (Bankacc,Amount,Date,Time) VALUES ('" + bank + "', '" + amount.Text + "', '" + d + "','" + t + "')";
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("บันทึกสำเร็จ");
                this.Close();
                Form5 form5 = new Form5();
                form5.Show();
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาด");
            }

     

        }

        private void comboBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();

            this.Hide();

            f8.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            this.Hide();

            f2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            this.Hide();
            f10.Show();
        }
    }
}
