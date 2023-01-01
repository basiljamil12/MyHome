using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    public partial class AllNotes : System.Web.UI.Page
    {
        public static string[] noteCont;
        public static string[] noteBy;
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            noteCont = obj.CGetNotesContent(Convert.ToInt32(Request.QueryString["GID"]));
            noteBy = obj.CGetNotesName(Convert.ToInt32(Request.QueryString["GID"]));
        }
        public void GetNameByID()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnnouncenNotes.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            obj.UpdatedLogOut(Convert.ToInt32(Request.QueryString["ID"]));
            Response.Redirect("SignIn.aspx");
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
    }
}