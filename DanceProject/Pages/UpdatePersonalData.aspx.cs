using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.TypeClasses;
using DanceProject.ServiceClasses;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Data;

namespace DanceProject.Pages
{
    public partial class UpdatePersonalData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User u = UserService.FindUserById((DataTable)Session["Users"], Session["SelectedUser"].ToString());
                if(u.UserCategory=="1") DropDownList1.SelectedValue = "Choreographer";
                else DropDownList1.SelectedValue = "Dancer";

                Label11.Text = u.UserId;// הכנסת הפרטים האישיים של המשתמש
                UserPassword.Text = u.UserPassword;
                UserFirstName.Text = u.UserFirstName;
                UserLastName.Text = u.UserLastName;
                TextBox1.Text = DateTime.Parse(u.UserBirthDate).ToString("yyy-MM-dd");
                UserPhoneNumber.Text = u.UserPhoneNumber;
                Image1.ImageUrl = u.ProfilePicture;
                UserEmail.Text = u.UserEmail;

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

        

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//כפתור לדף בית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)// כפתור להתראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)//כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)//התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)//ביטול העריכה
        {
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            User u = UserService.FindUserById((DataTable)Session["Users"], Session["SelectedUser"].ToString());

            string filename, filelocation = Image1.ImageUrl, fileName;
            try
            {
                if (FileUpload1.HasFile)
                {
                    string filePath = Server.MapPath(u.ProfilePicture);
                    if (File.Exists(filePath) && u.ProfilePicture != "/Photos/NoProfile.png") File.Delete(filePath); // מחיקת תמונת הפרופיל מהתיקייה

                    filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    filename = filename.Substring(0, filename.Length - 4);
                    fileName = String.Format(@"{0}{1}.jpg", filename, DateTime.Now.Ticks);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("/Photos/" + fileName)); // שמירה בתיקיה
                    filelocation = "/Photos/" + fileName;

                    Image1.ImageUrl = filelocation;
                }
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            int UserType;
            if (DropDownList1.SelectedValue == "Choreographer") UserType=1;
            else UserType=2; 
            UserService.Update(u.UserId, UserPassword.Text,UserType, UserFirstName.Text, UserLastName.Text, TextBox1.Text, UserPhoneNumber.Text, filelocation, UserEmail.Text, false, false);
            Session["Users"] = DbManagement.GetTable("Users"); // טבלת משתמשים
        }

        
    }
}