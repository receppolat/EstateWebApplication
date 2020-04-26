using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.OleDb;

namespace Emlak_Sitesi
{
    public partial class uye_giris : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            tbka.Attributes.Add("placeholder", "Kullanıcı Adınız");
            tbka.Attributes.Add("style", "padding-left:10px");
            tbsifre.Attributes.Add("placeholder", "Şifrenizi Giriniz");
            tbsifre.Attributes.Add("style", "padding-left:10px");
        }

        protected void tbka_TextChanged(object sender, EventArgs e)
        {
        
        }

        protected void btngrs_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from uyeler", conn);
            da.Fill(ds, "uyeler");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ka"].ToString() == tbka.Text &&tbsifre.Text == ds.Tables[0].Rows[i]["sifre"].ToString()&& ds.Tables[0].Rows[i]["gorev"].ToString() == "Uye")
                    {
                        Session["uye"] = 1;
                        if (Session["sayfa"].ToString() == "duyuruayrinti" && Session["sayfa"] != null)
                            Response.Redirect("duyuruayrinti.aspx?id=" + Session["q1"].ToString());
                        else if (Session["sayfa"].ToString() == "duyurular" && Session["sayfa"] != null)
                            Response.Redirect("duyurular.aspx");
                        else if (Session["sayfa"].ToString() == "evozelligi" && Session["sayfa"] != null)
                            Response.Redirect("evozelligi.aspx?id=" + Session["q"].ToString());
                        else if (Session["sayfa"].ToString() == "evler" && Session["sayfa"] != null)
                            Response.Redirect("evler.aspx");
                        else
                           Response.Redirect("index.aspx");
                    }
                    else if(ds.Tables[0].Rows[i]["ka"].ToString() == tbka.Text && ds.Tables[0].Rows[i]["gorev"].ToString() == "Admin" && tbsifre.Text == ds.Tables[0].Rows[i]["sifre"].ToString())
                    {
                        Session["admin"] = 1;
                        Response.Redirect("admin.aspx");
                    }
                    
                }


            }


        }

        protected void tbsifre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnkyt_Click(object sender, EventArgs e)
        {
            Response.Redirect("uye_kayit.aspx");
        }
    }
}