using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDBReserve
{
    public partial class Form9 : Form
    {
       public string Date,Hall,Date1,Time,Band,Food,Gift,phone,mail,total,fourty,sixty;

        private void label34_Click(object sender, EventArgs e)
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
            this.Close();
            Form6 f6 = new Form6();
            f6.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
        }

  

        private void label31_Click(object sender, EventArgs e)
        {

        }

        public Form9()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
            
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.MarginBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
        private Bitmap memoryimg;

        private void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));

        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Print");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            labeldatenow.Text = Date;
            labeldate.Text = Date1;
            labeltime.Text = Time;
            labelband.Text = Band;
            labelfood.Text = Food;
            labelgift.Text = Gift;
            labeltotal.Text = total;
            labelfourty.Text = fourty;
            labelsixty.Text = sixty;
        }
    }
}
