using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.ServiceClasses;
using System.Data;
using System.IO;
using DanceProject.TypeClasses;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class AddDance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt1 = ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"];
                DataTable dt2 = ((DataSet)Session["Dances"]).Tables["DanceTypesCategories"];
                DataTable dt3 = ((DataSet)Session["Dances"]).Tables["Users"];

                if (dt1 != null) // הוספת סגנונות ריקוד ל dropdownlist
                        foreach (DataRow row in dt1.Rows)
                            if (row["IsValid"].ToString() == "True")
                                DanceStyle.Items.Add(new ListItem(row["CategoryName"].ToString()));

                User u=(User)Session["User"];
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

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (DanceService.FindDanceId(DanceName.Text) != null) 
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This dance already exists.\");", true); // הודעה אם שם הריקוד כבר קיים
            else
            {
                string style = (DanceStyle.SelectedValue).ToString(); // שם סגנון הריקוד החדש
                string styleId = null; // קוד סגנון הריקוד החדש
                DataTable dt1 = ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"]; 
                foreach (DataRow row in dt1.Rows) // מציאת קוד הסגנון
                    if (row["CategoryName"].ToString() == style)
                        styleId = row["CategoryId"].ToString();

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

                string video = ""; // קישור לסרטון
                try
                {
                    if (DanceVideo.Text != "")
                    {
                        video = DanceVideo.Text;
                        video = video.Remove(video.IndexOf("title") - 2);
                        video = video.Remove(0, video.IndexOf("http"));
                    }
                }
                catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                DanceService.AddDance(DanceName.Text, styleId,"1", ((User)Session["User"]).UserId, DanceLength.Text, DanceSong.Text, video, filelocation); // שאילתה להכנסת הריקוד לטבלת ריקודים

                Session["from"] = "AddDance.aspx";
                DancesDancers dancersInDance = new DancesDancers();
                Session["dancersInDance"] = dancersInDance;
                Session["DanceName"] = DanceName.Text;
                Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים
                Response.Redirect("ShowDancers.aspx"); // מעבר לבחירת רקדנים  
            }
        }
 
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור לעמוד הבית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e) // כפתור לדף התראות
        {
            Response.Redirect("Notifications.aspx");
        }
        
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)// כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)// התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }        
    }
}