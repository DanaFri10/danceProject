using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DanceProject.ServiceClasses;
using DanceProject.TypeClasses;
using System.Web.Services;
using System.Data;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class AddPerformance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                localhost.WebService1 x = new localhost.WebService1(); // שירות רשת
                Session["x"] = x;

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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור לדף הבית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e) // כפתור להתראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e) // כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (PerformanceService.FindPerformanceId(TextBox1.Text) != null) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This performance already exists.\");", true); // הודעה אם שם ההופעה כבר קיים
            else
            {
                string filename, fileName = "", filelocation = "/Photos/NoDance.png"; // תמונה
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

                PerformanceService.AddPerformance(TextBox1.Text, filelocation, ((User)Session["User"]).UserId.ToString());//שאילתה להוספת הופעה

                localhost.WebService1 x = (localhost.WebService1)Session["x"];
                x.AddPerformance(TextBox1.Text, filelocation, ((User)Session["User"]).UserId); // שאילתה להוספת הופעה לשירות רשת

                Session["from"] = "AddPerformance.aspx";
                PerformancesDances dancesInPerformance = new PerformancesDances();
                Session["dancesInPerformance"] = dancesInPerformance;
                Session["PerformanceName"] = PerformanceService.FindPerformanceId(TextBox1.Text);
                Session["Performances"] = DbManagement.GetTable("Performances"); // טבלת הופעות
                Response.Redirect("ShowDances.aspx"); // מעבר לבחירת ריקודים
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e) // כפתור התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }
    }
}