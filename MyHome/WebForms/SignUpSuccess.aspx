<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpSuccess.aspx.cs" Inherits="MyHome.WebForms.SignUpSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .maindiv {
            margin-left: 450px;
            margin-top: 90px;
            width: 250px;
            text-align: center;
            box-shadow: rgba(17, 17, 26, 0.1) 0px 1px 0px, rgba(17, 17, 26, 0.1) 0px 8px 24px, rgba(17, 17, 26, 0.1) 0px 16px 48px;
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
            height: 30px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <br />
            <br />
            <p class="text">Account created successfully<br />Welcome to the family</p>
            <br />
            <p class="text">Proceed to Sign In?</p>
            <br />
            <asp:Button ID="Button1" runat="server" class="button-63" OnClick="Button1_Click" Text="Sign In" Width="220px" />
            <br />
            <br />
        </div>
        <div>
        </div>
    </form>
</body>
</html>
