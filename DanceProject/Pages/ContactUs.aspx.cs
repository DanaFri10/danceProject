using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.TypeClasses;
using DanceProject.ServiceClasses;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User u = (User)Session["User"];
                if (u.IsAdmin) // תפריט לאדמין
                {
                    Menu1.Visible = true;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                }
                else
                {
                    if (u.UserCategory.ToString() == "1") //תפריט לכראוגרף
                    {
                        Menu1.Visible = false;
                        Menu2.Visible = true;
                        Menu3.Visible = false;
                    }
                    else//תפריט לרקדן
                    {
                        Menu1.Visible = false;
                        Menu2.Visible = false;
                        Menu3.Visible = true;
                    }
                }
                Hi.Text = "Hi, " + u.UserFirstName + " " + u.UserLastName + "!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
 
            User u = (User)Session["User"];

            string x=u.UserEmail.ToString();
            EmailService.SendEmail(TextBox1.Text +" User's email: "+u.UserEmail, TextBox2.Text, "2021danceproject@gmail.com" );
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"Your email was sent to us!.\");", true);
        }

        protected void Menu3_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }

        }
    }
}