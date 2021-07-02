using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.ServiceClasses;
using System.Data;
using DanceProject.TypeClasses;
using System.Windows.Forms;
using System.IO;

namespace DanceProject.Pages
{
    public partial class ShowDance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet dt = (DataSet)Session["Dances"];
                DataTable Users = ((DataSet)Session["Dances"]).Tables["Users"];
                DataTable Choreographer = new DataTable();
                Session["DanceComments"] = DbManagement.GetTableByQuery("SELECT DanceComments.CommentId, DanceComments.UserId, DanceComments.DanceId, DanceComments.CommentDate, DanceComments.CommentContent, Users.UserFirstName, Users.UserLastName, Users.IsBlocked FROM Users INNER JOIN DanceComments ON Users.UserId = DanceComments.UserId ORDER BY DanceComments.CommentDate DESC;"); //טבלת תגובות לריקודים
                
                foreach (DataRow row in dt.Tables[0].Rows)
                    if (row["DanceId"].ToString() == Session["SelectedDance"].ToString())
                    {
                        Image2.ImageUrl = row["DancePhoto"].ToString(); // הצגת פרטי הריקוד
                        Label2.Text = row["DanceId"].ToString();
                        Label4.Text = row["DanceName"].ToString();
                        Label6.Text = row["DanceStyle"].ToString();
                        Label8.Text = row["DanceType"].ToString();
                        Label12.Text = row["DanceLength"].ToString();
                        Label14.Text = row["DanceSong"].ToString();

                        foreach (DataColumn column in Users.Columns) // מציאת הכראוגרף של הריקוד
                            Choreographer.Columns.Add(new DataColumn(column.ColumnName.ToString()));
                        foreach (DataRow row1 in Users.Rows)
                            if (row1["UserCategory"].ToString() == "1" && row1["UserId"].ToString() == row["ChoreographerId"].ToString())
                                Choreographer.ImportRow(row1);
                        Session["Choreographer"] = Choreographer;
                        DataList1.DataSource = Choreographer;
                        DataList1.DataBind();

                        string src = row["DanceVideo"].ToString(); // סרטון הריקוד
                        src = src.Trim(new char[] { '#' });
                        //src="\"\""+src+"\"\"";
                        I1.Attributes["src"] = src;
                    }

                DataTable DancersId = new DataTable(); // מציאת ת"ז של הרקדנים שבריקוד
                foreach (DataColumn c in ((DataTable)Session["DancesDancers"]).Columns) DancersId.Columns.Add(c.ColumnName);
                foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                    if (r["DanceId"].ToString() == Session["SelectedDance"].ToString())
                        DancersId.ImportRow(r);
                DataTable DancersInDance = new DataTable(); // מציאת השמות של הרקדנים
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) DancersInDance.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in ((DataTable)Session["Users"]).Rows)
                    foreach (DataRow r2 in DancersId.Rows)
                        if (r2["DancerId"].ToString() == r1["UserId"].ToString() && r1["IsBlocked"].ToString()=="False") DancersInDance.ImportRow(r1);
                GridView1.DataSource = DancersInDance;
                GridView1.DataBind();
                Session["DancersInDan"] = DancersInDance;

                DataTable Performances = new DataTable();// מציאת ההופעות שהריקוד נמצא בהן
                foreach (DataColumn c in ((DataTable)Session["PerformancesDances"]).Columns) Performances.Columns.Add(c.ColumnName);
                foreach (DataRow r in ((DataTable)Session["PerformancesDances"]).Rows)
                    if (r["DanceId"].ToString() == Session["SelectedDance"].ToString()) Performances.ImportRow(r);
                Performances = PerformanceService.RemoveDoubles(Performances);
                GridView3.DataSource = Performances;
                GridView3.DataBind();

                DataTable Comments=new DataTable();//תגובות על הריקוד
                foreach (DataColumn c in ((DataTable)Session["DanceComments"]).Columns) Comments.Columns.Add(c.ColumnName);
                foreach(DataRow r in ((DataTable)Session["DanceComments"]).Rows) 
                    if(r["DanceId"].ToString()==Session["SelectedDance"].ToString())
                        foreach(DataRow r1 in ((DataTable)Session["Users"]).Rows)//בדיקה אם המשתמש שהגיב לא חסום
                            if(r["UserId"].ToString()==r1["UserId"].ToString())
                                if(r1["IsBlocked"].ToString()=="False")
                                    Comments.ImportRow(r);
                Session["Comments"] = Comments;
                GridView2.DataSource = Comments;
                GridView2.DataBind();
                
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

                if (u.IsAdmin || u.UserId == Choreographer.Rows[0]["UserId"].ToString())
                {
                    ImageButton4.Visible = true;
                    ImageButton8.Visible = true;
                }

                Hi.Text = "Hi, " + u.UserFirstName + " " + u.UserLastName + "!";
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ShowChoreographer") // תצוגת כראוגרף
            {
                int index = e.Item.ItemIndex;
                Session["SelectedUser"] = ((DataTable)Session["Choreographer"]).Rows[index]["UserId"].ToString();
                Session["from"] = "ShowDance1.aspx";
                Response.Redirect("ShowUser.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowDancer")//תצוגת רקדן
            {
                int index=Convert.ToInt32(e.CommandArgument);
                Session["SelectedUser"] = ((DataTable)Session["DancersInDan"]).Rows[index]["UserId"].ToString();
                Session["from"] = "ShowDance2.aspx";
                Response.Redirect("ShowUser.aspx");
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteComment")//מחיקת תגובה
            {
                DataTable Comments = (DataTable)Session["Comments"];
                string commentId = Comments.Rows[Convert.ToInt32(e.CommandArgument)][0].ToString();

                string UserId = ((DataTable)Session["Comments"]).Rows[Convert.ToInt32(e.CommandArgument)]["UserId"].ToString();//אם מוחקים תגובה המשתמש שהגיב אותה נחסם
                if (UserId != ((User)Session["User"]).UserId)
                {
                    UserService.BlockUser(UserId, true);
                    EmailService.SendEmail("You are blocked because of your comment: " + ((DataTable)Session["Comments"]).Rows[Convert.ToInt32(e.CommandArgument)]["CommentContent"].ToString(), "You are blocked because of your comment", UserService.GetEmail((DataTable)Session["Users"], UserId));//שליחת אימייל
                }
                DanceService.DeleteComment(commentId);//מחיקה ממסד הנתונים

                foreach (DataRow r in Comments.Rows)//מחיקה מטבלת תגובות
                    if (r["CommentId"].ToString() == commentId)
                        r.Delete();
                Comments.AcceptChanges();
                Session["Comments"] = Comments;
                GridView2.DataSource = Comments;
                GridView2.DataBind();

                //User u = (User)Session["User"];
                //if (u.IsAdmin)
                //{
                //    GridView2.Columns[4].Visible = true;
                //    GridView2.Columns[5].Visible = true;
                //}
                //else
                //{
                //    for (int i = 0; i < GridView2.Rows.Count; i++)
                //        if (u.UserId.ToString() != Comments.Rows[i][1].ToString())
                //            GridView2.Rows[i].Cells[4].Visible = false;
                //    GridView2.Columns[5].Visible = false;
                //}
            }
            if (e.CommandName == "BlockUser")
            {
                string UserId = ((DataTable)Session["Comments"]).Rows[Convert.ToInt32(e.CommandArgument)]["UserId"].ToString();//אם מוחקים תגובה המשתמש שהגיב אותה נחסם
                if (UserId != ((User)Session["User"]).UserId) UserService.BlockUser(UserId, true);
                EmailService.SendEmail("You are blocked because of your comment: " + ((DataTable)Session["Comments"]).Rows[Convert.ToInt32(e.CommandArgument)][2].ToString(), "You are blocked because of your comment", UserService.GetEmail((DataTable)Session["Users"], UserId));//שליחת אימייל

                DataTable Comments = (DataTable)Session["Comments"];
                string commentId = ((DataTable)Session["Comments"]).Rows[Convert.ToInt32(e.CommandArgument)][0].ToString();
                DanceService.DeleteComment(commentId);//מחיקת התגובה ממסד הנתונים
                foreach (DataRow r in Comments.Rows)//מחיקה מטבלת תגובות
                    if (r["CommentId"].ToString() == commentId)
                        r.Delete();
                Comments.AcceptChanges();
                Session["Comments"] = Comments;
                GridView2.DataSource = Comments;
                GridView2.DataBind();

                //User u = (User)Session["User"];
                //if (u.IsAdmin)
                //{
                //    GridView2.Columns[4].Visible = true;
                //    GridView2.Columns[5].Visible = true;
                //}
                //else
                //{
                //    for (int i = 0; i < GridView2.Rows.Count; i++)
                //        if (u.UserId.ToString() != Comments.Rows[i][1].ToString())
                //            GridView2.Rows[i].Cells[4].Visible = false;
                //    GridView2.Columns[5].Visible = false;
                //}
            }
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Session["from"] = "ShowDance3.aspx";
        //    Session["DanceName"] = Label4.Text;
        //    DancesDancers dancersInDance = new DancesDancers();
        //    foreach (DataRow row in ((DataTable)Session["DancersInDan"]).Rows)
        //        dancersInDance.Add(row["DancerId"].ToString());
        //    Session["DancersInDance"] = dancersInDance;
        //    Response.Redirect("ShowDancers.aspx");
        //}

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPerformance")//תצוגת הופעה
            {
                string performanceName = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                Session["SelectedPerformance"] = PerformanceService.FindPerformanceId(performanceName);
                Session["from"] = "ShowDance.aspx";
                Response.Redirect("ShowPerformance.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e) // הצגת פרטי ריקוד
        {
            Button6.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }

        protected void Button7_Click(object sender, EventArgs e)// הצגת פרטי רקדנים
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }

        protected void Button8_Click(object sender, EventArgs e)// הצגת פרטי הופעות
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }

        protected void Button9_Click(object sender, EventArgs e)// הצגת סרטון
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button10.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
        }

        protected void Button10_Click(object sender, EventArgs e)// הצגת תגובות
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//כפתור עמוד בית
        {
            Response.Redirect("HomePage.aspx");
        }


        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)//עריכת ריקוד
        {
            Response.Redirect("EditDance.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            User u = (User)Session["User"];
            DanceService.AddComment(u.UserId, Session["SelectedDance"].ToString(), tbox.Text);//הוספת תגובה
            DataTable Comments = DbManagement.GetTableByQuery("SELECT DanceComments.CommentId, DanceComments.UserId, DanceComments.DanceId, DanceComments.CommentDate, DanceComments.CommentContent, Users.UserFirstName, Users.UserLastName FROM Users INNER JOIN DanceComments ON Users.UserId = DanceComments.UserId WHERE (((DanceComments.DanceId)=" + Session["SelectedDance"].ToString() + ")) ORDER BY DanceComments.CommentDate DESC;");
            Session["Comments"] = Comments;
            GridView2.DataSource = Comments;
            GridView2.DataBind();
            tbox.Text = "";
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)//התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this dance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string DanceId = Session["SelectedDance"].ToString();

                if (!DanceService.IsInPerformance(DanceId, (DataTable)Session["PerformancesDances"])) // אם הריקוד לא בתוך הופעה מוחקים אותו
                {
                    NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId, "Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!"); //הודעה לכראוגרף
                    EmailService.SendEmail("Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!", "Your dance was deleted", UserService.GetEmail(DbManagement.GetTable("Users"), DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId));

                    DataTable dancers = DbManagement.GetTableByQuery("SELECT DancesDancers.DanceId, DancesDancers.DancerId, Users.IsBlocked FROM Users INNER JOIN DancesDancers ON Users.UserId = DancesDancers.DancerId WHERE (((DancesDancers.DanceId)=" + DanceId + ") AND ((Users.IsBlocked)=No));");
                    foreach (DataRow row in dancers.Rows)
                    {
                        NotificationService.AddNotification(row[1].ToString(), "The dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" you were in was deleted!"); //הודעה לרקדן
                        EmailService.SendEmail("Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!", "Your dance was deleted", UserService.GetEmail(DbManagement.GetTable("Users"), DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId));
                    }

                    string filePath = Server.MapPath(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).DancePhoto.ToString());
                    if (File.Exists(filePath) && DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).DancePhoto.ToString() != "/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת הריקוד מהתיקייה

                     DanceService.DeleteDance(DanceId);//מחיקה ממסד נתונים

                     foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows) // מחיקה מטבלת ריקודים
                         if (row["DanceId"].ToString() == DanceId)
                             row.Delete();
                     ((DataSet)Session["Dances"]).Tables["Dances"].AcceptChanges();
                }
                else // אם הריקוד בתוך הופעה אי אפשר למחוק אותו
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"You can't delete this dance since it has been used already. From now on it will be invalid.\");", true);
                    DanceService.DanceNotValid(DanceId, false);
                }
                Response.Redirect("ShowDances.aspx");
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable Comments = (DataTable)Session["Comments"];
            User u = (User)Session["User"];
            if (u.IsAdmin) // אדמין יכול למחוק תגובות ולחסום את המשתמשים שהגיבו
            {
                GridView2.Columns[4].Visible = true;
                GridView2.Columns[5].Visible = true;

                for (int i = 0; i < GridView2.Rows.Count; i++) // אין כפתור חסימה לתגובה של אדמין
                    if (UserService.FindUserById(((DataSet)Session["Dances"]).Tables["Users"],Comments.Rows[i][1].ToString()).IsAdmin)
                        GridView2.Rows[i].Cells[5].Visible = false;
                
            }
            else // המשתמש שהגיב יכול למחוק את התגובות שלו
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                    if (u.UserId.ToString() != Comments.Rows[i][1].ToString())
                        GridView2.Rows[i].Cells[4].Visible = false;
                GridView2.Columns[5].Visible = false;
            }
        }
















    }
}