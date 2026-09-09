
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Practical_5_Final.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Academic Calendar - Leave Management</title>
</head>

<body>

    <form id="form1" runat="server">

        <h2>Academic Calendar & Leave Management System</h2>

        <br />

        <asp:Label ID="Label2" runat="server"
            Font-Bold="true">
        </asp:Label>

        <br />
        <br />

        <h3>Select Leave Date</h3>

        <asp:Calendar ID="Calendar1"
            runat="server"
            OnSelectionChanged="Calender_SelectionChanged">
        </asp:Calendar>

        <br />

        <asp:Label ID="Label1" runat="server"
            Text="Selected Date: ">
        </asp:Label>

        <asp:Label ID="lblSelectedDate"
            runat="server"
            Font-Bold="true">
        </asp:Label>

        <br />
        <br />

        <asp:Label ID="lblError"
            runat="server"
            ForeColor="Red">
        </asp:Label>

        <br />
        <br />

        <asp:Button ID="BtnSubmit"
            runat="server"
            Text="Apply for Leave"
            OnClick="BtnSubmit_Click" />

        <br />
        <br />

        <asp:Button ID="btnLogout"
            runat="server"
            Text="Logout"
            OnClick="btnLogout_Click" />

    </form>

</body>

</html>

