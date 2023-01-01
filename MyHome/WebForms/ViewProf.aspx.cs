using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    public partial class ViewProf : System.Web.UI.Page
    {
        public static string[] members;
        protected void Page_Load(object sender, EventArgs e)
        {
            warnlbl.Visible = false;
            Button2.Visible = false;
            DatabaseQuery obj = new DatabaseQuery();
            ReadImg();
            string[] list = obj.GetUserInfo(Convert.ToInt32(Request.QueryString["ID"]));
            fnametxt.Text = list[0];
            lnametxt.Text = list[1];
            unametxt.Text = list[2];
            passwordtxt.Text = list[3];
            groupnametxt.Text = list[5];
            if (list[4] == "True")
            {
                isadmintxt.Text = "yes";
                groupinvitetxt.Text = list[6];
            }
            else 
            {
                isadmintxt.Text = "no";
                groupinvitetxt.Text = "not an admin account";
            }
            members = obj.GetMembers(Convert.ToInt32(Request.QueryString["GID"]));
                
        }
        public void ReadImg()
        {
            string myConn = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                SqlCommand cmd = new SqlCommand("GetImg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // open database connection.
                
                SqlParameter paraID = new SqlParameter()
                {
                    ParameterName = "@UserID",
                    Value = Convert.ToInt32(Request.QueryString["ID"])
                };
                cmd.Parameters.Add(paraID);
                //Execute the query 
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                ////Retrieve data from table and Display result
                byte[] image = null;
                while (sdr.Read())
                {
                    image = (byte[])sdr["UserDP"];
                }
                string strBase64 = Convert.ToBase64String(image);
                Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                Image1.DataBind();
                //Close the connection
                con.Close();
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
            Response.Redirect("SignIn.aspx");

        }

        protected void Button7_Click(object sender, EventArgs e)
        {

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Button8.Visible = false;
            warnlbl.Visible = true;
            Button2.Visible = true;
            
        }

        protected void isadmintxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void groupnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            obj.DeleteUser(Convert.ToInt32(Request.QueryString["ID"]));
            Response.Redirect("SignIn.aspx");
        }
    }
}