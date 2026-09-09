
using System;
using System.Web;

namespace Practical_5_Final
{
    public partial class Leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check whether user is logged in
            if (Session["userid"] == null)
            {
                // Check Remember Me cookie
                HttpCookie loginCookie =
                    Request.Cookies["LoginDetails"];

                if (loginCookie != null &&
                    !string.IsNullOrEmpty(loginCookie["Username"]))
                {
                    // Restore session
                    Session["userid"] =
                        loginCookie["Username"];
                }
                else
                {
                    // User is not logged in
                    Response.Redirect("Login.aspx");
                    return;
                }
            }

            if (!IsPostBack)
            {
                // Clear fields initially
                txtEmployeeName.Text = "";
                txtReason.Text = "";
                txtLoadAdjusted.Text = "";

                ddlLeaveType.SelectedIndex = 0;

                lblError.Text = "";
                pnlSummary.Visible = false;

                // Get selected date from Session
                if (Session["LeaveDate"] != null)
                {
                    DateTime leaveDate =
                        (DateTime)Session["LeaveDate"];

                    // Display selected date
                    lblLeaveDateValue.Text =
                        leaveDate.ToShortDateString();
                }
                else
                {
                    // No date selected
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Validate all ASP.NET validators
            if (!Page.IsValid)
            {
                return;
            }

            // Check leave date session
            if (Session["LeaveDate"] == null)
            {
                lblError.Text =
                    "Leave date is missing. Please select a date again.";

                return;
            }

            // Get values
            string employeeName =
                txtEmployeeName.Text.Trim();

            string leaveType =
                ddlLeaveType.SelectedValue;

            string reason =
                txtReason.Text.Trim();

            string loadAdjusted =
                txtLoadAdjusted.Text.Trim();

            DateTime leaveDate =
                (DateTime)Session["LeaveDate"];

            // Additional date validation
            if (leaveDate.Date < DateTime.Today)
            {
                lblError.Text =
                    "Invalid leave date. Please select today or a future date.";

                return;
            }

            // Store leave details in Session
            Session["EmployeeName"] = employeeName;
            Session["LeaveType"] = leaveType;
            Session["Reason"] = reason;
            Session["LoadAdjustedWith"] = loadAdjusted;

            // Create final leave session
            Session["LeaveDetails"] = true;

            // Display summary
            lblSummary.Text =
                "<b>Employee Name:</b> " +
                Server.HtmlEncode(employeeName) +
                "<br/><br/>" +

                "<b>Leave Date:</b> " +
                leaveDate.ToShortDateString() +
                "<br/><br/>" +

                "<b>Leave Type:</b> " +
                Server.HtmlEncode(leaveType) +
                "<br/><br/>" +

                "<b>Reason:</b> " +
                Server.HtmlEncode(reason) +
                "<br/><br/>" +

                "<b>Load Adjusted With:</b> " +
                Server.HtmlEncode(loadAdjusted);

            lblError.Text =
                "Leave application submitted successfully.";

            pnlSummary.Visible = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear all session data
            Session.Clear();

            // Destroy session
            Session.Abandon();

            // Delete Remember Me cookie
            if (Request.Cookies["LoginDetails"] != null)
            {
                HttpCookie deleteCookie =
                    new HttpCookie("LoginDetails");

                deleteCookie.Expires =
                    DateTime.Now.AddDays(-1);

                Response.Cookies.Add(deleteCookie);
            }

            // Redirect to Login
            Response.Redirect("Login.aspx");
        }
    }
}

