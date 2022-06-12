using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{

    public class Class_TT
    {
        public static string strconn = "server=localhost;integrated security=true;initial catalog=DB_TT";

        public static DataTable ExecuteReader(string strsql)
        {
            SqlConnection Conn = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {
                {
                    var withBlock = Conn;
                    if (withBlock.State == ConnectionState.Open)
                        withBlock.Close();
                    withBlock.ConnectionString = strconn;
                    withBlock.Open();
                }
            }
            catch
            {

            }

            SqlDataAdapter da = new SqlDataAdapter(strsql, Conn);
            da.Fill(dt);
            da.Dispose();
            da = null/* TODO Change to default(_) if this is not a reference type */;
            SqlConnection.ClearAllPools();
            Conn.Close();
            Conn = null/* TODO Change to default(_) if this is not a reference type */;
            return dt;
        }

        // new

        public static void ExecuteNonQuery(string sqlcmd)
        {
            SqlConnection Conn = new SqlConnection();
            try
            {
                {
                    var withBlock = Conn;
                    if (withBlock.State == ConnectionState.Open)
                        withBlock.Close();
                    withBlock.ConnectionString = strconn;
                    withBlock.Open();
                }
            }

            catch
            {

            }

            SqlCommand Com = new SqlCommand();

            Com = new SqlCommand();
            {
                var withBlock = Com;
                // withBlock.CommandText = CommandType.Text;
                withBlock.CommandText = sqlcmd;
                withBlock.Connection = Conn;
                withBlock.ExecuteNonQuery();
            }

            Com.Dispose();
            SqlConnection.ClearAllPools();
            Conn.Close();
            Conn = null /* TODO Change to default(_) if this is not a reference type */;
        }


    }

}