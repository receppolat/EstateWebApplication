using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Data.OleDb;

namespace Emlak_Sitesi
{
    public class Global : System.Web.HttpApplication
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["ziyaretci"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["ziyaretci"] = (int)Application["ziyaretci"] + 1;
            Application.UnLock();
        }
        int kontrol = 0;
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string sorgu = "insert into sayac (ip) Values (@ip)";
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from sayac",conn);
            da.Fill(ds, "sayac");
            for(int i= 0; i<ds.Tables[0].Rows.Count;i++)
            {
                if (ds.Tables["sayac"].Rows[i]["ip"].ToString() == Request.ServerVariables["Remote_Addr"].ToString())
                {
                    kontrol = 1;
                }
                else
                    kontrol = 0;
            }
            if (kontrol == 0)
            {
                OleDbCommand komut = new OleDbCommand(sorgu, conn);
                komut.Parameters.AddWithValue("@ip", Request.ServerVariables["Remote_Addr"].ToString());
                komut.ExecuteNonQuery();
            }

            conn.Close();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["ziyaretci"] = (int)Application["ziyaretci"] - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application.Remove("ziyaretci");
        }
    }
}