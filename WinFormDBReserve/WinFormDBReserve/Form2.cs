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
using System.Text.RegularExpressions;

namespace WinFormDBReserve
{
    public partial class Form2 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=reserve;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {



            if (username.Text == "" || password.Text == "" || name.Text == "" || lastname.Text == "" || phone.Text == "" || email.Text == "" || location.Text == "") {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน");
                return;
            }

            if (email.Text.IndexOf("@") == -1 || email.Text.IndexOf(".com") == -1) {
                MessageBox.Show("E-mail ใส่่ไม่ถูกต้อง");
                return;
            }

            foreach (char ch in name.Text) {
                if ( !(((int)ch >= 65 && (int)ch <= 90) || ((int)ch >= 97 && (int)ch <= 122)) ) {
                    MessageBox.Show("ใส่ได้เพียงตัวอักษรเท่านั้น");
                    return;
                }
                
            }

            foreach (char ch in lastname.Text)
            {
                if (!(((int)ch >= 65 && (int)ch <= 90) || ((int)ch >= 97 && (int)ch <= 122)))
                {
                    MessageBox.Show("ใส่ได้เพียงตัวอักษรเท่านั้น");
                    return;
                }
             

            }

            


            MySqlConnection conn = databaseConnection();
            string sql = "INSERT INTO user ( username, password, name, lastname,phone, location, email) VALUES ( '"+username.Text+"', '"+password.Text+"', '"+name.Text+"', '"+lastname.Text+ "','" + phone.Text + "', '" + location.Text+"', '"+email.Text+"')";
            
            MySqlCommand cmd = new MySqlCommand(sql,conn);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("เพิ่มผู้ใช้สำเร็จ");
                this.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else {
                MessageBox.Show("เกิดข้อผิดพลาด");
            }
        }
        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 f5= new Form5();
            f5.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
