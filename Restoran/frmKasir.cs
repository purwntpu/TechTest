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
    public partial class frmKasir : Form
    {
        sqlconnection con = new sqlconnection();

        public frmKasir()
        {
            InitializeComponent();
        }

        private void frmKasir_Load(object sender, EventArgs e)
        {
            string query = "select A.harga,B.ikan, B.ayam, B.esteh, B.jeruk from " +
                "(SELECT * harga,row_number() over (order by harga) as row_num FROM tb_daftarmenu) as A " +
                "inner join (SELECT ikan ,row_number() over (order by val) as row_numikan " +
                "ikan ,row_number() over (order by ikan) as row_numikan " +
                "ayam ,row_number() over (order by ayam) as row_numayam " +
                "esteh ,row_number() over (order by esteh) as row_numesteh " +
                "jeruk ,row_number() over (order by jeruk) as row_numjeruk " +
                "FROM B) as B on  A.id=B.id ORDER BY A.harga";
            DataTable view = con.openTable(query);
          
            this.DG.DataSource = view;

            DataTable hh = con.openTable("select distinct table from tb_pesanan where status !='READY' order by table");
            for (int x = 0; x < hh.Rows.Count; x++)
            {
                comboBox1.Items.Add(hh.Rows[x][0].ToString().Trim());

            }

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string query = "select A.harga,B.ikan, B.ayam, B.esteh, B.jeruk from " +
                "(SELECT * harga,row_number() over (order by harga) as row_num FROM tb_daftarmenu) as A " +
                "inner join (SELECT ikan ,row_number() over (order by val) as row_numikan " +
                "ikan ,row_number() over (order by ikan) as row_numikan " +
                "ayam ,row_number() over (order by ayam) as row_numayam " +
                "esteh ,row_number() over (order by esteh) as row_numesteh " +
                "jeruk ,row_number() over (order by jeruk) as row_numjeruk " +
                "FROM B) as B on  A.id=B.id ORDER BY A.harga";
            DataTable view = con.openTable(query);
            int harga = 0;
           
            int total = 0, bayar = 0,kembali=0;
            for (int a = 0; a < view.Rows.Count; a++)
            {
                 harga += Convert.ToInt32(view.Rows[a]["harga"].ToString());
                
            }

            bayar = Convert.ToInt32(textBox1.Text.ToString());
            total = harga;
            kembali = bayar - total;
            textBox2.Text = kembali.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = comboBox1.Text.ToString();

            string query = "select * from tb_pesanan where table ='" + table + "'";
            DataTable qr = con.openTable(query);

            
        }
    }
}
