<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chatroom.aspx.cs" Inherits="MyHome.WebForms.Chatroom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function scrolla() {
            window.scrollTo(0, document.querySelector(".chatscontainer").body.scrollHeight);
        }
        
    </script>
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
        .text {
            overflow-wrap: break-word;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }
        .txtbottom {
            position: fixed;
            bottom: 30px;
            margin-left: 120px;
            left: -163px;
            width: 1428px;
        }

        .txtbottomborder {
            width: 100%;
            margin-left:200px;
        }

        .alligncenter {
            text-align: center;
        }
        .scrollcont{
            
        }
        .chatscontainer {
            
            position: fixed;
            width: 905px;
            margin-left: 125px;
          
            height: 450px;
            bottom: 80px;
            overflow-y: scroll;
            overflow-x: hidden;
        }

        /* Chat containers */
        .containerleft {
             
           box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            text-align: left;
            border: 2px solid #dedede;
            background-color: #f1f1f1;
            border-radius: 5px;
            padding: 10px;
            margin: 10px;
            width: 500px;
        }

        /* Darker chat container */
        .containerright {
             
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            text-align: right;
            border-color: #ccc;
            background-color: #ddd;
            border-radius: 5px;
            padding: 10px;
            margin: 10px 10px 10px 350px;
            width: 500px;
        }

        /* Clear floats */
        .container::after {
            content: "";
            clear: both;
            display: table;
        }

        /* Style images */
        .container img {
            display: inline-block;
            float: left;
            max-width: 60px;
            width: 100%;
            margin-right: 20px;
            border-radius: 50%;
        }

            /* Style the right image */
            .container img.right {
                display: inline-block;
                float: right;
                margin-left: 20px;
                margin-right: 0;
            }

        .messageleft {
            margin-left: 10px;
            display: inline-block;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }
        .messageleft1 {
            margin-left: 10px;
            display: inline-block;
            color: #00008B;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }

        .messageright {
            margin-right: 10px;
            display: inline-block;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }
        .messageright1 {
            margin-right: 10px;
            display: inline-block;
            color: #800080;
            font-family: Tahoma, sans-serif;
            font-size: 13px;
        }
        .img {
            display: inline-block;
            float: right;
            max-width: 60px;
            width: 100%;
            margin-right: 20px;
            border-radius: 50%;
        }

        .time-right {
            margin-right: 10px;
            font-family: Tahoma, sans-serif;
            font-size: 8px;
            color: #6e6c67;
        }

        .time-left {
            margin-left: 10px;
            font-family: Tahoma, sans-serif;
            font-size: 8px;
            color: #6e6c67;
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
            height: 25px;
        }

            .inputs :hover {
                border-color: #ccc;
            }

            .inputs:focus {
                border-color: #9147ff;
                background: #fff;
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
            height: 40px;
            min-width: 140px;
            padding: 2px 2px;
            text-decoration: none;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
            white-space: nowrap;
            cursor: pointer;
        }
    </style>
</head>
<body onload="scrolla()">
    
    <form id="form1" runat="server">
        <div class="outnav">
        <div class="nav">
            <asp:Button ID="Button1" runat="server" class="navbtns" OnClick="Button1_Click" Text="Sticky Notes &amp; Announcements" Width="250px" />
            <asp:Button ID="Button3" runat="server" class="navbtns" OnClick="Button3_Click" Text="Chatroom" Width="217px" />
            <asp:Button ID="Button4" runat="server" class="navbtns" OnClick="Button4_Click" Text="Photo Gallery" Width="250px" />
            <asp:Button ID="Button6" runat="server" class="navbtns" OnClick="Button6_Click" Text="View Profile" Width="223px" />
            <asp:Button ID="Button5" runat="server" class="navbtns" OnClick="Button5_Click" Text="Sign Out" Width="204px" />
        </div>
            </div>
        <div id="maincon" class="chatscontainer">
            <%if (mID != null)
                {  %><%for (int i = 0; i < mID.Length; i++)
                {
                    if (mID[i] != SessionID)
                    {
            %>
            <div class="containerleft">
                <p class="messageleft1" style="color: blue"><%:By[i].ToUpper() %></p>
                <p class="messageleft"><%:Content[i] %></p>
                <br />
                <span class="time-left"><%:Time[i] %></span>
            </div>
            <%}
                else
                { %>
            <div class="containerright">

                <p class="messageright"><%:Content[i] %></p>
                <p class="messageright1"><%:By[i].ToUpper() %></p>
                <br />
                <span class="time-right"><%:Time[i] %></span>

            </div>
            <%}
                    }
                }
                else
                { %>
            <p>There are no messages available</p>
            <%} %>
  
            </div>
        <div class="txtbottom">
            <div class="txtbottomborder">
                <asp:TextBox ID="messagetypetxt" MaxLength="50" class="inputs" runat="server" Width="701px" style="margin-left: 0px"></asp:TextBox>
                <asp:Button ID="sendbtn" class="button-63" runat="server" Text="Send" Width="113px" OnClick="sendbtn_Click" />

            </div>



        </div>

    </form>
</body>
</html>
