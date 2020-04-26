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
   
    public partial class adminozelislemler : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds1 = new DataSet();
        int sayac = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["admin"] == null)
            {
                 Response.Redirect("uye_giris.aspx");
            }

            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");

            OleDbDataAdapter da = new OleDbDataAdapter("select * from sayac", conn);
            da.Fill(ds1, "sayac");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                sayac++;
            }
            Label1.Text = Application.Get("ziyaretci").ToString();
            Label2.Text = sayac.ToString();
        }
        protected void btnsiltur_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            if (int.Parse(GridView2.SelectedValue.ToString()) > 0 )
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("delete * from turler where turid=" + GridView2.SelectedValue, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Response.Redirect("adminozelislemler.aspx");
        }
        protected void btnsilsehir_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            if (int.Parse(GridView1.SelectedValue.ToString()) > 0)
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("delete * from sehirler where sehirid=" + GridView1.SelectedValue, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Response.Redirect("adminozelislemler.aspx");
        }
        protected void btnekle0_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into sehirler (sehir) Values (@sehir)", conn);
            cmd.Parameters.AddWithValue("@sehir", tbsehirler.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("adminozelislemler.aspx");
        }

        protected void btnekle_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into turler (tur) Values (@tur)", conn);
            cmd.Parameters.AddWithValue("@tur", tbturler.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("adminozelislemler.aspx");
        }

        protected void btnanasayfa_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("/img/bg-img") + FileUpload1.FileName);
                conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into resimler (link) Values (@link)", conn);
                cmd.Parameters.AddWithValue("@link", FileUpload1.FileName);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Response.Redirect("adminozelislemler.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            string sec = "select * from sehirler where sehirid=" + GridView1.SelectedValue;
            OleDbDataAdapter da = new OleDbDataAdapter(sec, conn);
            da.Fill(ds3, "sehirler");
            tbsehirler.Text = ds3.Tables["sehirler"].Rows[0]["sehir"].ToString();       
            conn.Close();
        }

        protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            string sec = "select * from turler where turid=" + GridView2.SelectedValue;
            OleDbDataAdapter da = new OleDbDataAdapter(sec, conn);
            da.Fill(ds2, "turler");
            tbturler.Text = ds2.Tables["turler"].Rows[0]["tur"].ToString();
            conn.Close();
        }

        protected void btnanasayfaSil_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            if (int.Parse(GridView3.SelectedValue.ToString()) > 0)
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("delete * from resimler where id=" + GridView3.SelectedValue, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Response.Redirect("adminozelislemler.aspx");
        }

        protected void cikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
        int kontrol = 1;
        protected void btneklemenu_Click(object sender, EventArgs e)
        {
            Random sayi = new Random();
            int uretilen = sayi.Next(0, 1000);

            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from menuler", conn);
            DataSet ds3 = new DataSet();
            da.Fill(ds3,"menuler");

            for(int i=0;i<ds3.Tables[0].Rows.Count;i++)
            {
                if(ds3.Tables["menuler"].Rows[i]["link"].ToString()=="sayfa.aspx?id="+uretilen.ToString())
                {
                    uretilen = sayi.Next(0, 1000);
                    i--;
                }
                else
                {
                    kontrol = 0;
                }
            }
            if(kontrol == 0)
            {
                OleDbCommand cmd = new OleDbCommand("insert into menuler (link,baslik) Values (@link,@baslik)", conn);
                cmd.Parameters.AddWithValue("@link", "sayfa.aspx?id=" + uretilen.ToString());
                cmd.Parameters.AddWithValue("@baslik", tbmenu.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Redirect("adminozelislemler.aspx");
        }

        protected void btnsilmenu_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            if (int.Parse(GridView4.SelectedValue.ToString()) > 0)
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("delete * from menuler where id=" + GridView4.SelectedValue, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Response.Redirect("adminozelislemler.aspx");
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            string sec = "select * from menuler where id=" + GridView4.SelectedValue;
            OleDbDataAdapter da = new OleDbDataAdapter(sec, conn);
            da.Fill(ds2, "menuler");
            tbmenu.Text = ds2.Tables["menuler"].Rows[0]["baslik"].ToString();
            conn.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("harita.aspx");
        }
    }
}