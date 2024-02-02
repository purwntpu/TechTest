using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Reflection;
using System.Windows.Forms;
namespace Restoran
{
    class sqlconnection
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        static SqlTransaction tran;
        string vNoman = "";
        
        static string constr = "Data Source=LAPTOP-U7QOHP09\\SQLEXPRESS;Initial Catalog=Restoran;Integrated Security=True";

        //DESKTOP-A1F54SM\SQLEXPRESS        DESKTOP-QI6L7D8\\SQLExpress
        DataTable dt;

        public void connection()
        {
            con = new SqlConnection(constr);

            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
        public void buatdir(string pathdir)
        {
            if (!Directory.Exists(pathdir))
            {
                Directory.CreateDirectory(pathdir);
            }
        }
        public void dobeldir(string pathdir)
        {
            if (!Directory.Exists(pathdir))
            {
                Directory.CreateDirectory(pathdir);
            }
            else if(Directory.Exists(pathdir))
            {
                Directory.CreateDirectory(pathdir);
            }
        }

        public DataTable openTable(string query)
        {
            //select
            con = new SqlConnection(constr);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }

            con.Open();

            dt = new DataTable();
            adapter = new SqlDataAdapter(query, constr);
            adapter.Fill(dt);

            con.Close();
            return dt;
        }

      
        public void executeQuery(string query)
        {
            con = new SqlConnection(constr);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }

            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandText = query;
            //reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            con.Close();
        }

       
        public void Transactionbegin()
        {
            con = new SqlConnection(constr);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            cmd = con.CreateCommand();
            tran = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = tran;
        }
        public void executeQuerybegin(string query)
        {
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }

        public void committran()
        {

            tran.Commit();
            con.Close();
        }

        public void rollbacktran()
        {
            tran.Rollback();
            con.Close();
        }


        //pakai yg ini, penambahan produk
       
        
        public void DBFexecuteQuery(string query)
        {
            con = new SqlConnection(constr);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }

            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandText = query;
            //reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
