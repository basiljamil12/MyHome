using MyHome.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHome.WebForms
{
    
    public partial class SignUp : System.Web.UI.Page
    {
        public static string firstname;
        public static string lastname;
        public static string username;
        public static string password;
        public static byte[] ImageByteArray;

        public bool FieldsCheck()
        {
            if (String.IsNullOrEmpty(firsttxt.Text) || String.IsNullOrEmpty(lasttxt.Text) || String.IsNullOrEmpty(usernametxt.Text) || String.IsNullOrEmpty(passwordtxt.Text) || String.IsNullOrEmpty(cpasswordtxt.Text))
            {
                signuplbl.Text = "all fields must have a value";
                return false;
            }
            else
            {
                if (firsttxt.Text.Contains(" ") || lasttxt.Text.Contains(" ") || usernametxt.Text.Contains(" ") || passwordtxt.Text.Contains(" "))
                {
                    signuplbl.Text = "white spaces are not allowed";
                    return false;
                }
                else
                {
                    if ( find(firsttxt.Text) == true 
                        || find(lasttxt.Text) == true)
                    {
                        signuplbl.Text = "first and last name can't have special characters";
                        return false;
                    }
                    else
                    {
                        DatabaseQuery obj = new DatabaseQuery();
                        if (obj.CheckUsernameAval(usernametxt.Text) == true)
                        {
                            if (passwordtxt.Text.Equals(cpasswordtxt.Text))
                                return true;
                            else
                            {
                                signuplbl.Text = "passwords do not match";
                                return false;
                            }
                        }
                        else
                        {
                            signuplbl.Text = "username already exists";
                            return false;
                        }
                        
                            
                        }
                    
                }
            }
            //add a constraint to check the SQL if the username exists already 
            
        }
        //function doesnt work properly
        //public bool HasNums(string x)
        //{
        //    return x.Any(Char.IsDigit);
        //}
        //public bool HasSpecial(string x)
        //{
        //    Regex rex = new Regex("^[a-z0-9 ]+$", RegexOptions.IgnoreCase);
        //    return !rex.IsMatch(x);
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.Visible = false;

        }
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        public bool SignupUser(string firstname, string lastname, string username, string password, int groupid, int joingroup)
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
                    SqlCommand cmd = new SqlCommand("AddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                        SqlParameter paragID = new SqlParameter()
                        {
                            ParameterName = "@GroupID",
                            Value = groupid
                        };
                        cmd.Parameters.Add(paragID);

                        SqlParameter parafn = new SqlParameter()
                        {
                            ParameterName = "@FirstName",
                            Value = firstname
                        };
                        cmd.Parameters.Add(parafn);

                        SqlParameter paraln = new SqlParameter()
                        {
                            ParameterName = "@LastName",
                            Value = lastname
                        };
                        cmd.Parameters.Add(paraln);
                    if (joingroup == 1) //if joingroup = 1 the user doesnt want to be an admin
                    {
                        SqlParameter paraia = new SqlParameter()
                        {
                            ParameterName = "@IsAdmin",
                            Value = 0
                        };
                        cmd.Parameters.Add(paraia);
                    }
                    else
                    {
                        SqlParameter paraia = new SqlParameter()
                        {
                            ParameterName = "@IsAdmin",
                            Value = 1
                        };
                        cmd.Parameters.Add(paraia);
                    }
                        

                        SqlParameter paraua = new SqlParameter()
                        {
                            ParameterName = "@Username",
                            Value = username
                        };
                        cmd.Parameters.Add(paraua);

                        SqlParameter paraps = new SqlParameter()
                        {
                            ParameterName = "@Password",
                            Value = password
                        };
                        cmd.Parameters.Add(paraps);

                        SqlParameter paraImage = new SqlParameter()
                        {
                            ParameterName = "@UserDP",
                            Value = bytes
                        };
                        cmd.Parameters.Add(paraImage);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //} 
                    //qry = "exec AddUser '" + groupid + "','" + firstname + "','" + lastname + "','" + 0 + "','" + username + "','" + password + "','" + bytes + "'";
                    //else // if the groupid != 1 the user wants to create a new group and be an admin
                    //qry = "exec AddUser '" + groupid + "','" + firstname + "','" + lastname + "','" + 1 + "','" + username + "','" + password + "','" + bytes + "'";
                    //SqlCommand cmd = new SqlCommand(qry, conn);
                    //cmd.ExecuteNonQuery();
                    //conn.Close();
                    return true;
                }
                catch
                {
                    throw;
                    return false;
                }
            }
            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FieldsCheck() == true)
            {
                Button1.Visible = false;
                Button2.Visible = false;
                newadminlbl.Visible = true;
                newadmintxt.Visible = true;
                crtaccbtn1.Visible = true;
                FileUpload1.Visible = true;
                Label1.Visible = true;
                signuplbl.Visible = false;
            }
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FieldsCheck() == true)
            {
                Button1.Visible = false;
                Button2.Visible = false;
                joinfamlbl.Visible = true;
                joinfamtxt.Visible = true;
                crtaccbtn2.Visible = true;
                FileUpload1.Visible = true;
                Label1.Visible = true;
                signuplbl.Visible = false;
            }
        }
        
        protected void crtaccbtn1_Click(object sender, EventArgs e)
        {
            if (!newadmintxt.Text.Contains(" ") && !find(newadmintxt.Text))
            {
                DatabaseQuery obj = new DatabaseQuery();
                //call sql query to insert
                if (SignupUser(firsttxt.Text.ToLower(), lasttxt.Text.ToLower(), usernametxt.Text.ToLower(), passwordtxt.Text, obj.MakeGroup(newadmintxt.Text.ToLower()), 0) == true)

                {
                    
                    obj.InIn(obj.GetIdOnSignIn(usernametxt.Text, passwordtxt.Text));
                    Response.Redirect("SignUpSuccess.aspx");
                }
                else
                {
                    newadminlbl.Text = "there was an error please try again later";
                }
            }
        }
       
        protected void crtaccbtn2_Click(object sender, EventArgs e)
        {
            DatabaseQuery obj = new DatabaseQuery();
            if (obj.GetGroupIDByInvite(joinfamtxt.Text) != 0)
            {
                if (SignupUser(firsttxt.Text.ToLower(), lasttxt.Text.ToLower(), usernametxt.Text.ToLower(), passwordtxt.Text, obj.GetGroupIDByInvite(joinfamtxt.Text), 1) == true)
                {
                    obj.InIn(obj.GetIdOnSignIn(usernametxt.Text, passwordtxt.Text));
                    Response.Redirect("SignUpSuccess.aspx");
                }

                else
                    inverrlbl.Text = "error occured";
            }
            else
            {
                inverrlbl.Text = "invalid invite";
            }
        }
        public bool find(string str)
        {
            bool result;
            char[] one = str.ToCharArray();
            char[] two = new char[one.Length];
            int c = 0;

            bool isDigitPresent = str.Any(x => char.IsDigit(x));
            for (int i = 0; i < str.Length; i++)
            {

                if (!Char.IsLetterOrDigit(one[i]))
                {
                    two[c] = one[i];
                    c++;
                    result = true;
                    break;
                }
            }
            return false;
        }
    }
}