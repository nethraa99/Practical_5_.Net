The Academic Calendar & Leave Management System is developed using ASP.NET Web Forms and C#. It uses:

Rich Controls: The Calendar control is used to select the leave date.
Validation Controls: RequiredFieldValidator is used to validate login and leave form fields.
Session: Stores the logged-in username, selected leave date, and leave details between pages.
Cookies: Used for the Remember Me feature so the user can access the system without logging in again.
Page Authentication: Session/Cookie checking prevents unauthorized direct access to pages.
Calendar & Date Validation: Allows only valid leave dates.
Logout: Session.Clear() and Session.Abandon() remove session data, and the login cookie is deleted.
