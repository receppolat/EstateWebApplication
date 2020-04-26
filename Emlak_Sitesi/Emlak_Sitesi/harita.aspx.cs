using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace Emlak_Sitesi
{
    public partial class harita : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        public string haritaa;

        void vericek()
        {
            ds.Clear();
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            string sec = "select * from menuler";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, conn);
            da.Fill(ds, "menuler");
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            vericek();      
            haritaa += "</li></ul>";
            for (int i= 0;i<ds.Tables["menuler"].Rows.Count;i++)
            {
                haritaa += "<ul type='square'><li><a href='" + ds.Tables["menuler"].Rows[i]["link"].ToString() + "'>"+ds.Tables["menuler"].Rows[i]["baslik"].ToString()+"</a>";
                haritaa += "</li></ul>";
            }
        }
    }
}