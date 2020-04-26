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
    public partial class duyuruayrinti : System.Web.UI.Page
    {
        public StringBuilder menuler = new StringBuilder();
        public StringBuilder duyuru = new StringBuilder();
        public StringBuilder sonevler = new StringBuilder();
        public StringBuilder yorumlar = new StringBuilder();
        public StringBuilder altmenu = new StringBuilder();
        public StringBuilder altevler = new StringBuilder();
        public string menubaslik;
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        int sayac = 0;
        string id = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"]== null)
            {
                giris.Text = "Giriş Yap";
                kayit.Visible = true ;
                btnonay.Enabled = false;
                tbmail.ReadOnly = true;
                tbad.ReadOnly = true;
                tbyorum.ReadOnly = true;
            }
            else
            {
                giris.Text = "Çıkış Yap";
                kayit.Visible = false;
                btnonay.Enabled = true;
                tbmail.ReadOnly = false;
                tbad.ReadOnly = false;
                tbyorum.ReadOnly = false;
               
            }

            try
            {
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

                if (!IsPostBack)
                    Session["q1"] = id;

                if (Request.QueryString.Count > 0)
                    id = Request.QueryString[0];
                Session["q1"] = id;


                OleDbDataAdapter da1 = new OleDbDataAdapter("select * from duyurular where duyuruid=" + Session["q1"], conn);
                da1.Fill(ds1, "duyuru");



                OleDbDataAdapter da2 = new OleDbDataAdapter("select * from yorumlar", conn);
                da2.Fill(ds2, "yorumlar");

                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables["yorumlar"].Rows[i]["duyuruid"].ToString() == Session["q1"].ToString())
                        sayac++;
                }

                duyuru.Append(
                    "<div class='single-blog-area'>" +
                       "<div class='blog-post-thumbnail'>" +
                             "<img src='img/blog-img/" + ds1.Tables["duyuru"].Rows[0]["fotograf"].ToString() + "' alt=''>" +//idye göre resimi getirecek
                        "</div>" +
                        "<div class='post-content'>" +
                            "<div class='post-date'>" +
                                 "<a>" + ds1.Tables["duyuru"].Rows[0]["tarih"].ToString() + "</a>" +
                            "</div>" +
                            " <a class='headline'>Baslık</a>" +
                            "<div class='post-meta'>" +
                                "<p>Yazar: <a>Polat Emlak</a> | <a>Yorum Sayısı:" + sayac + " </a></p>" +
                            "</div>" +
                             "<p>" + ds1.Tables["duyuru"].Rows[0]["icerik"].ToString() + "</p>" +
                        "</div>" +
                    "</div>");


                for (int i = 0; i < ds2.Tables["yorumlar"].Rows.Count; i++)//idye göre ne kadar yorum varsa o kadar dönecek
                {

                    if (ds2.Tables["yorumlar"].Rows[i]["duyuruid"].ToString() == Session["q1"].ToString())
                    {
                        yorumlar.Append(
                       "<li class='single_comment_area'>" +
                           " <div class='comment-wrapper d-flex'>" +
                                 "<div class='comment-author'>" +
                                       "<img src='img/blog-img/c-3.jpg' alt=''>" +
                                 "</div>" +
                            "<div class='comment-content'>" +
                                 "<div class='comment-meta'>" +
                                       "<a class='comment-author-name'>" + ds2.Tables["yorumlar"].Rows[i]["ka"].ToString() + "</a> |" +
                                        "<a class='comment-date'>" + ds2.Tables["yorumlar"].Rows[i]["tarih"].ToString() + "</a> |" +
                                 "</div>" +
                                 "<p>" + ds2.Tables["yorumlar"].Rows[i]["yorum"].ToString() + "</p>" +
                            "</div>" +
                           "</div>" +
                       "</li>");
                    }


                }

            }
            catch
            {

            }
               
           
          


        }

        protected void giris_Click(object sender, EventArgs e)
        {
           
            if (Session["uye"] != null)
            {
                giris.Text = "Çıkış Yap";
                kayit.Visible = false;
                Session.Abandon();
                Response.Redirect("duyuruayrinti.aspx?id=" + id);

            }
            else
            {
                giris.Text = "Giriş Yap";
                kayit.Visible = true;
                Session["sayfa"] = "duyuruayrinti";
                Response.Redirect("uye_giris.aspx");
                
            }
            
            
           
        }

        protected void kayit_Click(object sender, EventArgs e)
        {
            Session["sayfa"] = "duyuruayrinti";
            Response.Redirect("uye_kayit.aspx");
        }

        protected void btnonay_Click(object sender, EventArgs e)
        {

            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            if (tbad.Text.Length!=0&tbmail.Text.Length!=0&&tbyorum.Text.Length!=0)
            {
                OleDbCommand cmd = new OleDbCommand("insert into yorumlar (yorum,ka,tarih,mail,duyuruid) Values (@yorum,@ka,@tarih,@mail,@duyuruid)", conn);
                cmd.Parameters.AddWithValue("@yorum",tbyorum.Text);
                cmd.Parameters.AddWithValue("@ka",tbad.Text);
                cmd.Parameters.AddWithValue("@tarih",DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@mail",tbmail.Text);
                cmd.Parameters.AddWithValue("@duyuruid",Session["q1"].ToString());
                cmd.ExecuteNonQuery();

               
            }
            
            conn.Close();
            Response.Redirect("duyuruayrinti.aspx?id=" + Session["q1"].ToString());
        }
    }
}