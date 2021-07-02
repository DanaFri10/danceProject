using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DanceProject.ServiceClasses;
using DanceProject.TypeClasses;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class SelectDates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label11.Text = PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName;

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

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today) // לא ניתן לבחור את הימים שקודמים מהיום
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
            }

            DataTable PerformancesDates = (DataTable)Session["PerformancesDates"]; //צביעת הימים שיש בהם הופעה בירוק
            foreach (DataRow row in PerformancesDates.Rows)
                if (e.Day.Date.ToShortDateString() == ((DateTime)row["PerformanceDate"]).ToShortDateString())
                    e.Cell.BackColor = System.Drawing.Color.PaleGreen;

            DataTable DatesOfThisPerformance = new DataTable();//צביעת הימים של ההופעה הספציפית בורוד בהיר
            foreach (DataColumn c in PerformancesDates.Columns) DatesOfThisPerformance.Columns.Add(c.ColumnName);
            foreach (DataRow row in PerformancesDates.Rows)
                if (row["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString())
                    DatesOfThisPerformance.ImportRow(row);
            foreach (DataRow row in DatesOfThisPerformance.Rows)
                if (e.Day.Date.ToShortDateString() == (DateTime.Parse(row["PerformanceDate"].ToString()).ToShortDateString()))
                    e.Cell.BackColor = System.Drawing.Color.PeachPuff;

            DataTable FullDates = ((localhost.WebService1)Session["x"]).GetTblByQuery("SELECT PerformancesDates.PerformanceDate, Count(PerformancesDates.PerformanceId) AS CountOfPerformanceId FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId GROUP BY PerformancesDates.PerformanceDate HAVING (((Count(PerformancesDates.PerformanceId))>=2));");
            foreach (DataRow row in FullDates.Rows) //צביעת הימים שיש בהם יותר משתי הופעות בורוד כהה ולא ניתן לבחור אותם
                if (e.Day.Date.ToShortDateString() == ((DateTime)row["PerformanceDate"]).ToShortDateString())
                {
                    e.Day.IsSelectable = false;
                    e.Cell.BackColor = System.Drawing.Color.PaleVioletRed;
                }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור לדף הבית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e) //כפתור לדף התראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e) //כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            DataTable PerformancesDates = (DataTable)Session["PerformancesDates"];
            bool found = false;
            foreach (DataRow r in PerformancesDates.Rows)
                if (r["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString() && r["PerformanceDate"].ToString() == Calendar1.SelectedDate.ToString("MM/dd/yyyy") && r["PerformanceHour"].ToString() == TextBox3.Text) found = true;

            if (Calendar1.SelectedDate != new DateTime(0001, 01, 01, 00, 00, 00) && !found)
            {
                ((localhost.WebService1)Session["x"]).AddPerformanceDate(Session["SelectedPerformance"].ToString(), Calendar1.SelectedDate.ToString("MM/dd/yyyy"), TextBox3.Text, TextBox2.Text);
                Calendar1.SelectedDate = new DateTime();
                TextBox2.Text = "";
                TextBox3.Text = "";
                Label7.Text = "";

                Session["PerformancesDates"] = ((localhost.WebService1)Session["x"]).GetTblByQuery("SELECT Performances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace, [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour] AS Expr1 FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId ORDER BY [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour];"); // תאריכי הופעות
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"The date was added successfully!.\");", true);

                NotificationService.AddNotification(PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceChoreographer, "A new date was added to your performance! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName); // הודעה לכראוגרף של ההופעה
                EmailService.SendEmail("A new date was added to your performance! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A new performance date!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceChoreographer));

                DataTable dances = new DataTable(); // תצוגת ריקודים בהופעה
                foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dances.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in ((DataTable)Session["PerformancesDances"]).Rows)
                    if (r1["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString())
                        foreach (DataRow r2 in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                            if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                                dances.ImportRow(r2);
                
                DataTable dancers = new DataTable(); // הרקדנים שבהופעה
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) dancers.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["DancesDancers"]).Rows)
                        if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                            foreach (DataRow r3 in ((DataTable)Session["Users"]).Rows)
                                if (r2["DancerId"].ToString() == r3["UserId"].ToString() && r3["IsBlocked"].ToString() == "False")
                                    dancers.ImportRow(r3);
                dancers = UserService.RemoveDoubles(dancers);

                DataTable choreographers = new DataTable(); // הכראוגרפים שבהופעה
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) choreographers.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["Users"]).Rows)
                        if (r1["ChoreographerId"].ToString() == r2["UserId"].ToString())
                            choreographers.ImportRow(r2);
                choreographers = UserService.RemoveDoubles(choreographers);

                foreach (DataRow r in dancers.Rows) // הודעות לכל הרקדנים שבהופעה
                {
                    NotificationService.AddNotification(r["UserId"].ToString(), "A new date was added to a performance you are dancing in! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName);
                    EmailService.SendEmail("A new date was added to a performance you are dancing in! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A new performance date!", UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
                }

                foreach (DataRow r in choreographers.Rows) // הודעות לכל הכראוגרפים שבהופעה
                {
                    NotificationService.AddNotification(r["UserId"].ToString(), "A new date was added to a performance you have a dance in! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName);
                    EmailService.SendEmail("A new date was added to a performance you have a dance in! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A new performance date!", UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
                }

            }
            else
            {
                if (Calendar1.SelectedDate == new DateTime(0001, 01, 01, 00, 00, 00)) Label7.Text = "This is a required field";
                else ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This performance date and hour already exists.\");", true);
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e) //ביטול הוספת תאריכים וחזרה לעריכת הופעה
        {
            Response.Redirect("EditPerformance.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e) // התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }

        }
    }
}