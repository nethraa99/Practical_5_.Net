
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="Practical_5_Final.Leave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Leave Application Form</title>
</head>

<body>

    <form id="form1" runat="server">

        <h2>Leave Application</h2>

        <br />

        <!-- EMPLOYEE NAME -->

        <asp:Label ID="Label1"
            runat="server"
            Text="Employee Name: ">
        </asp:Label>

        <asp:TextBox ID="txtEmployeeName"
            runat="server">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvEmployeeName"
            runat="server"
            ControlToValidate="txtEmployeeName"
            ErrorMessage="Employee name is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br />
        <br />

        <!-- LEAVE DATE -->

        <asp:Label ID="Label2"
            runat="server"
            Text="Leave Date: ">
        </asp:Label>

        <asp:Label ID="lblLeaveDateValue"
            runat="server"
            Font-Bold="true">
        </asp:Label>

        <br />
        <br />

        <!-- LEAVE TYPE -->

        <asp:Label ID="Label3"
            runat="server"
            Text="Leave Type: ">
        </asp:Label>

        <asp:DropDownList ID="ddlLeaveType"
            runat="server">

            <asp:ListItem
                Text="Select Leave Type"
                Value="">
            </asp:ListItem>

            <asp:ListItem
                Text="Casual Leave (CL)"
                Value="Casual Leave">
            </asp:ListItem>

            <asp:ListItem
                Text="Sick Leave (SL)"
                Value="Sick Leave">
            </asp:ListItem>

            <asp:ListItem
                Text="Earned Leave (EL)"
                Value="Earned Leave">
            </asp:ListItem>

        </asp:DropDownList>

        <asp:RequiredFieldValidator
            ID="rfvLeaveType"
            runat="server"
            ControlToValidate="ddlLeaveType"
            InitialValue=""
            ErrorMessage="Please select leave type."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br />
        <br />

        <!-- REASON -->

        <asp:Label ID="Label4"
            runat="server"
            Text="Reason: ">
        </asp:Label>

        <asp:TextBox ID="txtReason"
            runat="server"
            TextMode="MultiLine"
            Rows="3">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvReason"
            runat="server"
            ControlToValidate="txtReason"
            ErrorMessage="Reason is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br />
        <br />

        <!-- LOAD ADJUSTMENT -->

        <asp:Label ID="Label5"
            runat="server"
            Text="Load Adjusted With (Colleague Name): ">
        </asp:Label>

        <asp:TextBox ID="txtLoadAdjusted"
            runat="server">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvLoadAdjusted"
            runat="server"
            ControlToValidate="txtLoadAdjusted"
            ErrorMessage="Colleague name is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br />
        <br />

        <!-- SUBMIT -->

        <asp:Button ID="BtnSubmit"
            runat="server"
            Text="SUBMIT"
            OnClick="BtnSubmit_Click" />

        <br />
        <br />

        <asp:Label ID="lblError"
            runat="server"
            ForeColor="Red">
        </asp:Label>

        <!-- SUMMARY -->

        <asp:Panel ID="pnlSummary"
            runat="server"
            Visible="false">

            <hr />

            <h2>Submitted Leave Details</h2>

            <asp:Label ID="lblSummary"
                runat="server">
            </asp:Label>

            <br />
            <br />

            <asp:Button ID="btnLogout"
                runat="server"
                Text="Logout"
                OnClick="btnLogout_Click" />

        </asp:Panel>

    </form>

</body>

</html>

