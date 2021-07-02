using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DanceProject.ServiceClasses;
using DanceProject.TypeClasses;
using System.IO;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class Entrance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable users;// טבלת משתמשים
            if (Session["Users"] != null) users = (DataTable)Session["Users"];
            else
            {
                users = DbManagement.GetTable("Users");
                Session["Users"] = users;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false; // הכפתור נעלם
            Panel1.Visible = true; // התחברות מופיעה

            Button2.Visible = true; // הכפתור מופיע
            Panel2.Visible = false; // התחברות נעלמת
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button2.Visible = false; // הכפתור נעלם
            Panel2.Visible = true; // התחברות מופיעה

            Button1.Visible = true; // הכפתור מופיע
            Panel1.Visible = false; // התחברות נעלמת        
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!RequiredFieldValidator1.IsValid) RequiredFieldValidator1.Visible = true;

            TypeClasses.User u = UserService.FindUser((DataTable)Session["Users"], UserId.Text, UserPassword.Text); // המשתמש שנכנס לאתר
            Session["User"] = u;

            if (u == null) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"Incorrect Id or password.\");", true); // שם משתמש או סיסמה לא נכונים
            else
            {
                if (u.IsBlocked) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This user is blocked.\");", true); // משתמש חסום
                else Response.Redirect("HomePage.aspx"); // כניסה לאתר אם שם משתמש וסיסמה נכונים והמשתמש לא חסום
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (UserId.Text == "") ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"Please enter your Id first.\");", true);
            else
            {
                EmailService.SendEmail("Your password is: " + UserService.GetPassword((DataTable)Session["Users"], UserId.Text), "Your password", UserService.GetEmail((DataTable)Session["Users"], UserId.Text)); // שליחת מייל למשתמש עם הסיסמה
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"Your password was sent to your email.\");", true);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Button1.Visible = true; // הכפתור מופיע
            Panel1.Visible = false; // התחברות נעלמת
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Button2.Visible = true; // הכפתור מופיע
            Panel2.Visible = false; // התחברות נעלמת
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            User u = UserService.FindUserById(DbManagement.GetTable("Users"), UserId.Text);
            if (u != null) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This user already exists.\");", true); // הודעה אם המשתמש כבר קיים
            else
            {
                string filename, fileName = "", filelocation="/Photos/NoProfile.png"; // תמונה
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        filename = filename.Substring(0, filename.Length - 4);
                        fileName = String.Format(@"{0}{1}.jpg", filename, DateTime.Now.Ticks);
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("/Photos/" + fileName)); // שמירה בתיקיה
                        filelocation = "/Photos/" + fileName;
                    }
                }
                catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                User user;
                if (DropDownList1.SelectedValue == "Choreographer")
                {
                    UserService.Register(TextBox1.Text, TextBox2.Text, "1", UserFirstName.Text, UserLastName.Text, TextBox3.Text, UserPhoneNumber.Text, filelocation, UserEmail.Text, false, false);
                    user = new User(TextBox1.Text, TextBox2.Text, "1", UserFirstName.Text, UserLastName.Text, TextBox3.Text, UserPhoneNumber.Text, filelocation, UserEmail.Text, false, false);
                    Session["User"] = user;
                }
                else
                {
                    UserService.Register(TextBox1.Text, TextBox2.Text, "2", UserFirstName.Text, UserLastName.Text, TextBox3.Text, UserPhoneNumber.Text, filelocation, UserEmail.Text, false, false);
                    user = new User(TextBox1.Text, TextBox2.Text, "1", UserFirstName.Text, UserLastName.Text, TextBox3.Text, UserPhoneNumber.Text, filelocation, UserEmail.Text, false, false);
                    Session["User"] = user;
                }
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}