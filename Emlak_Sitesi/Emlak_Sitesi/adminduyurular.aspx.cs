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
    public partial class adminduyurular : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("uye_giris.aspx");
            }
        }

        protected void btnekle_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            if (tbbaslik.Text.Length>0&&tbicerik.Text.Length>0 && FileUpload1.HasFile)
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into duyurular (fotograf,baslik,icerik,tarih) Values (@fotograf,@baslik,@icerik,@tarih)", conn);
                cmd.Parameters.AddWithValue("@fotograf", FileUpload1.FileName);
                cmd.Parameters.AddWithValue("@baslik", tbbaslik.Text);
                cmd.Parameters.AddWithValue("@icerik", tbicerik.Text);
                cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                cmd.ExecuteNonQuery();

                FileUpload1.SaveAs(Server.MapPath("/img/blog-img/") + FileUpload1.FileName);

            }
            else
                Response.Write("<script lang='JavaScript'>alert('Lütfen bilgileri eksiksiz doldurunuz');</script>");
            conn.Close();
            Response.Redirect("adminduyurular.aspx");
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.SelectedValue.ToString()) > 0 )
            {
                conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
                conn.Open();
                
                OleDbCommand cmd = new OleDbCommand("delete * from duyurular where duyuruid=" + GridView1.SelectedValue, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Response.Redirect("adminduyurular.aspx");
        }

        protected void btnduzenle_Click(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.SelectedValue.ToString()) > 0)
            {
                conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
                conn.Open();
              
                if (tbbaslik.Text.Length > 0 && tbicerik.Text.Length > 0 && FileUpload1.HasFile)
                {
                    
                    OleDbCommand cmd1 = new OleDbCommand("delete * from duyurular where duyuruid=" + GridView1.SelectedValue, conn);
                    cmd1.ExecuteNonQuery();
                    OleDbCommand cmd = new OleDbCommand("insert into duyurular (fotograf,baslik,icerik) Values (@fotograf,@baslik,@icerik)", conn);
                    cmd.Parameters.AddWithValue("@fotograf", FileUpload1.FileName);
                    cmd.Parameters.AddWithValue("@baslik", tbbaslik.Text);
                    cmd.Parameters.AddWithValue("@icerik", tbicerik.Text);
                    cmd.ExecuteNonQuery();

                    FileUpload1.SaveAs(Server.MapPath("/img/blog-img/") + FileUpload1.FileName);

                }

                conn.Close();
            }
            Response.Redirect("adminduyurular.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            conn.Open();
            
            string sec = "select * from duyurular where duyuruid=" + GridView1.SelectedValue;
            OleDbDataAdapter da = new OleDbDataAdapter(sec, conn);
            da.Fill(ds1, "duyurular");
            tbicerik.Text = ds1.Tables["duyurular"].Rows[0]["icerik"].ToString();
            tbbaslik.Text = ds1.Tables["duyurular"].Rows[0]["baslik"].ToString();
            
            conn.Close();
        }

        protected void cikis_Click(object sender, EventArgs e)
        {
            Session.Abandon(); Response.Redirect("index.aspx");
        }
    }
}