using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.TypeClasses;
using System.Data;
using DanceProject.ServiceClasses;
using System.Windows.Forms;
using Label = System.Web.UI.WebControls.Label;
using Button = System.Web.UI.WebControls.Button;

namespace DanceProject.Pages
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User u = (User)Session["User"];
                DataTable notifications = DbManagement.GetTableByQuery("Select * from Notifications where UserId=\""+u.UserId+"\" Order by NotificationDate DESC"); // טבלת התראות
                Session["Notifications"] = notifications;
                GridView1.DataSource = notifications;
                GridView1.DataBind();

                if (notifications.Rows.Count <= 0) Label2.Text = "You don't have any notifications"; // הודעה אם אין התראות
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete") // מחיקת התראה
            {
                if (MessageBox.Show("Are you sure you want to delete this notification?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string NotificationId=((DataTable)Session["Notifications"]).Rows[Convert.ToInt32(e.CommandArgument)]["NotificationId"].ToString();
                    NotificationService.DeleteNotification(NotificationId); //מחיקה ממסד הנתונים

                    DataTable notifications = (DataTable)Session["Notifications"];//מחיקה מהטבלה
                    foreach (DataRow r in notifications.Rows)
                        if (r["NotificationId"].ToString() == NotificationId)
                            r.Delete();
                    notifications.AcceptChanges();

                    GridView1.DataSource = notifications;
                    GridView1.DataBind();
                    Session["Notifications"] = notifications;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) //לחיצה על עמוד בגריד
        {
            GridView1.PageIndex=e.NewPageIndex;
            GridView1.DataSource = (DataTable)Session["Notifications"];
            GridView1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//כפתור דף בית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)//כפתור התראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)//כפתור דף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)//התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Visible = true;
                e.Row.Cells[4].Visible = true;

                DataTable notifications = (DataTable)Session["Notifications"];
                User u = (User)Session["User"];
                if (e.Row.Cells[4].Text == "False")
                {
                    e.Row.BackColor = System.Drawing.Color.LightCyan;// צביעת ההודעות שלא נצפו עדיין בתכלת
                    NotificationService.Watched(u.UserId, e.Row.Cells[3].Text);// עדכון ההודעה לנצפה
                }

                foreach (DataRow r in notifications.Rows)
                    if (r["NotificationId"].ToString() == e.Row.Cells[3].Text) r["Watched"] = true;
                Session["Notifications"] = notifications;


                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;

                
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
            }
        }
    }
}