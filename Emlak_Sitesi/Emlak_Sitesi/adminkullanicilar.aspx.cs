using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace Emlak_Sitesi
{
    public partial class adminkullanicilar : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds3 = new DataSet();
        int kontrol = 0;
        protected void Page_Load(object sender, EventArgs e)
        {   
            if(!IsPostBack)
            {
                Session["kontrol"] = kontrol;
            }
            if (Session["admin"] == null)
            {
                Response.Redirect("uye_giris.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            string sec = "select * from uyeler where id=" + GridView1.SelectedValue;
            OleDbDataAdapter da1 = new OleDbDataAdapter(sec, conn);
            da1.Fill(ds3, "uyeler");
            tbad.Text = ds3.Tables["uyeler"].Rows[0]["isim"].ToString();
            tbsoyad.Text = ds3.Tables["uyeler"].Rows[0]["soyisim"].ToString();
            tbposta.Text = ds3.Tables["uyeler"].Rows[0]["eposta"].ToString();
            tbka.Text = ds3.Tables["uyeler"].Rows[0]["ka"].ToString();
            tbsifre.Text = ds3.Tables["uyeler"].Rows[0]["sifre"].ToString();
            
            conn.Close();
        }

        protected void btnekle_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
           
            OleDbDataAdapter da = new OleDbDataAdapter("select * from uyeler", conn);
            da.Fill(ds, "uyeler");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ka"].ToString() == tbka.Text)
                    {
                        kontrol = 1;
                        Session["kontrol"] = kontrol;
                        break;
                    }
                    else
                    {
                        kontrol = 0;
                        Session["kontrol"] = kontrol;
                    }

                }


            }
            if (int.Parse(Session["kontrol"].ToString()) != 1)
            {
                if (tbka.Text.Length > 0 && tbsifre.Text.Length > 0 && tbposta.Text.Length > 0 && tbad.Text.Length > 0 && tbsoyad.Text.Length > 0)
                {
                    OleDbCommand cmd = new OleDbCommand("insert into uyeler (ka,isim,soyisim,eposta,sifre,gorev) Values (@ka,@isim,@soyisim,@eposta,@sifre,@gorev)", conn);
                    cmd.Parameters.AddWithValue("@ka", tbka.Text);
                    cmd.Parameters.AddWithValue("@isim", tbad.Text);
                    cmd.Parameters.AddWithValue("@soyisim", tbsoyad.Text);
                    cmd.Parameters.AddWithValue("@eposta", tbposta.Text);
                    cmd.Parameters.AddWithValue("@sifre", tbsifre.Text);
                    cmd.Parameters.AddWithValue("@gorev", "Uye");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                    Response.Write("<script lang='JavaScript'>alert('Lütfen bilgileri eksiksiz doldurunuz');</script>");
            }
            else
                Response.Write("<script lang='JavaScript'>alert('Kullanici Var');</script>");
            Response.Redirect("adminkullanicilar.aspx");
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            if (int.Parse(GridView1.SelectedValue.ToString()) > 0 )
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("delete * from uyeler where id=" + GridView1.SelectedValue, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Response.Redirect("adminkullanicilar.aspx");

        }

        protected void btnduzenle_Click(object sender, EventArgs e)
        {


           conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from uyeler", conn);
            da.Fill(ds, "uyeler");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ka"].ToString() == tbka.Text)
                    {
                        kontrol = 1;
                        Session["kontrol"] = kontrol;
                        break;
                    }
                    else
                    {
                        kontrol = 0;
                        Session["kontrol"] = kontrol;
                    }

                }


            }
            conn.Close();
            if (int.Parse(Session["kontrol"].ToString()) != 1)
            {
                if (int.Parse(GridView1.SelectedValue.ToString()) > 0)
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("delete * from uyeler where id=" + GridView1.SelectedValue, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }

                if (tbka.Text.Length > 0 && tbsifre.Text.Length > 0 && tbposta.Text.Length > 0 && tbad.Text.Length > 0 && tbsoyad.Text.Length > 0)
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into uyeler (ka,isim,soyisim,eposta,sifre,gorev) Values (@ka,@isim,@soyisim,@eposta,@sifre,@gorev)", conn);
                    cmd.Parameters.AddWithValue("@ka", tbka.Text);
                    cmd.Parameters.AddWithValue("@isim", tbad.Text);
                    cmd.Parameters.AddWithValue("@soyisim", tbsoyad.Text);
                    cmd.Parameters.AddWithValue("@eposta", tbposta.Text);
                    cmd.Parameters.AddWithValue("@sifre", tbsifre.Text);
                    cmd.Parameters.AddWithValue("@gorev", "Uye");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                    Response.Write("<script lang='JavaScript'>alert('Lütfen bilgileri eksiksiz doldurunuz');</script>");
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Kullanıcı Var');</script>");
            }
            Response.Redirect("adminkullanicilar.aspx");
        }

        protected void cikis_Click(object sender, EventArgs e)
        {
            Session.Abandon(); Response.Redirect("index.aspx");
        }
    }
}