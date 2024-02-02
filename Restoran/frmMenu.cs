using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Restoran
{
    public partial class frmMenu : Form
    {
       
        public frmLogin flogin = new frmLogin();
        public frmDaftarMenu fdafmenu = new frmDaftarMenu();
        public frmKasir fkasir = new frmKasir();
        public frmMenu fmenu = new frmMenu();
        public DaftarPesanan dafpesanan = new DaftarPesanan();

        public frmMenu()
        {
            InitializeComponent();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            
            
           
            
            string fset = Directory.GetCurrentDirectory() + "\\setusr.dat";
            string[] setdata = File.ReadAllLines(fset);
            foreach (string baris in setdata)
            {
                string[] grp = baris.Split(';');
                toolStripStatusLabel1.Text = grp[0].ToString().Trim()+
                "-"+grp[1].ToString().Trim();
                if (grp[1].ToString().Trim() == "Administrator")
                {
                    daftarMenuToolStripMenuItem.Enabled = true;
                    daftarPesananToolStripMenuItem.Enabled = true;
                    kasirToolStripMenuItem.Enabled = true;
                   
                }
                if (grp[1].ToString().Trim() == "Kasir")
                {
                    daftarMenuToolStripMenuItem.Enabled = true;
                    daftarPesananToolStripMenuItem.Enabled = true;
                }
                if (grp[1].ToString().Trim() == "Pelayan")
                {
                    daftarMenuToolStripMenuItem.Enabled = true;
                    daftarPesananToolStripMenuItem.Enabled = true;
                }
                if (grp[1].ToString().Trim() == "Pemesan")
                {
                    daftarMenuToolStripMenuItem.Enabled = true;

                }
                
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void ProsesPolisStripMenuItem_Click(object sender, EventArgs e)
        {
     
           
        }

        private void consolidationToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }

      
        private void postingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            
        }

    
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin flogin = new frmLogin();
            this.Hide();
            flogin.ShowDialog();
        }

        
        private void manifestReprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        

        private void reconcileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void manifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void importAddMedikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void cetakPolisPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void uploadDataSftpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void importExcelAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       

        private void importExcelProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

       

        private void AccountingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importExcelHToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void importExcelOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void daftarMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunfrmDaftarMenu();
        }
        void RunDaftarPesanan()
        {
            Form fc = Application.OpenForms["DaftarPesanan"];
            if (fc == null)
            {
                toolStripProgressBar1.Value = 0;
                dafpesanan = new DaftarPesanan();
                dafpesanan.Show();
                dafpesanan.MdiParent = this;
                dafpesanan.Dock = DockStyle.None;
                toolStripProgressBar1.Value = 100;
                LayoutMdi(MdiLayout.ArrangeIcons);
            }

        }
        void RunfrmDaftarMenu()
        {
            Form fc = Application.OpenForms["frmDaftarMenu"];
            if (fc == null)
            {
                toolStripProgressBar1.Value = 0;
                fdafmenu = new frmDaftarMenu();
                fdafmenu.Show();
                fdafmenu.MdiParent = this;
                fdafmenu.Dock = DockStyle.None;
                toolStripProgressBar1.Value = 100;
                LayoutMdi(MdiLayout.ArrangeIcons);
            }

        }
        void RunfrmKasir()
        {
            Form fc = Application.OpenForms["frmKasir"];
            if (fc == null)
            {
                toolStripProgressBar1.Value = 0;
                fkasir = new frmKasir();
                fkasir.Show();
                fkasir.MdiParent = this;
                fkasir.Dock = DockStyle.None;
                toolStripProgressBar1.Value = 100;
                LayoutMdi(MdiLayout.ArrangeIcons);
            }

        }

        private void daftarPesananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunDaftarPesanan();
        }

        private void kasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunfrmKasir();
        }
     }
}
