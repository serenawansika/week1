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
using System.Data.SqlClient;
using System.Configuration;

namespace WinFormDBReserve
{
    public partial class Form3 : Form
    {
        Form f3 = new Form9();
        public Form3()
        {

            InitializeComponent();
        }

        double price = 0;
        double sum = 0, vat = 0, value = 0, all = 0;
        double fp = 0.4, sp = 0.6, fourty = 0, sixty = 0;
        double bandpr = 0, totalfood = 0;
        int person;
        string gift = null;
        string user_id = null;
        string time = null;
        string menufood = null;
        string bands = null;
        string user_name = "";
        

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=reserve;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form3(string id, string name)
        {
            InitializeComponent();
            user_id = id;
            user_name = name;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM room";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();

            dataEquipment.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataEquipment.Rows[e.RowIndex];
            nameSelect.Text = row.Cells[1].Value.ToString();
            price = Convert.ToDouble(row.Cells[4].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = databaseConnection();
            string d = dateSelect.Value.ToString("dd/MM/yyyy");

            if (listPayment.Rows.Count <= 1)
            {
                MessageBox.Show("กรุณาเลือก Hall จัดงานมงคลสมรส");
                return;
            }

            if (gift == null)
            {
                MessageBox.Show("กรุณาเลือก GIFT SET");
                return;
            }

            if (time == null)
            {
                MessageBox.Show("กรุณาเลือกเวลา");
                return;
            }

            if (menufood == null)
            {
                MessageBox.Show("กรุณาเลือก Package Food");
                return;
            }
            if (bands == null)
            {
                MessageBox.Show("กรุณาเลือก Bands");
                return;
            }

            string sql = "INSERT INTO reserve ( user_id, total_amount, gift, date, time,food,bands,fourtydeposit,residuum,paystatus) VALUES ( '" + user_id + "', '" + textBoxForm2.Text + "', '" + gift + "', '" + d + "', '" + time + "', '" + menufood + "','" + bands + "','" + fourty + "','" + sixty + "','ยังไม่ได้ชำระเงิน')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();              // Execute the command
            long id = cmd.LastInsertedId;
            conn.Close();

            foreach (DataGridViewRow row in listPayment.Rows)
            {
                if (row.Cells[0].Value != null)
                {


                    string sqlReserve = "SELECT * FROM reserve JOIN reserve_history ON reserve.id = reserve_history.reserve_id WHERE reserve_history.room_name = '" + row.Cells[0].Value + "' AND reserve.date = '" + d + "' AND reserve.time = '" + time + "'";

                    MySqlCommand cmdRRR = new MySqlCommand(sqlReserve, conn);
                    conn.Open();
                    MySqlDataReader resultRRR = cmdRRR.ExecuteReader();
                    if (resultRRR.HasRows)
                    {
                        MessageBox.Show(row.Cells[0].Value + " ถูกจองแล้ว");
                        return;
                    }
                    conn.Close();
                }
            }


            foreach (DataGridViewRow row in listPayment.Rows)
            {
                if (row.Cells[0].Value != null)
                {


                    string sqlww = "SELECT * FROM room WHERE room = '" + row.Cells[0].Value + "'";

                    MySqlCommand cmdww = new MySqlCommand(sqlww, conn);
                    conn.Open();
                    MySqlDataReader resultww = cmdww.ExecuteReader();

                    double u = 0;
                    if (resultww.HasRows)
                    {
                        resultww.Read();
                        u = Double.Parse(resultww.GetValue(4).ToString());
                    }

                    u = u - Double.Parse(row.Cells[1].Value.ToString());
                    conn.Close();

                    string sqlUpdate = "UPDATE room SET unit = '" + u + "' WHERE room = '" + row.Cells[0].Value + "'";
                    MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn);
                    conn.Open();
                    cmdUpdate.ExecuteNonQuery();
                    conn.Close();


                    string sqlInsert = "INSERT INTO reserve_history (room_name, unit, reserve_id) VALUES ('" + row.Cells[0].Value + "', '" + row.Cells[1].Value + "', '" + id + "')";
                    MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn);
                    conn.Open();
                    cmdInsert.ExecuteNonQuery();
                    conn.Close();
                }
            }

            if (rows > 0)
            {
                MessageBox.Show("เพิ่มการจองสำเร็จ โดย คุณ" + user_name);
                //Form form4 = new Form4(user_id, user_name);
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการจอง");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gift = radioButton1.Text;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gift = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            gift = radioButton3.Text;
        }

        private void timeMorning_CheckedChanged(object sender, EventArgs e)
        {
            time = timeMorning.Text;
        }

        private void timeNight_CheckedChanged(object sender, EventArgs e)
        {
            time = timeNight.Text;
        }

        private void timeall_CheckedChanged(object sender, EventArgs e)
        {
            time = timeall.Text;
        }
        private void buffet_CheckedChanged(object sender, EventArgs e)
        {
            menufood = buffet.Text;

        }
        private void btncf_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
            {
                MessageBox.Show(" กรุณากรอกจำนวนแขกให้ครบถ้วน ");
                return;
            }
            else
            {

                if (buffet.Checked == true)
                {
                    menufood = buffet.Text;
                    value = 320;

                }
                else if (cocktail.Checked == true)
                {
                    menufood = cocktail.Text;
                    value = 600;
                }
                else if (table.Checked == true)
                {
                    menufood = table.Text;
                    value = 3200;
                }
                else if (nofood.Checked == true)
                {
                    menufood = nofood.Text;
                    value = 0;
                }

            }

            person = Convert.ToInt16(textBox4.Text);
            totalfood = value * person;
            pricefood.Text = totalfood.ToString();
        }

        private void jazz_CheckedChanged(object sender, EventArgs e)
        {
            bands = jazz.Text;
        }
        private void folksong_CheckedChanged(object sender, EventArgs e)
        {
            bands = folksong.Text;
        }
        private void classic_CheckedChanged(object sender, EventArgs e)
        {
            bands = classic.Text;
        }
        private void party_CheckedChanged(object sender, EventArgs e)
        {
            bands = party.Text;
        }
        private void acoustic_CheckedChanged(object sender, EventArgs e)
        {
            bands = acoustic.Text;
        }
        private void nobands_CheckedChanged(object sender, EventArgs e)
        {
            bands = nobands.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listPayment.Rows.RemoveAt(listPayment.CurrentRow.Index);
                textBox1.Clear();
                textBoxForm2.Clear();
                textBox3.Clear();
            }

            else
            {
                MessageBox.Show("Row Not Removed", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void add_Click(object sender, EventArgs e)
        {
            if (unit.Value == 1)
            {
                sum += price * (double)unit.Value;
                vat = sum * 0.07;
                textBox1.Text = sum.ToString();
                textBox3.Text = vat.ToString();
                listPayment.Rows.Add(nameSelect.Text, unit.Value.ToString(), price * (double)unit.Value);
                unit.Value = 0;
                nameSelect.Text = "";
            }
            else
            {
                MessageBox.Show("กรุณาใส่จำนวน HALL");
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            Form2 frm2 = new Form2();
            frm9.Date1 = dateSelect.Text;
            frm9.Hall = nameSelect.Text;
            frm9.Time = time.ToString();
            frm9.Band = bands.ToString();
            frm9.Food = menufood.ToString();
            frm9.Gift = gift.ToString();
            frm9.total = textBoxForm2.Text;
            frm9.fourty = fourty.ToString();
            frm9.sixty = sixty.ToString();
            frm9.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();

            this.Hide();

            f5.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void dateSelect_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnband_Click(object sender, EventArgs e)
        {
            if (jazz.Checked == true)
            {
                bandpr = 28000;
            }
            else if (folksong.Checked == true)
            {
                bandpr = 10000;
            }
            else if (classic.Checked == true)
            {
                bandpr = 12500;
            }
            else if (party.Checked == true)
            {
                bandpr = 20000;
            }
            else if (acoustic.Checked == true)
            {
                bandpr = 16000;
            }
            else if (nobands.Checked == true)
            {
                bandpr = 0;
            }
            textBox5.Text = bandpr.ToString();
        }


        private void btncfreal_Click(object sender, EventArgs e)
        {
            all = sum + vat + totalfood + bandpr;
            textBoxForm2.Text = all.ToString();
            fourty = all - (all * fp);
            textBox6.Text = fourty.ToString();
            sixty = all - (all * sp);
            textBox7.Text = sixty.ToString();

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}


