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
    public partial class evler : System.Web.UI.Page
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


        protected void Page_Load(object sender, EventArgs e)
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


            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from evler", conn);
            da2.Fill(ds1, "evler");

            
            for (int i=0;i<ds1.Tables[0].Rows.Count;i++)
            {
                if(ds1.Tables["evler"].Rows[i]["satildimi"].ToString()=="hayir")
                sonevler.Append(
               "<div class='col-12 col-md-6 col-xl-4'>" +
                    "<div class='single-featured-property mb-50'>" +
                       "<div class='property-thumb'>" +
                           "<a href='evozelligi.aspx?id="+ds1.Tables["evler"].Rows[i]["evid"]+"'><img src='img/bg-img/"+ds1.Tables["evler"].Rows[i]["fotograf"].ToString() +"'alt=''></a>" +
                           "<div class='tag'>" +
                               "<span>"+ds1.Tables["evler"].Rows[i]["satilik"].ToString()+"</span>" +
                           "</div>" +
                           "<div class='list-price'>" +
                               "<p>"+ds1.Tables["evler"].Rows[i]["fiyat"].ToString()+"</p>" +
                           "</div>" +
                       "</div>" +
                       "<div class='property-content'>" +
                           "<h5>"+ ds1.Tables["evler"].Rows[i]["tur"].ToString() +" | "+ ds1.Tables["evler"].Rows[i]["sehir"].ToString() +"</h5>" +
                           "<p class='location'><img src='img/icons/location.png' alt=''>"+ ds1.Tables["evler"].Rows[i]["adres"].ToString() + "</p>" +
                           "<p>"+ ds1.Tables["evler"].Rows[i]["odasayisi"].ToString()+"+"+ ds1.Tables["evler"].Rows[i]["salonsayisi"].ToString()+ " | "+ ds1.Tables["evler"].Rows[i]["ozellik"].ToString()+ "</p>" +
                           "<div class='property-meta-data d-flex align-items-end justify-content-between'>" +
                               "<div class='new-tag'>" +
                                   "<img src='img/icons/new.png'>" +
                               "</div>" +
                          "</div>" +
                       "</div>" +
                   "</div>" +
               "</div>");
            }

            altmenu.Append("<ul class='useful-links-nav d-flex align-items-center'>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                altmenu.Append("<li><a href='" + ds.Tables[0].Rows[i]["link"].ToString() + "'>" + ds.Tables[0].Rows[i]["baslik"].ToString() + "</a></li>");
            }
            altmenu.Append("</ul>");

            tbanahtar.Attributes.Add("placeholder", "    Evleri filtrelemek için ===>");
            OleDbDataAdapter da4 = new OleDbDataAdapter("select * from sehirler", conn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4, "sehirler");
            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                ddsehirler.Items.Add(new ListItem(ds4.Tables["sehirler"].Rows[i]["sehir"].ToString(), (i + 1).ToString()));
            }

            OleDbDataAdapter da5 = new OleDbDataAdapter("select * from turler", conn);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5, "turler");
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                ddkategoriler.Items.Add(new ListItem(ds5.Tables["turler"].Rows[i]["tur"].ToString(), (i + 1).ToString()));
            }
            ddodasayisi.Items.Add(new ListItem("1", "1"));
            ddodasayisi.Items.Add(new ListItem("2", "2"));
            ddodasayisi.Items.Add(new ListItem("3", "3"));
            ddodasayisi.Items.Add(new ListItem("4", "4"));
            ddodasayisi.Items.Add(new ListItem("5", "5"));

            ddoturmaodasi.Items.Add(new ListItem("0", "1"));
            ddoturmaodasi.Items.Add(new ListItem("1", "2"));
            ddoturmaodasi.Items.Add(new ListItem("2", "3"));

            ddsatilik.Items.Add(new ListItem("Satılık", "1"));
            ddsatilik.Items.Add(new ListItem("Kiralık", "2"));

            tbanahtar.Width = 250;
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

        protected void giris_Click(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                giris.Text = "Çıkış Yap";
                kayit.Visible = false;
                Session.Abandon();
                Response.Redirect("evler.aspx" );

            }
            else
            {
                giris.Text = "Giriş Yap";
                kayit.Visible = true;
                Session["sayfa"] = "evler";
                Response.Redirect("uye_giris.aspx");

            }
        }

        protected void kayit_Click(object sender, EventArgs e)
        {
            Session["sayfa"] = "evler";
            Response.Redirect("uye_kayit.aspx");
        }

        protected void btnara_Click(object sender, EventArgs e)
        {
            Session["odasayisi"] = ddodasayisi.SelectedItem.Text;
            Session["salonsayisi"] = ddoturmaodasi.SelectedItem.Text;
            Session["sehir"] = ddsehirler.SelectedItem.Text;
            Session["tur"] = ddkategoriler.SelectedItem.Text;
            Session["satilik"] = ddsatilik.SelectedItem.Text;
            
            Response.Redirect("evlerara.aspx");
        }
    }
}