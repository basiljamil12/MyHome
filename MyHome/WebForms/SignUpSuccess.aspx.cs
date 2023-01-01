using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    public partial class SignUpSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

        
        protected void Button1_Click(object sender, EventArgs e)
        {
           // InIn();
            Response.Redirect("SignIn.aspx");
        }
    }
}