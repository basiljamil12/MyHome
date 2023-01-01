using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    public partial class Chatroom : System.Web.UI.Page
    {
        public static string[] Content;
        public static string[] By;
        public static string[] Time;
        public static int[] mID;
        public static int SessionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            mID = obj.GetMessageID(Convert.ToInt32(Request.QueryString["GID"]));
            By = obj.FirstnLast(Convert.ToInt32(Request.QueryString["GID"]));
            Content = obj.GetMessageC(Convert.ToInt32(Request.QueryString["GID"]));
            Time = obj.GetMessageT(Convert.ToInt32(Request.QueryString["GID"]));
            SessionID = Convert.ToInt32(Request.QueryString["ID"]);
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

        protected void sendbtn_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            obj.AddMessage(messagetypetxt.Text, Convert.ToInt32(Request.QueryString["ID"]), Convert.ToInt32(Request.QueryString["GID"]));
            Response.Redirect("Chatroom.aspx?ID=" + Request.QueryString["ID"] + "&GID=" + Request.QueryString["GID"]);
        }
    }
}