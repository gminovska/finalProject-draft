<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fans.aspx.cs" Inherits="Fans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Welcome to your Fan Page!</h1>
        <h2>Select an artist you would like to follow</h2>
        <asp:DropDownList ID="ArtistDropDownList" runat="server"></asp:DropDownList>
        <asp:Button ID="FollowArtist" runat="server" Text="Follow Artist" OnClick="FollowArtistButton_Click" />
        <asp:Label ID="artistAdded" runat="server" Text=""></asp:Label>
        <div id="follow">
        <h2>You are currently following these artists:</h2>
        <asp:RadioButtonList ID="followArtistRadioButtonList" runat="server"></asp:RadioButtonList>
            </div>
        
        <h2>Select the artist you would like to see all the shows for</h2>
        <asp:Button ID="ShowsbyArtist" runat="server" Text="Shows per Artist" OnClick="ShowsbyArtistButton_Click" />
        <asp:GridView ID="ShowGridView" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
