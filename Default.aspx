<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Practical_5_Final.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Management - Calendar</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Employee Leave Management System</h2>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calender_SelectionChanged">
        </asp:Calendar>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Selected Date: "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmit" runat="server" Text="Apply for leave" OnClick="BtnSubmit_Click" />
    </form>
</body>
</html>