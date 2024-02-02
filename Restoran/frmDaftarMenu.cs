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
    public partial class frmDaftarMenu : Form
    {
        sqlconnection con = new sqlconnection();
        public frmDaftarMenu()
        {
            InitializeComponent();
        }

        private void frmDaftarMenu_Load(object sender, EventArgs e)
        {
            DataTable hh = con.openTable("select nama,stock,harga from tb_daftarmenu");
             
            for(int a=0; a< hh.Rows.Count; a++)
            {
                string nama = hh.Rows[a]["nama"].ToString();
                string stock = hh.Rows[a]["stock"].ToString();
                string harga = hh.Rows[a]["harga"].ToString();
                //string nama = "AYAM";
                //string stock = "0";
                //string harga = "";
                if(nama.Contains("IKAN") && stock =="0")
                {
                    textBox1.Enabled = false;
                }
                else if (nama.Contains("AYAM") && stock =="0")
                {
                    textBox2.Enabled = false;
                }
                else if(nama.Contains("ESTEH") && stock =="0")
                {
                    textBox4.Enabled = false;
                }
                else if(nama.Contains("JERUK") && stock =="0")
                {
                    textBox3.Enabled = false;
                }
                else if (nama.Contains("IKAN"))
                {
                    label3.Text = harga;

                }
                else if (nama.Contains("AYAM"))
                {
                    label4.Text = harga;

                }
                else if (nama.Contains("ESTEH"))
                {
                    label5.Text = harga;

                }
                else if (nama.Contains("JERUK"))
                {
                    label6.Text = harga;

                }
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ikan = textBox1.Text.ToString();
            string ayam = textBox2.Text.ToString();
            string esteh = textBox4.Text.ToString();
            string jeruk = textBox3.Text.ToString();
            string table = textBox5.Text.ToString();

            string query = "insert into tb_pesanan ([ayam],[ikan],[esteh],[jeruk],[table] values('" + ikan + "','" + ayam + "','" + esteh + "','" +jeruk+ "','" +table+ "'";
            con.executeQuery(query);
        

            string query1 = " UPDATE Orders SET ikan = ikan - '" + ikan +"',' ayam = ayam - '" + ayam + "', esteh = esteh - '" + esteh + "', jeruk = jeruk - '"+jeruk+"'";
            con.executeQuery(query1);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            MessageBox.Show("Pesanan Sudah dipesan, Mohon tunggu");
        }
    }
}
