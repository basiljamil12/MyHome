<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProf.aspx.cs" Inherits="MyHome.WebForms.ViewProf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .button-63 {
            align-items: center;
            background-color: indianred;
            border: 0;
            border-radius: 8px;
            box-shadow: rgba(151, 65, 252, 0.2) 0 15px 30px -5px;
            box-sizing: border-box;
            color: #FFFFFF;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
            justify-content: center;
            line-height: 1em;
            max-width: 100%;
            height: 20px;
            min-width: 140px;
            padding: 2px 2px;
            text-decoration: none;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
            white-space: nowrap;
            cursor: pointer;
            display:inline-block;
        }
         .button-63:active,
        .button-63:hover {
            outline: 0;
        }
         .nav{
            background-image: linear-gradient(144deg,#AF40FF, #5B42F3 50%,#00DDEB);
            border: 0;
            border-radius: 8px;
            margin: 0px 0px 5px 0px;
        }
        .outnav{
            background-image: linear-gradient(144deg,#AF40FF, #5B42F3 50%,#00DDEB);
            border: 0;
            border-radius: 8px;
            padding: 5px;
            
        }
        .navbtns{
            padding-top:3px;
            background-color: transparent;
    background-repeat: no-repeat;
    border: none;
    cursor: pointer;
    overflow: hidden;
    outline: none;
    color: whitesmoke;
        }
        .navbtns:hover {
  opacity: 70%;
}
        .maindiv {
            margin-left: 355px;
            margin-top: 20px;
            width: 490px;
            text-align: center;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
            border-radius: 5px;
            display: inline-block;
        }
        .text {
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }
        .btext {
            font-family: Tahoma, sans-serif;
            font-size: 20px;
            font-weight: bold;
        }
        .inputs {
            font-size: 14px;
            border-radius: 6px;
            line-height: 1.5;
            padding: 5px 10px;
            transition: box-shadow 100ms ease-in, border 100ms ease-in, background-color 100ms ease-in;
            border: 2px solid #dee1e2;
            color: rgb(14, 14, 16);
            background: #dee1e2;
            width: 80%;
            height: 30px;
        }

            .inputs :hover {
                border-color: #ccc;
            }

            .inputs:focus {
                border-color: #9147ff;
                background: #fff;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="outnav">
        <div class="nav">
            <asp:Button ID="Button1" runat="server" class="navbtns" OnClick="Button1_Click" Text="Sticky Notes &amp; Announcements" Width="250px" />
            <asp:Button ID="Button3" runat="server" class="navbtns" OnClick="Button3_Click" Text="Chatroom" Width="234px" />
            <asp:Button ID="Button4" runat="server" class="navbtns" OnClick="Button4_Click" Text="Photo Gallery" Width="250px" />
            <asp:Button ID="Button6" runat="server" class="navbtns" OnClick="Button6_Click" Text="View Profile" Width="214px" />
            <asp:Button ID="Button5" runat="server" class="navbtns" OnClick="Button5_Click" Text="Sign Out" Width="208px" />
            <br />
            <br />
            </div>
            </div>
        <div class="maindiv">
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" />
            <br />
            <br />
            <p class="btext">User Details</p>
            
            <p class="text">First Name</p>
            <asp:TextBox ID="fnametxt" class="inputs" runat="server" ReadOnly="True"></asp:TextBox>
            
            <p class="text">Last Name</p>
            <asp:TextBox ID="lnametxt" class="inputs" runat="server" ReadOnly="True"></asp:TextBox>
            
            <p class="text">Userame</p>
            <asp:TextBox ID="unametxt" class="inputs" runat="server" ReadOnly="True"></asp:TextBox>
            
            <p class="text">IsAdmin</p>
            <asp:TextBox ID="isadmintxt" class="inputs" runat="server" OnTextChanged="isadmintxt_TextChanged" ReadOnly="True"></asp:TextBox>
            
            <p class="text">Password</p>
            <asp:TextBox ID="passwordtxt" class="inputs" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <P class="btext">Group Details</P>
            
            <p class="text">Group Name</p>
            <asp:TextBox ID="groupnametxt" class="inputs" runat="server" OnTextChanged="groupnametxt_TextChanged" ReadOnly="True"></asp:TextBox>
            
            <p class="text">Group Invite</p>
            <asp:TextBox ID="groupinvitetxt" class="inputs" runat="server" ReadOnly="True"></asp:TextBox>
            <p class="text">Group Members</p>
            <% for (int i = 0; i < members.Length; i++)
                {%>
            <input id="Text1" type="text" class="inputs" value="<%: members[i] %>" readonly />
            <br /><br />
               
            <%} %>
            <br />
            <br />
            <br />
            <asp:Button ID="Button8" runat="server" class="button-63" OnClick="Button8_Click" Text="Delete Account" Width="119px" /> <br/>
            <asp:Label ID="warnlbl" runat="server" ForeColor="Maroon" class="text">This action is not reversable <br /> Do you wish to delete all your data?</asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" class="button-63"  Text="Confirm Delete" Width="119px" OnClick="Button2_Click" />
            <br />
        </div>

    </form>
</body>
</html>
