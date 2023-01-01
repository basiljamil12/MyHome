<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncenNotes.aspx.cs" Inherits="MyHome.WebForms.AnnouncenNotes" %>

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
        .flex-container {
            display: flex;
        }

        .flex-child {
            flex: 1;
            text-align: center;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
            border-radius: 5px;
        }

            .flex-child:first-child {

                margin-right: 20px;
            }

        .rectangle {
            width: 400px;
            text-align:left;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
            border-radius: 5px;
            border-color: #800080;
            margin-left: 70px;
            margin-right: 50px;
            margin-top: 10px;
            margin-bottom: 10px;
            padding-left: 9px;
            padding-right: 9px;
            padding-top: 3px;
            padding-bottom: 3px;
        }

        .rectanglesticky {
            width: 400px;
            text-align:left;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
            border-radius: 5px;
            margin-left: 75px;
            margin-right: 50px;
            margin-top: 10px;
            margin-bottom: 10px;
            padding-left: 9px;
            padding-right: 9px;
            padding-top: 3px;
            padding-bottom: 3px;
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
        
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="outnav">
        <div class="nav">
            <asp:Button ID="Buttn5" runat="server" class="navbtns" Text="Sticky Notes &amp; Announcements" Width="250px" OnClick="Buttn5_Click" />
            <asp:Button ID="Buttn6" runat="server" class="navbtns" Text="Chatroom" Width="198px" OnClick="Buttn6_Click" />
            <asp:Button ID="Buttn7" runat="server" class="navbtns" Text="Photo Gallery" Width="221px" OnClick="Buttn7_Click" />
            <asp:Button ID="Buttn8" runat="server" class="navbtns" Text="View Profile" Width="225px" OnClick="Buttn8_Click" />
            <asp:Button ID="Buttn9" runat="server" class="navbtns" Text="Sign Out" Width="220px" OnClick="Buttn9_Click" />
            </div>
        </div>
        <div class="flex-container">
            <div class="flex-child">
                <br />
                <p class="btext">Annoucements</p>
                <asp:Button ID="Button1" runat="server" class="button-63" Text="+Add" OnClick="Button1_Click" /><br />
                <br />
            <%if (taskName != null)
                    {  %>
                <%for (int i = 0; i < taskBy.Length; i++)
                    {
                %>
                <div class="rectangle">
                    <p class="texta"><%: taskBy[i].ToUpper() %></p>                    
                    <p class="textn"><%: taskName[i] %> </p>
                </div>
                <% }  %>
                <%} else { %>
                <asp:Label ID="Label1" runat="server" class="text" Text="No Annoucements Made"></asp:Label>
                         <%   }  %>

                <br />
                <asp:Button ID="Button3" runat="server" class="button-63" Text="View All" OnClick="Button3_Click" />
                <br />
                <br />
            </div>
            <div class="flex-child">
                <br />
                <p class="btext">Sticky Notes</p>
                <asp:Button ID="Button2" runat="server" class="button-63" Text="+Add" OnClick="Button2_Click" /><br />
                <br />
                <%if (noteBy != null)
                    {  %>
                <%for (int i = 0; i < noteBy.Length; i++)
                    {
                %><div class="rectanglesticky">
                        <p class="texta"><%: noteBy[i].ToUpper() %></p>                    
                    <p class="textn"><%: noteCont[i] %> </p>
                    </div>
                <% }  %>
                <%} else { %>
                <asp:Label ID="Label2" runat="server" class="text" Text="No Notes Made"></asp:Label>
                         <%   }  %>
                <br />
                <asp:Button ID="Button4" runat="server" class="button-63" Text="View All" OnClick="Button4_Click" />
                <br />
                <br />
            </div>
        </div>
    </form>

</body>
</html>
