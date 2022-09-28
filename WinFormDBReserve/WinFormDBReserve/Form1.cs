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
    public partial class Form1 : Form
    {
        public static string user_id =null;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=reserve;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void login_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            string sql = "SELECT * FROM user WHERE username = '"+ username.Text +"' AND password = '"+password.Text+"'";
            
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            MySqlDataReader result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                result.Read();
                user_id = result.GetValue(0).ToString();
                string user_name = result.GetValue(3).ToString()+" "+result.GetValue(4).ToString();
                MessageBox.Show("เข้าสู่ระบบสำเร็จ");
                Form3 home = new Form3(user_id, user_name);
                this.Hide();
                home.Show();
            }
            else {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านผิด");
            }
            conn.Close();

            
        }

        private void lb_register_Click_1(object sender, EventArgs e)
        {
            Form2 f2= new Form2();

            this.Hide();

            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
