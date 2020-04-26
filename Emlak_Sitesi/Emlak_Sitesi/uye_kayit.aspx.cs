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
    public partial class uye_kayit : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();

        int ka,sifre;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from uyeler", conn);
            da.Fill(ds, "uyeler");
            Random sayi = new Random();
            ka = sayi.Next(100000, 1000000);
            sifre = sayi.Next(100000, 1000000);
            if (ds.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if(ds.Tables[0].Rows[i]["ka"].ToString()==ka.ToString())
                    {
                        sifre = sayi.Next(100000, 1000000);
                        ka = sayi.Next(100000, 1000000);
                    }
                       
                }
                
                
            }
            tbka.Text = ka.ToString();
            tbsifre.Text = sifre.ToString();
            conn.Close();
            
        }

        protected void btnkayit_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            if (tbka.Text.Length > 0 && tbsifre.Text.Length > 0 && tbeposta.Text.Length > 0 && tbad.Text.Length > 0 && tbsoyad.Text.Length > 0)
            {
                OleDbCommand cmd = new OleDbCommand("insert into uyeler (ka,isim,soyisim,eposta,sifre,gorev) Values (@ka,@isim,@soyisim,@eposta,@sifre,@gorev)", conn);
                cmd.Parameters.AddWithValue("@ka", ka.ToString());
                cmd.Parameters.AddWithValue("@isim", tbad.Text);
                cmd.Parameters.AddWithValue("@soyisim", tbsoyad.Text);
                cmd.Parameters.AddWithValue("@eposta", tbeposta.Text);
                cmd.Parameters.AddWithValue("@sifre", sifre.ToString());
                cmd.Parameters.AddWithValue("@gorev", "Uye");
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("uye_giris.aspx");
            }
            else
                Response.Write("<script lang='JavaScript'>alert('Lütfen bilgileri eksiksiz doldurunuz');</script>");

        }
    }
}