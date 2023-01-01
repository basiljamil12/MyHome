<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoGallery.aspx.cs" Inherits="MyHome.WebForms.PhotoGallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .gallerycontainer{
            text-align: center;
        }
        .imagecontainer{
            display:inline-block;
            width:330px;
            height:300px;
            border: 1px solid black;
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
        .btext {
            font-family: Tahoma, sans-serif;
            font-size: 25px;
            font-weight: bold;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="outnav">
        <div class="nav">
            <asp:Button ID="Button1" class="navbtns"  runat="server" OnClick="Button1_Click" Text="Sticky Notes &amp; Announcements" Width="250px" />
            <asp:Button ID="Button3" class="navbtns" runat="server" OnClick="Button3_Click" Text="Chatroom" Width="229px" />
            <asp:Button ID="Button4" class="navbtns" runat="server" OnClick="Button4_Click" Text="Photo Gallery" Width="233px" />
            <asp:Button ID="Button6" class="navbtns" runat="server" OnClick="Button6_Click" Text="View Profile" Width="229px" />
            <asp:Button ID="Button5" class="navbtns" runat="server" OnClick="Button5_Click" Text="Sign Out" Width="223px" />
            </div>
            </div>
        <div>
        <div>
            <br />
            <br />
            
            <p class="btext">&nbsp;&nbsp;Photo Gallery</p>
            <br />
            <div style="text-align:center">
                 <asp:FileUpload ID="FileUpload1" runat="server" accept=".png,.jpg,.jpeg,.gif" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button7" runat="server" class="button-63" Text="+Add" OnClick="Button7_Click" /><br /><br />
            </div>
           
            
            
        </div>
        <div class="gallerycontainer">
            
            
    <div style="text-align:center">
       
        <asp:GridView ID="GridView1" runat="server" BorderWidth="0px" CellPadding="5" CellSpacing="1" Font-Names="Tahoma" Font-Size="17pt" GridLines="None" ShowHeader="False" Width="100%">
        <Columns>
            
            <asp:TemplateField HeaderText="Photo">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server"  ImageUrl='<%#"data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Image")) %>'/>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
       
    </div>
        </div>
            </div>
    </form>

</body>
</html>
