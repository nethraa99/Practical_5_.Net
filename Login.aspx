
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practical_5_Final.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Leave Management System</title>
</head>

<body>

    <form id="form1" runat="server">

        <h2>Academic Calendar & Leave Management System</h2>

        <br />

        <!-- USERNAME -->

        <asp:Label ID="lblUserId" runat="server"
            Text="User ID: ">
        </asp:Label>

        <asp:TextBox ID="userid" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvUserId"
            runat="server"
            ControlToValidate="userid"
            ErrorMessage="User ID is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br />
        <br />

        <!-- PASSWORD -->

        <asp:Label ID="lblPassword" runat="server"
            Text="Password: ">
        </asp:Label>

        <asp:TextBox ID="Password" runat="server"
            TextMode="Password">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvPassword"
            runat="server"
            ControlToValidate="Password"
            ErrorMessage="Password is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br />
        <br />

        <!-- REMEMBER ME -->

        <asp:CheckBox ID="CheckBox1" runat="server"
            Text="Remember Me" />

        <br />
        <br />

        <!-- LOGIN BUTTON -->

        <asp:Button ID="Button1" runat="server"
            Text="Login"
            OnClick="LoginSubmit_Click" />

        <br />
        <br />

        <asp:Label ID="errorLbl" runat="server"
            ForeColor="Red">
        </asp:Label>

    </form>

</body>
</html>

