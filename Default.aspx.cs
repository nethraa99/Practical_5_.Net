using System;
using System.Web;

namespace Practical_5_Final
{
    public partial class Default : System.Web.UI.Page
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
                    // Restore session from cookie
                    Session["userid"] =
                        loginCookie["Username"];
                }
                else
                {
                    // No session and no cookie
                    Response.Redirect("Login.aspx");
                    return;
                }
            }

            if (!IsPostBack)
            {
                // Display welcome message
                string username =
                    Session["userid"].ToString();

                Label2.Text =
                    "Welcome, " + username;

                // Keep date fields empty initially
                lblSelectedDate.Text = "";
                lblError.Text = "";
            }
        }

        protected void Calender_SelectionChanged(
            object sender, EventArgs e)
        {
            DateTime selectedDate =
                Calendar1.SelectedDate;

            // Date validation
            if (selectedDate.Date < DateTime.Today)
            {
                lblError.Text =
                    "Invalid date. Please select today or a future date.";

                lblSelectedDate.Text = "";

                // Remove invalid date from session
                Session.Remove("LeaveDate");

                return;
            }

            // Store selected date in session
            Session["LeaveDate"] = selectedDate;

            // Display selected date
            lblSelectedDate.Text =
                selectedDate.ToShortDateString();

            lblError.Text = "";
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Check whether date was selected
            if (Session["LeaveDate"] == null)
            {
                lblError.Text =
                    "Please select a valid leave date first.";

                return;
            }

            // Go to Leave page
            Response.Redirect("Leave.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Remove all sessions
            Session.Clear();
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

            // Go back to login
            Response.Redirect("Login.aspx");
        }
    }
}
