<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllNotes.aspx.cs" Inherits="MyHome.WebForms.AllNotes" %>

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
        .texta {
            color: #800080;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }
        .textn {
            color: #00008B;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }
        .rectangle {
            width: 400px;
            text-align:left;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
            border-radius: 5px;
            border-color: #800080;
            margin-left: 390px;
            margin-right: 50px;
            margin-top: 10px;
            margin-bottom: 10px;
            padding-left: 9px;
            padding-right: 9px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <div class="outnav">
        <div class="nav">
            <asp:Button ID="Button1" class="navbtns" runat="server" OnClick="Button1_Click" Text="Sticky Notes &amp; Announcements" Width="250px" />
            <asp:Button ID="Button3" class="navbtns" runat="server" OnClick="Button3_Click" Text="Chatroom" Width="220px" />
            <asp:Button ID="Button4" class="navbtns" runat="server" OnClick="Button4_Click" Text="Photo Gallery" Width="250px" />
            <asp:Button ID="Button6" class="navbtns" runat="server" OnClick="Button6_Click" Text="View Profile" Width="228px" />
            <asp:Button ID="Button5" class="navbtns" runat="server" OnClick="Button5_Click" Text="Sign Out" Width="222px" />
            </div>
            </div>
  
            <%if (noteBy != null)
                    {  %>
                <%for (int i = 0; i < noteBy.Length; i++)
                    {
                %>
                <div class="rectangle">
                    <p class="texta"><%: noteBy[i] %></p>                    
                    <p class="textn"><%: noteCont[i] %> </p>
                </div>
                <% }  %>
                <%} else { %>
                <asp:Label ID="Label1" runat="server" Text="No Annoucements Made"></asp:Label>
                         <%   }  %>
      
    </form>
</body>
</html>
