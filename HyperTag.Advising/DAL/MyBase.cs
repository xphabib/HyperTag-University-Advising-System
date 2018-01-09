using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hypertag.Advising.DAL
{
    abstract class MyBase
    {   

        public virtual bool Common()
        {
            return false;
        }
        public string Error { get; set; }

        protected SqlConnection cn = new SqlConnection();
        protected bool Connection()
        {
            if (cn.State == System.Data.ConnectionState.Open)
                return true;

            cn.ConnectionString = Hypertag.Advising.Properties.Settings.Default.MyCon;
            try
            {
                cn.Open();
                return true;
            }
            catch(Exception ex)
            {
                Error = ex.Message;
            }
            return false;
        }

        public string Search { get; set; }
        protected SqlCommand Command { get; set; }
        protected SqlDataReader MyReader { get; set; }

        protected SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            if (!Connection())
                return null;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        protected SqlCommand MyCommand(string SQL)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = SQL;
            return cmd;
        }

        protected DataSet ExecuteDataSet(string SQL)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = cn;
            if (!Connection())
                return new DataSet();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        protected DataSet ExecuteDataSet(SqlCommand cmd)
        {
            if (!Connection())
                return new DataSet();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        protected bool Execute(SqlCommand cmd)
        {
            if (!Connection())
                return false;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;

                // File writter here


                return false;
            }
        }

        public bool Database( string name)
        {
            Command = MyCommand("create database " + name);
            return Execute(Command);
        }

    }
}
