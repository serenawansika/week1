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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=;database=reserve;charset=utf8;");
        public MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=reserve;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public void searchData(string valueToFind)
        {

            string searchQuery = "SELECT * FROM room WHERE CONCAT (Id,room,maximum,unit,price) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            searchData("");

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchData(txtSearch.Text);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string updateQuery = "DELETE FROM room WHERE id='" + this.textBox3.Text + "'";
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data has been Succesfully Delate");
            conn.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string updateQuery = "UPDATE room SET room = '" + this.txtrname.Text + "',maximum='" + this.txtmax.Text + "',unit='" + this.txtunit.Text + "',price='" + this.txtprice.Text + "'WHERE ID ='" + this.textBox3.Text + "'";
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data Update Succesfully");
            conn.Close();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string updateQuery = "INSERT INTO room (room,maximum,unit,price) VALUES ('" + this.txtrname.Text + "', '" + this.txtmax.Text + "', '" + this.txtunit.Text + "', '" + this.txtprice.Text + "')";
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data Insert Succesfully");
            conn.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form12_Load_1(object sender, EventArgs e)
        {

        }
    }
}
