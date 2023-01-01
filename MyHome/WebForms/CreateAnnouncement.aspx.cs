using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    public partial class CreateAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            obj.MakeAnnouncement(Convert.ToInt32(Request.QueryString["ID"]), Convert.ToInt32(Request.QueryString["GID"]), announcetxt.Text);
            Response.Redirect("AnnouncenNotes.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Buttn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnnouncenNotes.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Buttn3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Chatroom.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Buttn4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhotoGallery.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Buttn6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProf.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }

        protected void Buttn5_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            obj.UpdatedLogOut(Convert.ToInt32(Request.QueryString["ID"]));
            Response.Redirect("SignIn.aspx");

        }
    }
}