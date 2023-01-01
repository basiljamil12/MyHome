using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
   
    public partial class PhotoGallery : System.Web.UI.Page
    {

        public static string[] imageid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select FirstName,[image] from [image] where groupid=" + Convert.ToInt32(Request.QueryString["GID"]), con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnnouncenNotes.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Chatroom.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhotoGallery.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProf.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            obj.UpdatedLogOut(Convert.ToInt32(Request.QueryString["ID"]));
            Response.Redirect("SignIn.aspx");

        }
        public void CreateGallery()
        {
            for (int i = 0; i < 3; i++)
            {
                Image image = new Image();
                image.ID = "image" + i;
                image.Height = Unit.Pixel(260);
                image.Width = Unit.Pixel(260);
                image.Style.Add("padding", "8px");
            }
        }
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        protected void Button7_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;
            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                try
                {
                    //string qry;
                    SqlCommand cmd = new SqlCommand("AddImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paragID = new SqlParameter()
                    {
                        ParameterName = "@UserID",
                        Value = Convert.ToInt32(Request.QueryString["ID"])
                    };
                    cmd.Parameters.Add(paragID);

                    SqlParameter parafn = new SqlParameter()
                    {
                        ParameterName = "@GroupID",
                        Value = Convert.ToInt32(Request.QueryString["GID"])
                    };
                    cmd.Parameters.Add(parafn);
                    SqlParameter paraImage = new SqlParameter()
                    {
                        ParameterName = "@Image",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paraImage);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("PhotoGallery.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

                }
                catch
                {
                    throw;
                }
                }

        }
    }
}