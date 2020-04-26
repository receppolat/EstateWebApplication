using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Xml;
namespace Emlak_Sitesi
{
    public partial class index : System.Web.UI.Page
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
        DataSet ds4 = new DataSet();
        public void altevlerfonk()
        {
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                altevler.Append("<div class='single-featured-properties-slide'>" +
                                   " <a href='#'><img src='img/bg-img/"+ ds2.Tables[0].Rows[i]["fotograf"].ToString() + "' alt=''></a>" +//burada fotografları veritabanında cekecegiz
                                "</div> ");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            
            OleDbDataAdapter da5 = new OleDbDataAdapter("select * from menuler", conn);
            da5.Fill(ds4, "menuler");


            XmlTextWriter yaz = new XmlTextWriter("dinamik.xml", System.Text.UTF8Encoding.UTF8);
            yaz.Formatting = Formatting.Indented;
            try
            {
                
                yaz.WriteStartDocument(); //Xml dökümanına ait declaration satırını oluşturur. Kısaca yazmaya başlar.
                yaz.WriteStartElement("siteMap");
                yaz.WriteAttributeString("xmlns", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
                for(int i=0;i<ds4.Tables[0].Rows.Count;i++)
                {
                    yaz.WriteStartElement("siteMapNode");
                    yaz.WriteAttributeString("url", ds4.Tables["menuler"].Rows[i]["link"].ToString());
                    yaz.WriteAttributeString("tittle", ds4.Tables["menuler"].Rows[i]["baslik"].ToString());
                    yaz.WriteAttributeString("description", "");
                    yaz.WriteEndElement();
                }
               
                yaz.WriteEndElement();
                yaz.Close();


            }
            catch (Exception ex)
            {
                
            }
            */
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");

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
            int ms = 100;
          

            if (!IsPostBack)
            {
                ms = 100;
                Session["ms"] = ms;
            }


           


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

            OleDbDataAdapter da1 = new OleDbDataAdapter("select * from resimler", conn);
            da1.Fill(ds1, "resimler");  
           
            ////BURADA VERİ TABANINDAN FOTOĞRAFLARI ÇEKECEK VE ÇEKTİĞİ FOTOĞRAFLARA GÖRE SLIDEI YAPACAK
           for(int i = 0; i < ds1.Tables[0].Rows.Count;i++)
           {
                resimler.Append("<div class='single-hero-slide bg-img' style='background-image:url(img/bg-img/" + ds1.Tables[0].Rows[i]["link"].ToString() + ");' >");
                resimler.Append(" <div class='container h-100'>" +
                    "<div class='row h-100 align-items-center'>" +
                    " <div class='col-12'>" +
                    "<div class='hero-slides-content'>" +
                    "<h2 data-animation='fadeInUp' data-delay='100ms'>Polat Emlak</h2>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>");
           }

            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from evler", conn);
           
            da2.Fill(ds2, "evler");



           for(int i =0;i<3; i++)
            {
                sonevler.Append(
           "<div class='col-12 col-md-6 col-xl-4'>" +
                "<div class='single-featured-property mb-50 wow fadeInUp' data-wow-delay='" + Session["ms"].ToString() + "ms' style='visibility:visible; animation-delay:100ms; animation-name:fadeInUp;'> " +
                    " <img src='img/bg-img/"+ ds2.Tables[0].Rows[i]["fotograf"].ToString() + "' width='500' height='500' alt=''>" +
                    " <div class='property-thumb'>"+

                           "<div class='tag'>" +
                                "<span>"+ ds2.Tables[0].Rows[i]["satilik"].ToString() +"</span >"+
                           "</div> " +

                           " <div class='list-price'>"+
                                "<p> "+ ds2.Tables[0].Rows[i]["fiyat"].ToString() + " </p>"+
                           "</div>" +

                     "</div>" +

                     "<div class='property-content'>" +
                        "<h5>Sehir</h5>" +
                            "<p class='location'>"+ ds2.Tables[0].Rows[i]["adres"].ToString() + "</p>" +
                            "<p>"+ ds2.Tables[0].Rows[i]["ozellik"].ToString() + "</p>" +
                       
                     "</div>" +
                 "</div>" +
           "</div>");
                ms = int.Parse(Session["ms"].ToString());
                ms += 100;
                Session["ms"] = ms;

            }

            OleDbDataAdapter da3 = new OleDbDataAdapter("select * from duyurular", conn);
            da3.Fill(ds3, "duyurular");
         
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    yorumlar.Append(
                        " <div class='single-testimonial-slide text-center'>" +
                             "<h5>" + ds3.Tables["duyurular"].Rows[i]["baslik"].ToString() + "</h5>" +
                             " <p>" + ds3.Tables["duyurular"].Rows[i]["icerik"].ToString() + "</p>" +
                             "<div class='testimonial-author-info'>" +
                              " <img src='img/bg-img/recep_polat.jpg' alt=''>" +
                            "<p>Recep Polat <span>| Admin</span></p>" +
                        "</div>" +
                        "</div>");
                }
            
            
           altmenu.Append("<ul class='useful-links-nav d-flex align-items-center'>");
           for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                altmenu.Append("<li><a href='"+ds.Tables[0].Rows[i]["link"].ToString()+"'>"+ds.Tables[0].Rows[i]["baslik"].ToString()+"</a></li>");
            }
            altmenu.Append("</ul>");
           

            altevlerfonk();
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