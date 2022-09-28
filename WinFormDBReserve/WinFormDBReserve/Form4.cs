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

    public partial class Form4 : Form
    {
        //string user_id = null;
        //string user_name = "";

        // private MySqlConnection connection;
        public MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=reserve;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            searchData("");
            
            try
            {
                MySqlConnection conn = databaseConnection();
                string selectQuery = "SELECT * FROM user";
                conn.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("id"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=reserve;charset=utf8;");

        public void searchData(string valueToFind)
        {
 
            string searchQuery = "SELECT * FROM reserve WHERE CONCAT (user_id,gift,time,food,bands,paystatus) LIKE '%"+valueToFind+"%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchData(txtSearch.Text);
        }

        private void update_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = databaseConnection();
            string pay = comboBox1.Text.ToString();
            string updateQuery = "UPDATE reserve SET paystatus = '" + pay + "'WHERE user_id ='"+ this.comboBox2.Text+"'";
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data Update Succesfully");
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string updateQuery = "DELETE FROM reserve WHERE user_id='" + this.comboBox2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data has been Succesfully Delate");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            this.Hide();
            f11.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            this.Hide();
            f12.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();

        }

        
    }
}
