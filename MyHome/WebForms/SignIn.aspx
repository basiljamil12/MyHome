<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="MyHome.WebForms.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .flex-container {
            display: flex;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
            border-radius: 5px;
            width:70%;
            margin-left: 165px;
            margin-top:15px;
        }

        .flex-child {
            flex: 1;
            border-radius: 5px;
            width: 50%;
        }

            .flex-child:first-child {

                margin-right: 20px;
            }
        .maindiv {
            margin-left: 15px;
            margin-top: 50px;
            margin-bottom: 50px;

            width: 250px;
            text-align: center;
            border-radius: 5px;
            display: inline-block;
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

        .button-63:active,
        .button-63:hover {
            outline: 0;
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

            .img{
                           
                margin-top:130px;
                margin-left:100px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="flex-container">
            <div class="flex-child">
                <asp:Image ID="Image1" runat="server" class="img" ImageUrl="~/Images/Untitled.png" />
            </div>
                <div class="flex-child">
        <div class="maindiv">
            

                <br />
               <br />
                <br /><br />
                <p class="text">Username</p>



                <asp:TextBox ID="usernametxt" MaxLength="20" runat="server" class="inputs"></asp:TextBox>
                <br />
                <br />
                <p class="text">Password</p>
                <asp:TextBox ID="passwordtxt" MaxLength="20" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Height="44px" OnClick="Button1_Click" Text="Sign In" Width="202px" class="button-63" />
                <br />
                <asp:Label ID="signinlbl" runat="server" class="text" ForeColor="Maroon"></asp:Label>
                  <br />

                <p class="text">Don&#39;t have an account?</p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForms/SignUp.aspx" class="text">SignUp Instead</asp:HyperLink>
                <br />
                <br />
            </div>
    
       </div>

            </div>
    </form>
</body>
</html>
