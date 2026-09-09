
using System;
using System.Web;

namespace Practical_5_Final
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check whether Remember Me cookie exists
                HttpCookie loginCookie = Request.Cookies["LoginDetails"];

                if (loginCookie != null)
                {
                    string username = loginCookie["Username"];

                    if (!string.IsNullOrEmpty(username))
                    {
                        // Restore username in session
                        Session["userid"] = username;

                        // Directly go to Default page
                        Response.Redirect("Default.aspx");
                    }
                }

                // Keep fields empty on first page load
                userid.Text = "";
                Password.Text = "";
                errorLbl.Text = "";
            }
        }

        protected void LoginSubmit_Click(object sender, EventArgs e)
        {
            // First validate ASP.NET validators
            if (!Page.IsValid)
            {
                return;
            }

            string username = userid.Text.Trim();
            string password = Password.Text.Trim();

            // Check username and password
            if (username == "student" && password == "1234")
            {
                // Create username session only after successful login
                Session["userid"] = username;

                // Check Remember Me
                if (CheckBox1.Checked)
                {
                    HttpCookie loginCookie = new HttpCookie("LoginDetails");

                    loginCookie["Username"] = username;

                    // Cookie valid for 30 minutes
                    loginCookie.Expires = DateTime.Now.AddMinutes(30);

                    Response.Cookies.Add(loginCookie);
                }
                else
                {
                    // If Remember Me is not checked,
                    // make sure old cookie is deleted
                    if (Request.Cookies["LoginDetails"] != null)
                    {
                        HttpCookie deleteCookie =
                            new HttpCookie("LoginDetails");

                        deleteCookie.Expires = DateTime.Now.AddDays(-1);

                        Response.Cookies.Add(deleteCookie);
                    }
                }

                // Go to calendar page
                Response.Redirect("Default.aspx");
            }
            else
            {
                // Invalid username/password
                errorLbl.Text =
                    "Invalid username or password. Please try again.";

                // Clear fields
                userid.Text = "";
                Password.Text = "";
            }
        }
    }
}

