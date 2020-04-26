using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace Emlak_Sitesi
{
    public partial class duyurular : System.Web.UI.Page
    {
        public StringBuilder menuler = new StringBuilder();
        public StringBuilder duyuru = new StringBuilder();
        public StringBuilder evler = new StringBuilder();
        public StringBuilder altmenu = new StringBuilder();
        public StringBuilder altevler = new StringBuilder();
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();
        int sayac = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] == null)
            {
                girisd.Text = "Giriş Yap";
                kayitd.Visible = true;       
            }
            else
            {
                girisd.Text = "Çıkış Yap";
                kayitd.Visible = false;
            }


            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            OleDbDataAdapter da = new OleDbDataAdapter("select * from menuler", conn);
            da.Fill(ds, "menuler");

            if (!IsPostBack)
                Session["sayacyorum"] = sayac;

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
            OleDbDataAdapter da3 = new OleDbDataAdapter("select * from duyurular", conn);
            da3.Fill(ds4, "duyuru");
       
        

            for (int i=0;i<ds4.Tables[0].Rows.Count;i++)
            {
                duyuru.Append("<div class='single-blog-area mb-50'>" +
                                 "<div class='blog-post-thumbnail'>" +
                                    "<img src='img/blog-img/" + ds4.Tables["duyuru"].Rows[i]["fotograf"].ToString() + "' alt=''>" +
                                 "</div>" +
                                 "<div class='post-content'>" +
                                        "<div class='post-date'>" +
                                             " <a>" + ds4.Tables["duyuru"].Rows[i]["tarih"].ToString() + "</a>" +
                                        "</div>" +
                                        " <p> <a class='headline'>" + ds4.Tables["duyuru"].Rows[i]["baslik"].ToString() + "</a> Yazar: <a>POLAT EMLAK</a> </p>" +
                                        "<div class='post-meta'>" +
                                            " <p>" + ds4.Tables["duyuru"].Rows[i]["icerik"].ToString() + "</p>" +      
                                            "<a href='duyuruayrinti.aspx?id="+ ds4.Tables["duyuru"].Rows[i]["duyuruid"].ToString() + "' class='btn south-btn'>Daha Fazla</a>" +///////////BURADA İDYE GÖRE DUYURU AYRINTILARINI GÖSTERECEĞİZ
                                        "<div/>" +
                                       
                                "</div>" +
                             "</div>");
            }


            altmenu.Append("<ul class='useful-links-nav d-flex align-items-center'>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                altmenu.Append("<li><a href='" + ds.Tables[0].Rows[i]["link"].ToString() + "'>" + ds.Tables[0].Rows[i]["baslik"].ToString() + "</a></li>");
            }
            altmenu.Append("</ul>");
            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from evler", conn);
            da2.Fill(ds1, "evler");
            

            altevlerfonk();
            
        }
        public void altevlerfonk()
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                altevler.Append("<div class='single-featured-properties-slide'>" +
                                   " <a href='#'><img src='img/bg-img/" + ds1.Tables[0].Rows[i]["fotograf"].ToString() + "' alt=''></a>" +//burada fotografları veritabanında cekecegiz
                                "</div> ");
            }
        }
        protected void girisd_Click(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                girisd.Text = "Çıkış Yap";
                kayitd.Visible = false;
                Session.Abandon();
                Response.Redirect("duyurular.aspx" );

            }
            else
            {
                girisd.Text = "Giriş Yap";
                kayitd.Visible = true;
                Session["sayfa"] = "duyurular";
                Response.Redirect("uye_giris.aspx");

            }
        }

        protected void kayitd_Click(object sender, EventArgs e)
        {
            Session["sayfa"] = "duyurular";
            Response.Redirect("uye_kayit.aspx");
        }
    }
}