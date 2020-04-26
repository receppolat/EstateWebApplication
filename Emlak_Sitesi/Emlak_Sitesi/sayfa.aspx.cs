using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace Emlak_Sitesi
{
    public partial class sayfa : System.Web.UI.Page
    {
        public StringBuilder menuler = new StringBuilder();
        public StringBuilder resimler = new StringBuilder();
        public StringBuilder sonevler = new StringBuilder();
        public StringBuilder yorumlar = new StringBuilder();
        public StringBuilder altmenu = new StringBuilder();
        public StringBuilder altevler = new StringBuilder();
        public string menubaslik;
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds2 = new DataSet();
        string id="";
        public void altevlerfonk()
        {
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                altevler.Append("<div class='single-featured-properties-slide'>" +
                                   " <a href='#'><img src='img/bg-img/" + ds2.Tables[0].Rows[i]["fotograf"].ToString() + "' alt=''></a>" +//burada fotografları veritabanında cekecegiz
                                "</div> ");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from evler", conn);

            da2.Fill(ds2, "evler");

            if (Session["uye"] != null)
            {
                giris.Text = "Çıkış Yap";
                kayit.Visible = false;
            }
            else
            {
                giris.Text = "Giriş Yap";
                kayit.Visible = true;

            }
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from menuler", conn);
            da.Fill(ds, "menuler");
            if (ds.Tables[0].Rows.Count > 0)
            {
                menuler.Append("<ul>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    menuler.Append("<li>");
                    menuler.Append("<a href='" + ds.Tables[0].Rows[i]["link"] + "'>");
                    menuler.Append(ds.Tables[0].Rows[i]["baslik"]);
                    menuler.Append("</a></li>");
                }
                menuler.Append("</ul>");
            }
            altevlerfonk();

            if (Request.QueryString.Count > 0)
                id = Request.QueryString[0];
            Session["q2"] = id;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables["menuler"].Rows[i]["link"].ToString() == "sayfa.aspx?id=" + Session["q2"].ToString())
                    Label1.Text = ds.Tables["menuler"].Rows[i]["baslik"].ToString();
            }
        }

        protected void giris_Click(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                giris.Text = "Çıkış Yap";
                kayit.Visible = false;
                Session.Abandon();
                Response.Redirect("index.aspx");

            }
            else
            {
                giris.Text = "Giriş Yap";
                kayit.Visible = true;
                Session["sayfa"] = "index";
                Response.Redirect("uye_giris.aspx");

            }
        }

        protected void kayit_Click(object sender, EventArgs e)
        {
            Session["sayfa"] = "index";
            Response.Redirect("uye_kayit.aspx");
        }
    }
}