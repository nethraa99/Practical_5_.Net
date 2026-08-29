using System;
using System.Web;

namespace Practical_5_Final
{
    public partial class Leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve date from Session
                if (Session["Leave"] != null)
                {
                    DateTime dt = (DateTime)Session["Leave"];
                    lblLeaveDateValue.Text = dt.ToShortDateString();
                }
                else
                {
                    // If session is empty, send them back to the calendar
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Store form data in a Cookie
            HttpCookie leaveCookie = new HttpCookie("LeaveDetails");
            leaveCookie["EmpName"] = txtEmployeeName.Text;
            leaveCookie["LeaveType"] = ddlLeaveType.SelectedValue;
            leaveCookie["Reason"] = txtReason.Text;
            leaveCookie["LoadAdjusted"] = txtLoadAdjusted.Text;

            // Set cookie expiration
            leaveCookie.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Add(leaveCookie);

            // 2. Read the data back to demonstrate using Session and Cookies
            string leaveDate = "";
            if (Session["Leave"] != null)
            {
                DateTime dt = (DateTime)Session["Leave"];
                leaveDate = dt.ToShortDateString();
            }

            // Populate the summary label with the submitted data
            lblSummary.Text = $"<b>Employee Name:</b> {leaveCookie["EmpName"]}<br/>" +
                              $"<b>Leave Date:</b> {leaveDate}<br/>" +
                              $"<b>Leave Type:</b> {leaveCookie["LeaveType"]}<br/>" +
                              $"<b>Reason:</b> {leaveCookie["Reason"]}<br/>" +
                              $"<b>Load Adjusted With:</b> {leaveCookie["LoadAdjusted"]}<br/>";

            // 3. Make the summary section visible below the form
            pnlSummary.Visible = true;
        }
    }
}