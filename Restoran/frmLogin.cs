using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace Restoran
{
    public partial class frmLogin : Form
    {
        public string tuser = "user";
        public string tuserid = "0003";
        public string tgroup = "";
        sqlconnection con = new sqlconnection();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUserName.Text = tgroup;
            txtUserPass.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUserPass.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }

        }

       private void button1_Click(object sender, EventArgs e)
        {
            tuser  = txtUserName.Text.Trim();
            string tpass = txtUserPass.Text.Trim();
            string qrl = "SELECT user_id,user_name,user_pass,user_grp,user_nonaktif FROM tb_admin "+
            "WHERE user_name = '"+ tuser.ToUpper() +"' AND user_pass='"+tpass.ToUpper()+"'" ;
            DataTable tbluser = con.openTable(qrl);
            if (tbluser.Rows.Count > 0)
            {
                tgroup = tbluser.Rows[0]["user_grp"].ToString().Trim();
                string fset = Directory.GetCurrentDirectory() + "\\setusr.dat";
                using (StreamWriter sw = new StreamWriter(fset,false))
                {
                    sw.WriteLine(tuser+";"+tgroup);
                    sw.Close();
                }
                frmMenu fGS = new frmMenu();
                this.Hide();
                fGS.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Access Denied!", "Login Failed", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

       private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
       {
           Application.Exit();
       }

       private void label1_Click(object sender, EventArgs e)
       {

       }
    }
}
