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
    public partial class Form10 : Form
    {
        public static string admin_id = null;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=reserve;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            string sql = "SELECT * FROM admin WHERE name_admin = '"+ username.Text +"' AND pass_admin = '"+password.Text+"'";
            
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            MySqlDataReader result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ");
                this.Close();
                Form4 f4 = new Form4();
                f4.Show();
            }
            else {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านผิด");
            }
            conn.Close();

        }
    }
}
