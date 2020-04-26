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
    public partial class admin : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds3 = new DataSet();
        static void verigoster()
        {



        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("~/odev.mdb");
            if (Session["admin"] == null)
            {
                Response.Redirect("uye_giris.aspx");
            }
            if (!IsPostBack)
            {

                conn.Open();
               OleDbDataAdapter da = new OleDbDataAdapter("select * from sehirler", conn);
              da.Fill(ds, "sehirler");
              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                ddsehirler.Items.Add(new ListItem(ds.Tables[0].Rows[i]["sehir"].ToString(), i.ToString()));
                 }
            OleDbDataAdapter da1 = new OleDbDataAdapter("select *from turler", conn);
            da1.Fill(ds1, "turler");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ddtur.Items.Add(new ListItem(ds1.Tables[0].Rows[i]["tur"].ToString(), i.ToString()));
            }
            ddsatilik.Items.Add(new ListItem("Satılık", "1"));
            ddsatilik.Items.Add(new ListItem("Kiralık", "2"));
            conn.Close();
           }
        }

          
    

        protected void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (tbaciklama.Text.Length > 0 && tbadres.Text.Length > 0 && tbfiyat.Text.Length > 0 && tbozellik.Text.Length > 0 && ddsatilik.Text.Length > 0 && ddtur.Text.Length > 0 && ddsehirler.Text.Length > 0 && FileUpload1.HasFile)
                {
                    OleDbCommand cmd = new OleDbCommand("insert into evler (fotograf,aciklama,adres,fiyat,ozellik,satilik,tur,sehir,turid,sehirid,odasayisi,salonsayisi,satildimi) Values (@fotograf,@aciklama,@adres,@fiyat,@ozellik,@satilik,@tur,@sehir,@turid,@sehirid,@odasayisi,@salonsayisi,@satildimi)", conn);
                    cmd.Parameters.AddWithValue("@fotograf", FileUpload1.FileName);
                    cmd.Parameters.AddWithValue("@aciklama", tbaciklama.Text);
                    cmd.Parameters.AddWithValue("@adres", tbadres.Text);
                    cmd.Parameters.AddWithValue("@fiyat", tbfiyat.Text);
                    cmd.Parameters.AddWithValue("@ozellik", tbozellik.Text);
                    cmd.Parameters.AddWithValue("@satilik", ddsatilik.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tur", ddtur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@sehir", ddsehirler.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@turid", ddtur.SelectedValue);
                    cmd.Parameters.AddWithValue("@sehirid", ddsehirler.SelectedValue);
                    cmd.Parameters.AddWithValue("@odasayisi", tboda.Text);
                    cmd.Parameters.AddWithValue("@salonsayisi", tbsalon.Text);
                    if (CheckBox1.Checked == false)
                        cmd.Parameters.AddWithValue("@satildimi", "evet");
                    else
                        cmd.Parameters.AddWithValue("@satildimi", "hayir");
                    cmd.ExecuteNonQuery();

                    FileUpload1.SaveAs(Server.MapPath("/img/bg-img/") + FileUpload1.FileName);

                }
                else
                    Response.Write("<script lang='JavaScript'>alert('Lütfen bilgileri eksiksiz doldurunuz');</script>");
                conn.Close();
                Response.Redirect("admin.aspx");
            }
            catch { }
    
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            string sec = "select * from evler where evid=" + GridView1.SelectedValue;
            OleDbDataAdapter da = new OleDbDataAdapter(sec, conn);
            da.Fill(ds3, "evler");
            tbaciklama.Text = ds3.Tables["evler"].Rows[0]["aciklama"].ToString();
            tbadres.Text = ds3.Tables["evler"].Rows[0]["adres"].ToString();
            tbfiyat.Text = ds3.Tables["evler"].Rows[0]["fiyat"].ToString();
            tbozellik.Text = ds3.Tables["evler"].Rows[0]["ozellik"].ToString();
            tboda.Text = ds3.Tables["evler"].Rows[0]["odasayisi"].ToString();
            tbsalon.Text= ds3.Tables["evler"].Rows[0]["salonsayisi"].ToString();
            conn.Close();
          
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            if(int.Parse(GridView1.SelectedValue.ToString())>0&& tbaciklama.Text.Length > 0 && tbadres.Text.Length > 0 && tbfiyat.Text.Length > 0 && tbozellik.Text.Length > 0 && ddsatilik.Text.Length > 0 && ddtur.Text.Length > 0 && ddsehirler.Text.Length > 0 )
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("delete * from evler where evid=" + GridView1.SelectedValue, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
               
            }
            Response.Redirect("admin.aspx");
        }

        protected void btnduzenle_Click(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.SelectedValue.ToString()) > 0)
            {
                conn.Open();
                if (tbaciklama.Text.Length > 0 && tbadres.Text.Length > 0 && tbfiyat.Text.Length > 0 && tbozellik.Text.Length > 0 && ddsatilik.Text.Length > 0 && ddtur.Text.Length > 0 && ddsehirler.Text.Length > 0 && FileUpload1.HasFile)
                {
                 
                    OleDbCommand cmd1 = new OleDbCommand("delete * from evler where evid=" + GridView1.SelectedValue, conn);
                    cmd1.ExecuteNonQuery();
                    OleDbCommand cmd = new OleDbCommand("insert into evler (fotograf,aciklama,adres,fiyat,ozellik,satilik,tur,sehir,turid,sehirid,odasayisi,salonsayisi,satildimi) Values (@fotograf,@aciklama,@adres,@fiyat,@ozellik,@satilik,@tur,@sehir,@turid,@sehirid,@odasayisi,@salonsayisi,@satildimi)", conn);
                    cmd.Parameters.AddWithValue("@fotograf", FileUpload1.FileName);
                    cmd.Parameters.AddWithValue("@aciklama", tbaciklama.Text);
                    cmd.Parameters.AddWithValue("@adres", tbadres.Text);
                    cmd.Parameters.AddWithValue("@fiyat", tbfiyat.Text);
                    cmd.Parameters.AddWithValue("@ozellik", tbozellik.Text);
                    cmd.Parameters.AddWithValue("@satilik", ddsatilik.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tur", ddtur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@sehir", ddsehirler.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@turid", ddtur.SelectedValue);
                    cmd.Parameters.AddWithValue("@sehirid", ddsehirler.SelectedValue);
                    cmd.Parameters.AddWithValue("@odasayisi", tboda.Text);
                    cmd.Parameters.AddWithValue("@salonsayisi", tbsalon.Text);
                    if (CheckBox1.Checked == false)
                        cmd.Parameters.AddWithValue("@satildimi", "evet");
                    else
                        cmd.Parameters.AddWithValue("@satildimi", "hayir");
                    cmd.ExecuteNonQuery();

                    FileUpload1.SaveAs(Server.MapPath("/img/bg-img/") + FileUpload1.FileName);

                }
 
                conn.Close();
            }
            Response.Redirect("admin.aspx");
        }

        protected void cikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}