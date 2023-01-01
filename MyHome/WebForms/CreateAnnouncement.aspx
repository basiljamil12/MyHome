<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAnnouncement.aspx.cs" Inherits="MyHome.WebForms.CreateAnnouncement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
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
        .button-63 {
            align-items: center;
            background-image: linear-gradient(144deg,#AF40FF, #5B42F3 50%,#00DDEB);
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
            min-width: 140px;
            padding: 2px 2px;
            text-decoration: none;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
            white-space: nowrap;
            cursor: pointer;
            height: 25px;
      
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
        .maindiv {
            margin-left: 420px;
            margin-top: 90px;
            padding: 10px;
            width: 340px;
            text-align: center;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
            border-radius: 5px;
            display: inline-block;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="outnav">
        <div class="nav">
            <asp:Button ID="Buttn2" class="navbtns" runat="server" Text="Sticky Notes &amp; Announcements" Width="250px" OnClick="Buttn2_Click" />
            <asp:Button ID="Buttn3" class="navbtns" runat="server" Text="Chatroom" Width="224px" OnClick="Buttn3_Click" />
            <asp:Button ID="Buttn4" class="navbtns" runat="server" Text="Photo Gallery" Width="250px" OnClick="Buttn4_Click" />
            <asp:Button ID="Buttn6" class="navbtns" runat="server" Text="View Profile" Width="201px" OnClick="Buttn6_Click" />
            <asp:Button ID="Buttn5" class="navbtns" runat="server" Text="Sign Out" Width="197px" OnClick="Buttn5_Click" />
            </div>
            </div>
        <div class="maindiv">
            <br />
            <asp:Label ID="Label2" class="btext" runat="server" Text="Make Announcements"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="announcetxt" class="inputs" MaxLength="50" runat="server" Height="50px" TextMode="MultiLine" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" class="text" ForeColor="Maroon" runat="server" Text="note: all the announcements automatically dissapear after 24 hours."></asp:Label>
            <br />
            <br />
            <div>
                <asp:Button ID="Button1" class="button-63" runat="server" OnClick="Button1_Click" Text="Make Announcement" /><br /><br />
                
            </div>
        </div>
    </form>
</body>
</html>
