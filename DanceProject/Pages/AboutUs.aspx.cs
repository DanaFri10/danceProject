using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.TypeClasses;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class AboutUs : System.Web.UI.Page
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

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Notifications.aspx");
        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
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