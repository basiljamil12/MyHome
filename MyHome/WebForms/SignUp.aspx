<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="MyHome.WebForms.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .maindiv {
            margin-left: 395px;
            margin-top: 20px;
            width: 400px;
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
            min-width: 140px;
            padding: 2px 2px;
            text-decoration: none;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
            white-space: nowrap;
            height: 20px;
            cursor: pointer;
            display:inline-block;
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

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">

            <p class="btext">NEW SIGNUP</p>
            <br />
            <br />
            <p class="text">First Name</p>
            <asp:TextBox ID="firsttxt" MaxLength="20" class="inputs" runat="server"></asp:TextBox>
            
            <P class="text">Last Name</P>
            <asp:TextBox ID="lasttxt" MaxLength="20" class="inputs" runat="server"></asp:TextBox>
            
            <p class="text">Username</p>
            <asp:TextBox ID="usernametxt" MaxLength="20"  class="inputs" runat="server"></asp:TextBox>
            
            <p class="text">Password</p>
            <asp:TextBox ID="passwordtxt" MaxLength="20" class="inputs" runat="server" TextMode="Password"></asp:TextBox>
            <p class="text">Confirm Password</p>
            <asp:TextBox ID="cpasswordtxt" MaxLength="20" class="inputs" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="signuplbl" runat="server" ForeColor="Maroon" class="text"></asp:Label>
            <br />
            <p class="text">Create account as a new admin <br />or join an existing family?</p>
            
            <asp:Button ID="Button1" runat="server" Height="44px" OnClick="Button1_Click" class="button-63" Text="New Admin" Width="202px" /><br />
            <br />
                        <asp:Button ID="Button2" runat="server" Height="44px" OnClick="Button2_Click" class="button-63" Text="Join Family" Width="202px" />
            <br />
            <asp:Label ID="newadminlbl" runat="server" Text="Add your family name" Visible="False" class="text"></asp:Label>
&nbsp;
            <asp:TextBox ID="newadmintxt" class="inputs" MaxLength="15" runat="server" style="height: 29px" Visible="False" ></asp:TextBox>
            <br />
            <asp:Label ID="joinfamlbl" runat="server" Text="Enter Invite " Visible="False" class="text"></asp:Label>
&nbsp;
            <asp:TextBox ID="joinfamtxt" class="inputs" runat="server" Visible="False"></asp:TextBox>
&nbsp;<asp:Label ID="inverrlbl" runat="server"></asp:Label>
            <br /><br />
            <asp:Label ID="Label1"  runat="server" Text="Upload an Image" Visible="False"></asp:Label>
            <br /><br />
            <asp:FileUpload ID="FileUpload1" runat="server" accept=".png,.jpg,.jpeg,.gif" Visible="False" />
            <br />
            <br />
            <asp:Button ID="crtaccbtn1" runat="server" OnClick="crtaccbtn1_Click" class="button-63" Text="Create Account" Visible="False" />
            <br />
            <asp:Button ID="crtaccbtn2" runat="server" OnClick="crtaccbtn2_Click" class="button-63" Text="Create Account" Visible="False" />
            <br />
            <br />
            <br />
            <p class="text">Already have and account?</p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForms/SignIn.aspx" class="text">SignIn Instead</asp:HyperLink>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
