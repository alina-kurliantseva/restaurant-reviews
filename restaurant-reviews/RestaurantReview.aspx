<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RestaurantReview.aspx.cs" Inherits="RestaurantReview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alina Kurliantseva | Restaurant Reviews</title>
    <link rel='stylesheet' runat="server" href='App_Themes/SiteStyles.css' type='text/css' media='all'  />
</head>

<body>
    <h2>Restaurant Reviews</h2>
    <div class="profileForm">
        <form runat="server">
            <label for="drpRestaurants">Restaurants:</label>
            <asp:DropDownList ID="drpRestaurants" runat="server" OnSelectedIndexChanged="drpRestaurants_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:Panel ID="details" runat="server">
                <label for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" ReadOnly="true"></asp:TextBox>
                <label for="txtSummary">Summary:</label>
                <asp:TextBox ID="txtSummary" runat="server"></asp:TextBox>
                <label for="drpRating">Rating:</label>
                <asp:DropDownList ID="drpRating" runat="server">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                </asp:DropDownList>
                <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" /><br />
                <asp:Label ID="lblConfirmation" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </form>
    </div>
</body>
</html>
