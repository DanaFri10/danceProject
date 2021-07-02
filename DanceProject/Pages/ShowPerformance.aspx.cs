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
using Label = System.Web.UI.WebControls.Label;
using System.IO;

namespace DanceProject.Pages
{
    public partial class ShowPerformance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                localhost.WebService1 x = new localhost.WebService1();// שירות רשת
                Session["x"] = x;  

                DataTable performances=(DataTable)Session["Performances"];
                DataTable Users = (DataTable)Session["Users"];
                DataTable Choreographer = new DataTable();
                Session["PerformanceComments"] = DbManagement.GetTableByQuery("SELECT Users.UserId, Users.UserFirstName, Users.UserLastName, Users.IsBlocked, PerformanceComments.CommentId, PerformanceComments.PerformanceId, PerformanceComments.CommentDate, PerformanceComments.CommentContent FROM Users INNER JOIN PerformanceComments ON Users.UserId = PerformanceComments.UserId;");//טבלת תגובות להופעות
                
                foreach(DataRow row in performances.Rows)
                    if (row["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString())
                    {
                        Label2.Text = row["PerformanceId"].ToString(); //הצגת פרטי ההופעה
                        Label4.Text = row["PerformanceName"].ToString();
                        Label28.Text = row["PerformanceLength"].ToString();
                        Image1.ImageUrl = row["PerformancePhoto"].ToString();

                                foreach (DataColumn column in Users.Columns) Choreographer.Columns.Add(new DataColumn(column.ColumnName.ToString())); // מציאת הכראוגרף של ההופעה
                                foreach (DataRow r in Users.Rows)
                                    if (r["UserCategory"].ToString() == "1" && r["UserId"].ToString() == row["ChoreographerId"].ToString())
                                        Choreographer.ImportRow(r);
                                Session["Choreographer"] = Choreographer;
                                DataList1.DataSource = Choreographer;
                                DataList1.DataBind();
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

                DataTable comments = new DataTable();//מציאת התגובות של ההופעה
                foreach (DataColumn c in ((DataTable)Session["PerformanceComments"]).Columns) comments.Columns.Add(c.ColumnName);
                foreach (DataRow r in ((DataTable)Session["PerformanceComments"]).Rows)
                    if (r["PerformanceId"].ToString() == Session["SelectedPerformance"].ToString())
                        foreach(DataRow r1 in ((DataTable)Session["Users"]).Rows)
                            if(r["UserId"].ToString()==r1["UserId"].ToString())
                                if(r1["IsBlocked"].ToString()=="False")
                                    comments.ImportRow(r);
                GridView3.DataSource = comments;
                GridView3.DataBind();
                Session["PerformanceComments"]=comments;
                 
                User u = (User)Session["User"];
                if (u.UserId == Choreographer.Rows[0]["UserId"].ToString() || u.IsAdmin)// אם המשתמש הוא הכראוגרף של ההופעה הוא יוכל לערוך ולמחוק אותה
                {
                    Pencil.Visible = true;
                    ImageButton8.Visible = true;
                }

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

                DataTable dancers = new DataTable(); // הרקדנים שבהופעה
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) dancers.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["DancesDancers"]).Rows)
                        if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                            foreach (DataRow r3 in ((DataTable)Session["Users"]).Rows)
                                if (r2["DancerId"].ToString() == r3["UserId"].ToString() && r3["IsBlocked"].ToString()=="False")
                                    dancers.ImportRow(r3);
                dancers = UserService.RemoveDoubles(dancers);
                GridView4.DataSource = dancers;
                GridView4.DataBind();
                Session["Dancers"] = dancers;

                DataTable choreographers = new DataTable(); // הכראוגרפים שבהופעה
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) choreographers.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["Users"]).Rows)
                        if (r1["ChoreographerId"].ToString() == r2["UserId"].ToString())
                            choreographers.ImportRow(r2);
                choreographers = UserService.RemoveDoubles(choreographers);
                GridView5.DataSource = choreographers;
                GridView5.DataBind();
                Session["Choreographers"] = choreographers;

                Hi.Text = "Hi, " + u.UserFirstName + " " + u.UserLastName + "!";
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteComment") // מחיקת תגובה
            {
                string UserId = ((DataTable)Session["PerformanceComments"]).Rows[Convert.ToInt32(e.CommandArgument)]["UserId"].ToString();
                if (UserId != ((User)Session["User"]).UserId)
                {
                    UserService.BlockUser(UserId, true); // אם תגובה נמחקת המשתמש נחסם אוטומטית
                    EmailService.SendEmail("You are blocked because of your comment: " + ((DataTable)Session["PerformanceComments"]).Rows[Convert.ToInt32(e.CommandArgument)][2].ToString(), "You are blocked because of your comment", UserService.GetEmail((DataTable)Session["Users"], UserId));//שליחת אימייל
                }

                DataTable Comments = (DataTable)Session["PerformanceComments"];
                string commentId = Comments.Rows[Convert.ToInt32(e.CommandArgument)]["CommentId"].ToString();
                PerformanceService.DeleteComment(commentId);//מחיקה ממסד הנתונים

                foreach (DataRow r in Comments.Rows) //מחיקה מהטבלה
                    if (r["CommentId"].ToString() == commentId)
                        r.Delete();
                Comments.AcceptChanges();
                GridView3.DataSource = Comments;
                GridView3.DataBind();
                Session["PerformanceComments"] = Comments;
            }

            if (e.CommandName == "BlockUser")
            {
                string UserId = ((DataTable)Session["PerformanceComments"]).Rows[Convert.ToInt32(e.CommandArgument)]["UserId"].ToString();
                if (UserId != ((User)Session["User"]).UserId)
                {
                    UserService.BlockUser(UserId, true); // אם תגובה נמחקת המשתמש נחסם אוטומטית
                    EmailService.SendEmail("You are blocked because of your comment: " + ((DataTable)Session["PerformanceComments"]).Rows[Convert.ToInt32(e.CommandArgument)][2].ToString(), "You are blocked because of your comment", UserService.GetEmail((DataTable)Session["Users"], UserId));//שליחת אימייל
                }

                string commentId = ((DataTable)Session["PerformanceComments"]).Rows[Convert.ToInt32(e.CommandArgument)][6].ToString();
                PerformanceService.DeleteComment(commentId);//מחיקה ממסד הנתונים

                DataTable Comments = (DataTable)Session["PerformanceComments"]; //מחיקה מהטבלה
                foreach (DataRow r in Comments.Rows)
                    if (r["CommentId"].ToString() == commentId)
                        r.Delete();
                Comments.AcceptChanges();
                GridView3.DataSource = Comments;
                GridView3.DataBind();
                Session["PerformanceComments"] = Comments;

                //User u = (User)Session["User"];
                //if (u.IsAdmin)
                //{
                //    GridView3.Columns[4].Visible = true;
                //    GridView3.Columns[5].Visible = true;
                //}
                //else
                //    for (int i = 0; i < GridView3.Rows.Count; i++)
                //        if (u.UserId.ToString() != Comments.Rows[i][1].ToString())
                //            GridView3.Rows[i].Cells[4].Visible = false;
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ShowChoreographer") //תצוגת כראוגרף
            {
                Session["SelectedUser"] = ((DataTable)Session["Choreographer"]).Rows[e.Item.ItemIndex]["UserId"].ToString();
                Session["from"] = "ShowPerformance.aspx";
                Response.Redirect("ShowUser.aspx");
            } 
        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Show") //תצוגת ריקוד
            {
                Session["SelectedDance"] = ((DataTable)Session["DanInPer"]).Rows[Convert.ToInt32(e.CommandArgument)]["DanceId"].ToString();
                Session["from"] = "ShowPerformance.aspx";
                Response.Redirect("ShowDance.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e) //עריכת הופעה
        {
            Response.Redirect("EditPerformance.aspx");
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Session["from"] = "ShowPerformance1.aspx";
        //    Session["PerformanceName"] = Label4.Text;
        //    PerformancesDances dancesInPerformance = new PerformancesDances();
        //    foreach (DataRow row in ((DataSet)Session["DanInPer"]).Tables[0].Rows)
        //        dancesInPerformance.Add(row["DanceId"].ToString());
        //    Session["DancesInPerformance"] = dancesInPerformance;
        //    Response.Redirect("ShowDances.aspx");
        //}

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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowDance1") // תצוגת ריקוד
            {
                string danceName = ((GridView)sender).Rows[Convert.ToInt32( e.CommandArgument)].Cells[0].Text;
                Session["SelectedDance"] = DanceService.FindDanceId(danceName);
                Session["from"] = "ShowDances.aspx";
                Response.Redirect("ShowDance.aspx");
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e) //פוטר להצגת אורך ההופעה
        {
            decimal sum = 0;
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label l = (Label)e.Row.Cells[2].FindControl("Label13");
                if (Session["dancesInPerformance"] != null)
                {
                    PerformancesDances dancesInPerformance = (PerformancesDances)Session["dancesInPerformance"];
                    DataTable dt = dancesInPerformance.TurnToDT(((DataSet)Session["Dances"]).Tables["Dances"]);
                    for (int i = 0; i < dancesInPerformance.dances.Count; i++)
                        sum += DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],dancesInPerformance.dances[i].ToString()).DanceLength;
                    l.Text = sum.ToString();
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) // צביעת הריקודים של הכראוגרף שמחובר בתכלת
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],DanceService.FindDanceId(e.Row.Cells[0].Text)).ChoreographerId == ((User)Session["User"]).UserId) e.Row.BackColor = System.Drawing.Color.AliceBlue;
                //if (DanceService.FindChoreographer(DanceService.FindDanceId(e.Row.Cells[0].Text))== ((User)Session["User"]).UserId) e.Row.BackColor = System.Drawing.Color.AliceBlue;
            }
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            if (e.CommandName == "ShowDancer")//תצוגת רקדן
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["SelectedUser"] = ((DataTable)Session["Dancers"]).Rows[index]["UserId"].ToString();
                Session["from"] = "ShowPerformance.aspx";
                Response.Redirect("ShowUser.aspx");
            }
        }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowChoreographer") // תצוגת כראוגרף
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["SelectedUser"] = ((DataTable)Session["Choreographers"]).Rows[index]["UserId"].ToString();
                Session["from"] = "ShowPerformance.aspx";
                Response.Redirect("ShowUser.aspx");
            }
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e) // תאריכי ההופעה
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
 
        }

        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = e.Row.Cells[0].Text.Substring(0, 10);
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(11, 5);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)//הצגת פרטים אישיים
        {
            Button6.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.White;

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
        }

        protected void Button7_Click(object sender, EventArgs e) // הצגת תאריכי הופעה
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
        }

        protected void Button8_Click(object sender, EventArgs e) // הצגת ריקודים
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
        }

        protected void Button9_Click(object sender, EventArgs e) // הצגת רקדנים
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
        }

        protected void Button10_Click(object sender, EventArgs e) // הצגת כראוגרפים
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button11.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
            Panel6.Visible = false;
        }

        protected void Button11_Click(object sender, EventArgs e) // הצגת תגובות
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = true;
        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור לעמוד בית
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
        
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e) // התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }

        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            User u = (User)Session["User"]; // הוספת תגובה
            PerformanceService.AddComment(u.UserId, Session["SelectedPerformance"].ToString(), tbox.Text);
            DataTable Comments = DbManagement.GetTableByQuery("SELECT PerformanceComments.CommentId, PerformanceComments.UserId, PerformanceComments.PerformanceId, PerformanceComments.CommentDate, PerformanceComments.CommentContent, Users.UserFirstName, Users.UserLastName FROM PerformanceComments INNER JOIN Users ON PerformanceComments.UserId = Users.UserId WHERE (Users.IsBlocked)=No and (((PerformanceComments.PerformanceId)=" + Session["SelectedPerformance"].ToString() + ")) ORDER BY PerformanceComments.CommentDate DESC;");
            Session["PerformanceComments"] = Comments;
            GridView3.DataSource = Comments;
            GridView3.DataBind();
            tbox.Text = "";

            //if (u.IsAdmin)
            //{
            //    GridView3.Columns[4].Visible = true;
            //    GridView3.Columns[5].Visible = true;
            //}
            //else
            //    for (int i = 0; i < GridView3.Rows.Count; i++)
            //        if (u.UserId.ToString() != Comments.Rows[i][1].ToString())
            //            GridView3.Rows[i].Cells[4].Visible = false;
        
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e) // מחיקת הופעה
        {
            if (MessageBox.Show("Are you sure you want to delete this performance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string PerformanceId = Session["SelectedPerformance"].ToString();
                               
                NotificationService.AddNotification(PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer, "Your performance was deleted! Performance Name: " + Label4.Text); //הודעה לכראוגרף
                EmailService.SendEmail("Your performance was deleted! Performance Name: " + Label4.Text, "Your performance was deleted!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));

                foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                {
                    NotificationService.AddNotification(r["ChoreographerId"].ToString(), "A performance you are dancing in was deleted! Performance Name: " + Label4.Text); //הודעה לכראוגרף
                    EmailService.SendEmail("A performance you are dancing in was deleted! Performance Name: " + Label4.Text, "A performance you are dancing in was deleted!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));
                }
                foreach (DataRow r in ((DataTable)Session["Choreographers"]).Rows)
                {
                    NotificationService.AddNotification(r["UserId"].ToString(), "A performance you have a dance in was deleted! Performance Name: " + Label4.Text); //הודעה לכראוגרף
                    EmailService.SendEmail("A performance you have a dance in was deleted! Performance Name: " + Label4.Text, "A performance you have a dance in was deleted!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));
                }

                string filePath = Server.MapPath((PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"])).PerformancePhoto.ToString());
                if (File.Exists(filePath) && (PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"])).PerformancePhoto.ToString() != "/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת ההופעה מהתיקייה

                PerformanceService.DeletePerformance(PerformanceId);// מחיקה ממסד הנתונים
                ((localhost.WebService1)Session["x"]).DeletePerformance(Session["SelectedPerformance"].ToString()); //מחיקה משירות רשת
                Session["PerformancesDates"] = ((localhost.WebService1)Session["x"]).GetTblByQuery("SELECT Performances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace, [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour] AS Expr1 FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId ORDER BY [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour];"); // תאריכי הופעות

                DataTable dt2 = (DataTable)Session["Performances"];
                for (int i = 0; i < dt2.Rows.Count; i++)//מחיקה מDataTable
                {
                    DataRow dr = dt2.Rows[i];
                    if (dr["PerformanceId"].ToString() == PerformanceId)
                        dr.Delete();
                }
                dt2.AcceptChanges();

                Response.Redirect("ShowPerformances.aspx"); // מעבר לתצוגת הופעות
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            User u = (User)Session["User"];
            DataTable Comments = (DataTable)Session["PerformanceComments"];

            if (u.IsAdmin)//אם המשתמש הוא אדמין הוא יוכל למחוק תגובות ולחסום משתמשים
            {
                GridView3.Columns[4].Visible = true;
                GridView3.Columns[5].Visible = true;
            }
            else // המשתמש שהגיב יוכל למחוק את התגובה שלו
                for (int i = 0; i < GridView3.Rows.Count; i++)
                    if (u.UserId.ToString() != Comments.Rows[i][1].ToString())
                        GridView3.Rows[i].Cells[4].Visible = false;
        }


        
    }
}