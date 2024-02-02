using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class DaftarPesanan : Form
    {
        string ikan = "";
        string ayam = "";
        string esteh = "";
        string jeruk = "";
        string table = "";
        sqlconnection con = new sqlconnection();
        public DaftarPesanan()
        {
            InitializeComponent();
        }

        private void DaftarPesanan_Load(object sender, EventArgs e)
        {
            DataTable hh = con.openTable("select distinct table from tb_pesanan where status !='READY' order by table");
            for (int x = 0; x < hh.Rows.Count; x++)
            {
                comboBox1.Items.Add(hh.Rows[x][0].ToString().Trim());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string table = this.comboBox1.GetItemText(this.comboBox1.SelectedItem).Trim();
            string query = "update tb_pesanan set status ='READY' where table ='" + table + "'";
            con.executeQuery(query);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = comboBox1.Text.ToString();

            string query = "select * from tb_pesanan where table ='" +table+"'";
            DataTable qr = con.openTable(query);

            textBox1.Text = qr.Rows[0][0].ToString();
            textBox2.Text = qr.Rows[0][1].ToString();
            textBox4.Text = qr.Rows[0][3].ToString();
            textBox3.Text = qr.Rows[0][2].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
             ikan = textBox1.Text.ToString();
             ayam = textBox2.Text.ToString();
             esteh = textBox4.Text.ToString();
             jeruk = textBox4.Text.ToString();
             table = comboBox1.Text.ToString();


            string query = "update tb_pesanan set ikan='" + ikan +"','" + ayam + "','" + esteh + "','" + jeruk  +"' where table ='" + table + "' and status !='DONE'";
            con.executeQuery(query);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ikan = textBox1.Text.ToString();
            ayam = textBox2.Text.ToString();
            esteh = textBox4.Text.ToString();
            jeruk = textBox4.Text.ToString();
            table = comboBox1.Text.ToString();


            string query = "delete from tb_pesanan where table ='" + table + "' and status !='DONE'";
            con.executeQuery(query);
        }
    }
}
