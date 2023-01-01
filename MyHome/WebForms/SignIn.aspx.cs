using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{

    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Image1.ImageUrl = @"C:\Users\moasf\\Pictures\png-transparent-home-screen-house-computer-icons-window-home-purple-violet-logo.png"; 
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            int uid = obj.GetIdOnSignIn(usernametxt.Text, passwordtxt.Text);
            if (obj.CheckUserSignin(usernametxt.Text, passwordtxt.Text) == true)
            {
                if (obj.CheckLogin(uid) == false)
                {
                    obj.UpdateLogged(uid);

                    Response.Redirect("AnnouncenNotes.aspx?ID=" + uid + "&GID=" + obj.GetGroupID(uid));
                }
                else
                {
                    signinlbl.Text = "already signed in";
                }
                //take to announcement
            }
            else
            {
                signinlbl.Text = "incorrect password or username";
            }
        }
    }
}