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
    public partial class evozelligi : System.Web.UI.Page
    {
        public StringBuilder menuler = new StringBuilder();
        public StringBuilder resimler = new StringBuilder();
        public StringBuilder altevler = new StringBuilder();
        public StringBuilder yorumlar = new StringBuilder();
        public StringBuilder altmenu = new StringBuilder();
        public StringBuilder evler = new StringBuilder();
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        string id = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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

                if (!IsPostBack)
                    Session["q"] = id;

                if (Request.QueryString.Count > 0)
                    id = Request.QueryString[0];
                Session["q"] = id;


                conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
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


                altmenu.Append("<ul class='useful-links-nav d-flex align-items-center'>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    altmenu.Append("<li><a href='" + ds.Tables[0].Rows[i]["link"].ToString() + "'>" + ds.Tables[0].Rows[i]["baslik"].ToString() + "</a></li>");
                }
                altmenu.Append("</ul>");

                string sec = "select * from evler where evid=" + Session["q"];
                OleDbDataAdapter da4 = new OleDbDataAdapter(sec, conn);
                da4.Fill(ds3, "foto");

                resimler.Append(

                        "<img src='img/bg-img/" + ds3.Tables["foto"].Rows[0]["fotograf"].ToString() + "' alt=''>"
                    );

                OleDbDataAdapter da3 = new OleDbDataAdapter(sec, conn);
                da3.Fill(ds1, "ev");

                evler.Append(
                    "<div class='listings-content'>" +
                         "<div class='list-price'>" +
                               "<p>" + ds1.Tables["ev"].Rows[0]["fiyat"].ToString() + "</p>" +
                         "</div>" +
                    "</div>" +
                    "<h5>" + ds1.Tables["ev"].Rows[0]["tur"].ToString() + " | " + ds1.Tables["ev"].Rows[0]["sehir"].ToString() + "</h5>" +
                    "<p class='location'><img src='img/icons/location.png' alt=''>" + ds1.Tables["ev"].Rows[0]["adres"].ToString() + "</p>" +
                    "<p>" + ds1.Tables["ev"].Rows[0]["odasayisi"].ToString() + "+" + ds1.Tables["ev"].Rows[0]["salonsayisi"].ToString() + " | " + ds1.Tables["ev"].Rows[0]["ozellik"].ToString() + "<p>" +
                    "<p>" + ds1.Tables["ev"].Rows[0]["aciklama"].ToString() + "<p>" +
                   "<div class='property-meta-data d-flex align-items-end justify-content-between'>" +
                                    "<div class='new-tag'>" +
                                        "<img src='img/icons/new.png'>" +
                                    "</div>" +
                               "</div>"
                   );

                OleDbDataAdapter da2 = new OleDbDataAdapter("select * from evler", conn);
                da2.Fill(ds2, "evler");

                altevlerfonk();
            }
            catch { }
            
        }

        public void altevlerfonk()
        {
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                altevler.Append("<div class='single-featured-properties-slide'>" +
                                   " <a href='#'><img src='img/bg-img/" + ds2.Tables[0].Rows[i]["fotograf"].ToString() + "' alt=''></a>" +//burada fotografları veritabanında cekecegiz
                                "</div> ");
            }
        }

        protected void giris_Click(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                giris.Text = "Çıkış Yap";
                kayit.Visible = false;
                Session.Abandon();
                Response.Redirect("evozelligi.aspx?id="+Session["q"].ToString());

            }
            else
            {
                giris.Text = "Giriş Yap";
                kayit.Visible = true;
                Session["sayfa"] = "evozelligi";
                Response.Redirect("uye_giris.aspx");

            }
        }

        protected void kayit_Click(object sender, EventArgs e)
        {
            Session["sayfa"] = "evozelligi";
            Response.Redirect("uye_kayit.aspx");
        }
    }
}