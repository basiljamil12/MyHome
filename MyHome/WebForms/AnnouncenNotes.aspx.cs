using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    
    public partial class AnnouncenNotes : System.Web.UI.Page
    {
        public static string[] taskName;
        public static string[] taskBy;
        public static string[] noteCont;
        public static string[] noteBy;
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            //add condition to display no content available if methods return null

            taskBy = obj.GetAnnNames(Convert.ToInt32(Request.QueryString["GID"]));
            taskName = obj.GetAnnContent(Convert.ToInt32(Request.QueryString["GID"]));
            noteCont = obj.GetNotesContent(Convert.ToInt32(Request.QueryString["GID"]));
            noteBy = obj.GetNotesName(Convert.ToInt32(Request.QueryString["GID"]));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAnnouncement.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllAnnouncements.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllNotes.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNote.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Buttn5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnnouncenNotes.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Buttn9_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            obj.UpdatedLogOut(Convert.ToInt32(Request.QueryString["ID"]));
            Response.Redirect("SignIn.aspx");
        }

        protected void Buttn8_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProf.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Buttn6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Chatroom.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }

        protected void Buttn7_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhotoGallery.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);

        }
    }
}