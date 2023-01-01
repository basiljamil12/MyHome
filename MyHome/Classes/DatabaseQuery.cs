using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MyHome.Classes
{
    public class DatabaseQuery
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        public bool CheckUsernameAval(string username)
        {
            conn.Open();
            string qry = "exec CheckUsername '" + username + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                conn.Close();
                return false;
            }

            else
            {
                conn.Close();
                return true;
            }
        }
        public void InIn(int userid)
        {
            conn.Open();
            string qry = "exec InIn '" + userid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public bool CheckUserSignin(string username, string password)
        {

            conn.Open();
            string qry = "exec AuthUser '" + username + "','" + password + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                conn.Close();
                return true;
            }

            else
            {
                conn.Close();
                return false;
            }
        }
        public void UpdateLogged(int userid)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update loggedin set logged = '1' where userid = " + userid, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdatedLogOut(int userid)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update loggedin set logged = '0' where userid = " + userid, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public bool CheckLogin(int userid)
        {
            bool returnlog = false;
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select logged from loggedin where userid = " + userid, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["logged"].ToString().Equals("1"))
                {
                    returnlog = true;
                }
                else if (dr["logged"].ToString().Equals("0"))
                {
                    returnlog = false;
                }
            }
            dr.Close();
            conn.Close();
            return returnlog;
        }
        public int GetIdOnSignIn(string username, string password)
        {
            int id = 0;
            conn.Open();
            string qry = "exec ReturnID '" + username + "','" + password + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                id = Convert.ToInt32(sdr.GetValue(0));
            }
            conn.Close();
            return id;
        }
        public bool SignupUser(string firstname, string lastname, string username, string password, int groupid, byte[] img, int joingroup)
        {
            try
            {
                conn.Open();
                string qry;
                if (joingroup == 1) //if joingroup = 1 the user doesnt want to be an admin
                    qry = "exec AddUser '" + groupid + "','" + firstname + "','" + lastname + "','" + 0 + "','" + username + "','" + password + "','" + img + "'";
                else // if the groupid != 1 the user wants to create a new group and be an admin
                    qry = "exec AddUser '" + groupid + "','" + firstname + "','" + lastname + "','" + 1 + "','" + username + "','" + password + "','" + img + "'";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                throw;
                return false;
            }
        }
        public int MakeGroup(string groupname)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("MakeGroup", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paraName = new SqlParameter()
                {
                    ParameterName = "@GroupName",
                    Value = groupname
                };
                cmd.Parameters.Add(paraName);

                SqlParameter paraInvite = new SqlParameter()
                {
                    ParameterName = "@GroupInvite",
                    Value = (groupname + DateTime.Now.ToString("MM/dd/yyyy/HH:mm:ss"))
                };
                cmd.Parameters.Add(paraInvite);

                SqlParameter paraId = new SqlParameter()
                {
                    ParameterName = "@GroupID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paraId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return Convert.ToInt32(cmd.Parameters["@GroupID"].Value);
            }
            catch
            {
                throw;
            }

        }
        public int GetGroupIDByInvite(string invite)
        {
            int id = 0;
            conn.Open();
            string qry = "exec GetGroupID '" + invite + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                id = Convert.ToInt32(sdr.GetValue(0));
            }
            conn.Close();
            return id;
        }

        public string[] GetUserInfo(int id)
        {
            string[] list = new string[8];
            conn.Open();
            string qry = "exec GetInfo '" + id + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                list[0] = sdr.GetValue(0).ToString();
                list[1] = sdr.GetValue(1).ToString();
                list[2] = sdr.GetValue(2).ToString();
                list[3] = sdr.GetValue(3).ToString();
                list[4] = sdr.GetBoolean(4).ToString();
                list[5] = sdr.GetValue(5).ToString();
                list[6] = sdr.GetValue(6).ToString();
            }
            conn.Close();
            return list;
        }
        public byte[] GetImg(int id)
        {
            string base64string = null;
            conn.Open();
            string qry = "exec GetImg '" + id + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            byte[] img = (byte[])cmd.ExecuteScalar();
            conn.Close();
            return img;
            
        }
        public void MakeAnnouncement(int userid, int groupid, string content)
        {
            conn.Open();
            string qry = "exec MakeAnnouncement '" + userid + "','" + groupid + "','" + content + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int GetGroupID(int id)
        {
            int gid = 0;
            conn.Open();
            string qry = "exec GetIDbyID '" + id + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                gid = Convert.ToInt32(sdr.GetValue(0));
            }
            conn.Close();
            return gid;
        }
        public string[] GetAnnNames(int gid)
        {
            string[] taskBy;
            conn.Open();
            string qry = "exec GetAnn '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["FirstName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetAnnContent(int gid)
        {
            string[] taskBy;
            conn.Close();
            
            string qry = "exec GetAnn '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            conn.Open();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["Content"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetAllAnnNames(int gid)
        {
            string[] taskName;
            conn.Open();
            string qry = "exec GetAllAnn '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                taskName = new string[rows2];
                //taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    taskName[j] = dr2["Content"].ToString();
                    //taskBy[j] = dr2["FirstName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskName;
            }
            else
            {
                return null;
            }
        }
        public string[] GetAllAnnContent(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetAllAnn '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["FirstName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetAllAnnTime(int gid)
        {
            string[] taskBy;
            conn.Open();
            string qry = "exec GetAllAnn '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["MadeOn"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public int[] GetNotesID(int gid)
        {
            int[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetNotes '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new int[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = Convert.ToInt32(dr2["NoteID"]);
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetNotesName(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetNotes '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["FirstName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetNotesContent(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetNotes '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["Content"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] CGetNotesContent(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetComNotes '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["Content"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] CGetNotesName(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetComNotes '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["FirstName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] CGetNotesOn(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetComNotes '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["CompletedOn"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] CGetNotesCompBy(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetComNotes '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["CompletedBy"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public void MakeNote(int userid, int groupid, string content)
        {
            conn.Open();
            string qry = "exec MakeNote '" + userid + "','" + groupid + "','" + content + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public string[] GetMessageF(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetMessage '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["FirstName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetMessageL(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetMessage '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["LastName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetMessageC(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetMessage '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["Content"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetMessageT(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetMessage '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["SentOn"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public int[] GetMessageID(int gid)
        {
            int[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetMessage '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new int[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = Convert.ToInt32(dr2["UserID"]);
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] FirstnLast(int gid)
        {
            string[] fname = GetMessageF(gid);
            string[] lname = GetMessageL(gid);
            if (lname != null)
            {
                string[] names = new string[lname.Length];

                for (int i = 0; i < lname.Length; i++)
                {
                    names[i] = fname[i] + " " + lname[i];
                }
                return names;

            }
            else
                return null;
        }
        public void AddMessage(string content, int userid, int gid)
        {
            conn.Open();
            string qry = "exec AddMessage '" + userid + "','" + gid + "','" + content + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteUser(int userid)
        {
            conn.Open();
            string qry = "exec DelImage '" + userid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            //conn.Close();
            //conn.Open();
            qry = "exec DelMessage '" + userid + "'";
            cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            //conn.Close();
            //conn.Open();
            qry = "exec DelNote '" + userid + "'";
            cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            //conn.Close();
            //conn.Open();
            qry = "exec DelAnn '" + userid + "'";
            cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            //conn.Close();
            qry = "exec DelUser '" + userid + "'";
            cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public string[] GetMembersLast(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetMembers '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["LastName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetMembersFirst(int gid)
        {
            string[] taskBy;
            conn.Close();
            conn.Open();
            string qry = "exec GetMembers '" + gid + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int rows2 = dt2.Rows.Count;
            if (rows2 > 0)
            {
                SqlDataReader dr2 = cmd.ExecuteReader();
                //taskName = new string[rows2];
                taskBy = new string[rows2];
                int j = 0;
                while (dr2.Read())
                {
                    //taskName[j] = dr2["Content"].ToString();
                    taskBy[j] = dr2["FirstName"].ToString();
                    j++;
                }
                dr2.Close();
                conn.Close();
                return taskBy;
            }
            else
            {
                return null;
            }
        }
        public string[] GetMembers(int gid)
        {
            string[] fname = GetMembersFirst(gid);
            string[] lname = GetMembersLast(gid);
            if (lname != null)
            {
                string[] names = new string[lname.Length];

                for (int i = 0; i < lname.Length; i++)
                {
                    names[i] = fname[i] + " " + lname[i];
                }
                return names;

            }
            else
                return null;
        }

    }
}