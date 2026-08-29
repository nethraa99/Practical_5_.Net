using System;

namespace Practical_5_Final
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Calender_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = Calendar1.SelectedDate;
            // Store the selected date in a Session
            Session["Leave"] = dt;
            Label1.Text = "You selected: " + dt.ToShortDateString();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Check if the session exists before redirecting
            if (Session["Leave"] != null)
            {
                Response.Redirect("Leave.aspx");
            }
            else
            {
                Label1.Text = "Please select a date from the calendar first!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}