using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using DanceProject.ServiceClasses;
using DanceProject.TypeClasses;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class EditPerformance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                localhost.WebService1 x = new localhost.WebService1(); // שירות רשת
                Session["x"] = x; 

                DataTable performances = (DataTable)Session["Performances"];
                foreach (DataRow row in performances.Rows) // הצגת פרטי הופעה
                    if (row["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString())
                    {
                        Image1.ImageUrl = row["PerformancePhoto"].ToString();
                        Label4.Text = row["PerformanceId"].ToString();
                        TextBox2.Text = row["PerformanceName"].ToString();
                    }

                DataTable dances = new DataTable(); // תצוגת ריקודים בהופעה
                foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dances.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in ((DataTable)Session["PerformancesDances"]).Rows)
                    if (r1["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString())
                        foreach (DataRow r2 in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                            if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                                dances.ImportRow(r2);
                GridView1.DataSource = dances;
                GridView1.DataBind();
                Session["DanInPer"] = dances;
                
                DataTable dancers = new DataTable(); // הרקדנים שבהופעה
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) dancers.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["DancesDancers"]).Rows)
                        if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                            foreach (DataRow r3 in ((DataTable)Session["Users"]).Rows)
                                if (r2["DancerId"].ToString() == r3["UserId"].ToString() && r3["IsBlocked"].ToString() == "False")
                                    dancers.ImportRow(r3);
                dancers = UserService.RemoveDoubles(dancers);
                Session["DancersInPer"] = dancers;

                DataTable choreographers = new DataTable(); // הכראוגרפים שבהופעה
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) choreographers.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["Users"]).Rows)
                        if (r1["ChoreographerId"].ToString() == r2["UserId"].ToString())
                            choreographers.ImportRow(r2);
                choreographers = UserService.RemoveDoubles(choreographers);
                Session["ChoInPer"] = choreographers;

                User u = (User)Session["User"];
                if (u.IsAdmin) // תפריט לאדמין
                {
                    Menu1.Visible = true;
                    Menu2.Visible = false;
                    Menu3.Visible = false;                    
                    
                    Label6.Visible = true;
                    Calendar1.Visible = true;
                    GridView6.Visible = true;
                    ImageButton7.Visible = true;
                    Button8.Visible = true;
                    Button11.Visible = true;
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

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    Session["from"] = "ShowPerformance1.aspx";
        //    Session["PerformanceName"] = Label4.Text;
        //    PerformancesDances dancesInPerformance = new PerformancesDances();
        //    foreach (DataRow row in ((DataSet)Session["DanInPer"]).Tables[0].Rows)
        //        dancesInPerformance.Add(row["DanceId"].ToString());
        //    Session["DancesInPerformance"] = dancesInPerformance;
        //    Response.Redirect("ShowPerformances.aspx");
        //}

        protected void GridView6_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this date?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ((localhost.WebService1)Session["x"]).DeleteDate(Session["SelectedPerformance"].ToString(), ((GridView)sender).Rows[e.RowIndex].Cells[0].Text.Substring(0, 10), ((GridView)sender).Rows[e.RowIndex].Cells[1].Text); // מחיקה ממסד הנתונים בשירות רשת

                DataTable Dates = (DataTable)Session["PerformancesDates"];
                foreach (DataRow r in Dates.Rows)
                    if (r["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString() && r["PerformanceDate"].ToString() == ((GridView)sender).Rows[e.RowIndex].Cells[0].Text.Substring(0, 10) && r["PerformanceHour"].ToString() == ((GridView)sender).Rows[e.RowIndex].Cells[1].Text)
                        r.Delete();
                Dates.AcceptChanges();
                Session["Dates"] = Dates;
                    
                DataTable Performances = (DataTable)Session["PerformancesInDate"];//מחיקה מטבלת הופעות בתאריך מסויים
                Performances.Rows[e.RowIndex].Delete();
                Performances.AcceptChanges();

                GridView6.DataSource = Performances;
                GridView6.DataBind();

                NotificationService.AddNotification(PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceChoreographer, "A date was deleted from your performance! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName); // הודעה לכראוגרף של ההופעה
                EmailService.SendEmail("A date was deleted from your performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A date was deleted from your performance!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceChoreographer));

                foreach (DataRow r in ((DataTable)Session["DancersInPer"]).Rows) // הודעות לכל הרקדנים שבהופעה
                {
                    NotificationService.AddNotification(r["UserId"].ToString(), "A date was deleted from a performance you are dancing in! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName+" User Id="+r["UserId"].ToString());
                    EmailService.SendEmail("A date was deleted from a performance you are dancing in! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " User Id=" + r["UserId"].ToString(), "A performance date was deleted!", UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
                }

                foreach (DataRow r in ((DataTable)Session["ChoInPer"]).Rows) // הודעות לכל הכראוגרפים שבהופעה
                {
                    NotificationService.AddNotification(r["UserId"].ToString(), "A date was deleted from a performance you have a dance in! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " User Id=" + r["UserId"].ToString());
                    EmailService.SendEmail("A date was deleted from a performance you have a dance in! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A performance date was deleted!", UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
                }
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false; // לוח שנה לתצוגה בלבד, אי אפשר לבחור תאריכים

            DataTable Dates = new DataTable(); //מציאת התאריכים של ההופעה
            foreach (DataColumn c in ((DataTable)Session["PerformancesDates"]).Columns) Dates.Columns.Add(c.ColumnName);
            foreach (DataRow r in ((DataTable)Session["PerformancesDates"]).Rows)
                if (r["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString())
                    Dates.ImportRow(r);

            foreach (DataRow row in Dates.Rows) //צביעת התאריכים של ההופעה בתכלת ואפשרות לבחור אותם
                if (e.Day.Date.ToString() == row["PerformanceDate"].ToString())
                {
                    e.Cell.BackColor = System.Drawing.Color.PowderBlue;
                    e.Day.IsSelectable = true;
                }

            Session["Dates"] = Dates;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DataTable Performances = new DataTable(); // הצגת ההופעות בתאריך שנבחר
            foreach (DataColumn c in ((DataTable)Session["PerformancesDates"]).Columns) Performances.Columns.Add(c.ColumnName);
            foreach (DataRow r in ((DataTable)Session["Dates"]).Rows)
                if (r["PerformanceDate"].ToString() == Calendar1.SelectedDate.ToString())
                    Performances.ImportRow(r);

            GridView6.DataSource = Performances;
            GridView6.DataBind();

            Session["PerformancesInDate"] = Performances;
        }

        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = e.Row.Cells[0].Text.Substring(0, 10);
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(11, 5);
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Button11.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button8.BackColor = System.Drawing.Color.White;

            Panel1.Visible = true;
            Panel2.Visible = false;
        }


        protected void Button8_Click1(object sender, EventArgs e)
        {
            Button11.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

            Panel1.Visible =false;
            Panel2.Visible = true;
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
            if (PerformanceService.FindPerformanceId(TextBox2.Text) != null && PerformanceService.FindPerformanceId(TextBox2.Text) != Session["SelectedPerformance"].ToString()) ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(\"This performance already exists.\")", true);//
            else
            {
                string filename,filelocation = Image1.ImageUrl , fileName;
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        string filePath = Server.MapPath((PerformanceService.FindPerformance(Label4.Text, (DataTable)Session["Performances"])).PerformancePhoto.ToString());
                        if (File.Exists(filePath) && (PerformanceService.FindPerformance(Label4.Text, (DataTable)Session["Performances"])).PerformancePhoto.ToString() != "/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת ההופעה מהתיקייה

                        filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        filename = filename.Substring(0, filename.Length - 4);
                        fileName = String.Format(@"{0}{1}.jpg", filename, DateTime.Now.Ticks);
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("/Photos/" + fileName)); // שמירה בתיקיה
                        filelocation = "/Photos/" + fileName;

                        Image1.ImageUrl = filelocation;
                    }
                }
                catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                PerformanceService.Update(Label4.Text, TextBox2.Text, filelocation); // עדכון במסד נתונים הרגיל
                ((localhost.WebService1)Session["x"]).Update(Label4.Text, TextBox2.Text, filelocation);
                Session["Performances"] = DbManagement.GetTable("Performances"); // טבלת הופעות
                Session["PerformancesDates"] = ((localhost.WebService1)Session["x"]).GetTblByQuery("SELECT Performances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace, [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour] AS Expr1 FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId ORDER BY [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour];"); // תאריכי הופעות

                NotificationService.AddNotification(PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceChoreographer, "Your performance was edited! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName); // הודעה לכראוגרף של ההופעה
                EmailService.SendEmail("Your performance was edited! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "Your performance was edited!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceChoreographer));

                foreach (DataRow r in ((DataTable)Session["DancersInPer"]).Rows) // הודעות לכל הרקדנים שבהופעה
                {
                    NotificationService.AddNotification(r["UserId"].ToString(), "A performance you had a dance in was edited! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " User Id=" + r["UserId"].ToString());
                    EmailService.SendEmail("A performance you had a dance in was edited! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " User Id=" + r["UserId"].ToString(), "A performance you had a dance in was edited!", UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
                }

                foreach (DataRow r in ((DataTable)Session["ChoInPer"]).Rows) // הודעות לכל הכראוגרפים שבהופעה
                {
                    NotificationService.AddNotification(r["UserId"].ToString(), "A performance you are dancing in was edited! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " User Id=" + r["UserId"].ToString());
                    EmailService.SendEmail("A performance you are dancing in was edited! Performance name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " User Id=" + r["UserId"].ToString(), "A performance you are dancing in was edited!", UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
                }
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowPerformance.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Session["from"] = "EditPerformance.aspx";
            Session["PerformanceName"] = Label4.Text;
            PerformancesDances dancesInPerformance = new PerformancesDances();
            foreach (DataRow row in ((DataTable)Session["DanInPer"]).Rows)
                dancesInPerformance.Add(row["DanceId"].ToString());
            Session["DancesInPerformance"] = dancesInPerformance;
            Response.Redirect("ShowDances.aspx");
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SelectDates.aspx");
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                if (e.CommandName == "Show") //תצוגת ריקוד
            {
                Session["SelectedDance"] = ((DataTable)Session["DanInPer"]).Rows[Convert.ToInt32(e.CommandArgument)]["DanceId"].ToString();
                Session["from"] = "ShowPerformance.aspx";
                Response.Redirect("ShowDance.aspx");
            }
        } 

    }
}