using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    public partial class AllAnnouncements : System.Web.UI.Page
    {
        public static string[] taskName;
        public static string[] taskBy;
        public static string[] taskOn;
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            taskName = obj.GetAllAnnNames(Convert.ToInt32(Request.QueryString["GID"]));
            taskBy = obj.GetAllAnnContent(Convert.ToInt32(Request.QueryString["GID"]));
            taskOn = obj.GetAllAnnTime(Convert.ToInt32(Request.QueryString["GID"]));
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
    }
}