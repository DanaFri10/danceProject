using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DanceProject.ServiceClasses;
using System.Windows.Forms;
using Label = System.Web.UI.WebControls.Label;
using Button = System.Web.UI.WebControls.Button;
using DanceProject.TypeClasses;
using System.IO;

namespace DanceProject.Pages
{
    public partial class BlockedUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable blockedUsers = new DataTable(); // משתמשים חסומים
                DataTable newUsers = new DataTable(); // משתמשים חדשים שעוד לא אושרו
                DataTable newDances = new DataTable();//ריקודים חדשים שעוד לא אושרו
                DataTable newPerformances = new DataTable(); //הופעות חדשות שעוד לא אושרו

                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns)// העברת השדות לטבלה חדשה
                {
                    blockedUsers.Columns.Add(c.ColumnName);
                    newUsers.Columns.Add(c.ColumnName);
                }
                foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) newDances.Columns.Add(c.ColumnName);
                foreach (DataColumn c in ((DataTable)Session["Performances"]).Columns) newPerformances.Columns.Add(c.ColumnName);

                foreach (DataRow r in ((DataTable)Session["Users"]).Rows) // המשתמשים החסומים
                    if (r["IsBlocked"].ToString() == "True")
                        blockedUsers.ImportRow(r);
                GridView2.DataSource = blockedUsers;
                GridView2.DataBind();
                Session["BlockedUsers"] = blockedUsers;

                foreach (DataRow r in ((DataTable)Session["Users"]).Rows) // משתמשים חדשים שעוד לא אושרו
                    if (r["IsBlocked"].ToString() == "False" && r["IsConfirmed"].ToString() == "False")
                        newUsers.ImportRow(r);
                GridView3.DataSource = newUsers;
                GridView3.DataBind();
                Session["NewUsers"] = newUsers;

                foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["Dances"].Rows) // ריקודים חדשים שעוד לא אושרו
                    if (r["IsValid"].ToString() == "True" && r["IsConfirmed"].ToString() == "False")
                        newDances.ImportRow(r);
                GridView4.DataSource = newDances;
                GridView4.DataBind();
                Session["NewDances"] = newDances;

                foreach (DataRow r in ((DataTable)Session["Performances"]).Rows) // הופעות שעוד לא אושרו
                    if (r["IsConfirmed"].ToString() == "False")
                        newPerformances.ImportRow(r);
                GridView5.DataSource = newPerformances;
                GridView5.DataBind();
                Session["NewPerformances"] = newPerformances;

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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Unblock") // ביטול החסימה
            {
                if (MessageBox.Show("Are you sure you want to unblock this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string UserId = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    UserService.BlockUser(UserId, false); //חסימה במסד הנתונים

                    DataTable blockedUsers = (DataTable)Session["BlockedUsers"];
                    DataTable newUsers = (DataTable)Session["NewUsers"];

                    for(int i=0;i<((DataTable)Session["Users"]).Rows.Count;i++) // שינוי החסימה בטבלת משתמשים
                        if (((DataTable)Session["Users"]).Rows[i]["UserId"].ToString() == UserId)
                            ((DataTable)Session["Users"]).Rows[i]["IsBlocked"] = false;
                   ((DataTable)Session["Users"]).AcceptChanges();

                    bool found = false;
                    for (int i = 0; i < blockedUsers.Rows.Count && !found; i++)
                        if (blockedUsers.Rows[i]["UserId"].ToString() == UserId)
                        {
                            blockedUsers.Rows[i]["IsBlocked"] = false; //ביטול חסימה בטבלה
                            if(blockedUsers.Rows[i]["IsConfirmed"].ToString()=="False") newUsers.ImportRow(blockedUsers.Rows[i]); //העברה לטבלת המשתמשים החדשים אם המשתמש עדיין לא אושר
                            blockedUsers.Rows[i].Delete(); // מחיקה מטבלת המשתמשים החסומים
                            found = true;
                        }
                    blockedUsers.AcceptChanges();
                    GridView3.DataSource = newUsers;
                    GridView3.DataBind();
                    Session["NewUsers"] = newUsers;

                    GridView2.DataSource = blockedUsers;
                    GridView2.DataBind();
                    Session["BlockedUsers"] = blockedUsers;

                    EmailService.SendEmail("You are unblocked!", "You are unblocked", UserService.GetEmail((DataTable)Session["Users"], UserId));
                         
                }
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Block") // חסימת משתמש
            {
                if (MessageBox.Show("Are you sure you want to block this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string UserId = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    DataTable newUsers = (DataTable)Session["NewUsers"];
                    DataTable blockedUsers = (DataTable)Session["BlockedUsers"];

                    for (int i = 0; i < ((DataTable)Session["Users"]).Rows.Count; i++) // שינוי החסימה בטבלת משתמשים
                        if (((DataTable)Session["Users"]).Rows[i]["UserId"].ToString() == UserId)
                            ((DataTable)Session["Users"]).Rows[i]["IsBlocked"] = true;
                    ((DataTable)Session["Users"]).AcceptChanges();

                    UserService.BlockUser(UserId, true); // חסימה במסד הנתונים

                    for (int i = 0; i < newUsers.Rows.Count; i++)
                        if (newUsers.Rows[i]["UserId"].ToString() == UserId)
                        {
                            blockedUsers.ImportRow(newUsers.Rows[i]); // הוספה לטבלת המשתמשים החסומים
                            newUsers.Rows[i].Delete(); // מחיקה מטבלת המשתמשים החדשים
                        }
                    newUsers.AcceptChanges();
                    GridView3.DataSource = newUsers;
                    GridView3.DataBind();
                    Session["NewUsers"] = newUsers;
                    
                    GridView2.DataSource = blockedUsers;
                    GridView2.DataBind();
                    Session["BlockedUsers"] = blockedUsers;

                    EmailService.SendEmail("You are blocked!", "You are blocked", UserService.GetEmail((DataTable)Session["Users"], UserId));
                         
                }
            }

            if (e.CommandName == "Confirm") //אישור משתמש
            {
                string UserId = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                DataTable newUsers = (DataTable)Session["NewUsers"];

                for (int i = 0; i < ((DataTable)Session["Users"]).Rows.Count; i++) // אישור משתמש בטבלת משתמשים
                    if (((DataTable)Session["Users"]).Rows[i]["UserId"].ToString() == UserId)
                        ((DataTable)Session["Users"]).Rows[i]["IsConfirmed"] = true;
                ((DataTable)Session["Users"]).AcceptChanges();

                UserService.ConfirmUser(UserId, true); // אישור משתמש במסד הנתונים

                for(int i=0;i<newUsers.Rows.Count;i++)
                    if (newUsers.Rows[i]["UserId"].ToString() == UserId)
                        newUsers.Rows[i].Delete(); // מחיקת המשתמש מטבלת המשתמשים החדשים
                newUsers.AcceptChanges();
                GridView3.DataSource = newUsers;
                GridView3.DataBind();
                Session["NewUsers"] = newUsers;

                NotificationService.AddNotification(UserId, "You were confirmed by the admin!"); //הודעה לרקדן
                EmailService.SendEmail("You were confirmed by the admin!", "You were confirmed by the admin!", UserService.GetEmail((DataTable)Session["Users"], UserId));       
            }
        }

            protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "Confirm") // אישור
                {
                    if (MessageBox.Show("Are you sure you want to confirm this dance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string DanceId = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                        DataTable newDances = (DataTable)Session["NewDances"];

                        DanceService.ConfirmDance(DanceId, true); //אישור במסד הנתונים
                        
                        foreach (DataRow r in (((DataSet)Session["Dances"]).Tables["Dances"]).Rows) // אישור בטבלת הריקודים
                            if (r["DanceId"].ToString() == DanceId) r["IsConfirmed"] = true;
                        (((DataSet)Session["Dances"]).Tables["Dances"]).AcceptChanges();

                        for (int i = 0; i < newDances.Rows.Count; i++)
                            if (newDances.Rows[i]["DanceId"].ToString() == DanceId)
                                newDances.Rows[i].Delete(); // מחיקה מטבלת הריקודים החדשים
                        newDances.AcceptChanges();
                        GridView4.DataSource = newDances;
                        GridView4.DataBind();
                        Session["NewDances"] = newDances;

                        NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId, "Your dance was confirmed by the admin!"); //הודעה לרקדן
                        EmailService.SendEmail("Your dance was confirmed by the admin!", "Your dance was confirmed by the admin!", UserService.GetEmail((DataTable)Session["Users"], DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId));       
      
                    }
                }

                if (e.CommandName == "Delete") // מחיקת ריקוד
                {
                    if (MessageBox.Show("Are you sure you want to delete this dance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string DanceId = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                        if (!DanceService.IsInPerformance(DanceId, (DataTable)Session["PerformancesDances"])) // אם הריקוד לא בתוך הופעה מוחקים אותו
                        {
                            string filePath = Server.MapPath(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).DancePhoto.ToString());
                        if (File.Exists(filePath) && DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).DancePhoto.ToString() != "/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת הריקוד מהתיקייה

                            NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId, "Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!"); //הודעה לכראוגרף
                            EmailService.SendEmail("Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!", "Your dance was deleted", UserService.GetEmail(DbManagement.GetTable("Users"), DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId));

                            DataTable dancers = DbManagement.GetTableByQuery("SELECT DancesDancers.DanceId, DancesDancers.DancerId, Users.IsBlocked FROM Users INNER JOIN DancesDancers ON Users.UserId = DancesDancers.DancerId WHERE (((DancesDancers.DanceId)=" + DanceId + ") AND ((Users.IsBlocked)=No));");
                            foreach (DataRow row in dancers.Rows)
                            {
                                NotificationService.AddNotification(row[1].ToString(), "The dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" you were in was deleted!"); //הודעה לרקדן
                                EmailService.SendEmail("Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!", "Your dance was deleted", UserService.GetEmail(DbManagement.GetTable("Users"), DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId));
                            }
                            DanceService.DeleteDance(DanceId); // מחיקה ממסד נתונים

                        }
                        else // אם הריקוד בתוך הופעה אי אפשר למחוק אותו
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"You can't delete this dance since it has been used already. From now on it will be invalid.\");", true);
                            DanceService.DanceNotValid(DanceId, false); // הריקוד לא תקף במסד הנתונים
                        }

                        foreach (DataRow r in (((DataSet)Session["Dances"]).Tables["Dances"]).Rows) // מחיקה מטבלת ריקודים
                            if (r["DanceId"].ToString() == DanceId) r.Delete();
                        (((DataSet)Session["Dances"]).Tables["Dances"]).AcceptChanges();

                        DataTable newDances = (DataTable)Session["NewDances"]; // מחיקה מטבלת הריקודים החדשים
                        for (int i = 0; i < newDances.Rows.Count; i++)
                            if (newDances.Rows[i]["DanceId"].ToString() == DanceId)
                                newDances.Rows[i].Delete();
                        newDances.AcceptChanges();
                        GridView4.DataSource = newDances;
                        GridView4.DataBind();
                        Session["NewDances"] = newDances;

                     }
                }
            }

            protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "Confirm") // אישור
                {
                    string PerformanceId = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    
                    PerformanceService.ConfirmPerformance(PerformanceId, true); //אישור במסד הנתונים

                    foreach (DataRow r in ((DataTable)Session["Performances"]).Rows) // אישור בטבלת הופעות
                        if (r["PerformanceId"].ToString() == PerformanceId) r["IsConfirmed"] = true;
                    ((DataTable)Session["Performances"]).AcceptChanges();

                    DataTable newPerformances = (DataTable)Session["newPerformances"];
                    for (int i = 0; i < newPerformances.Rows.Count; i++)
                        if (newPerformances.Rows[i]["PerformanceId"].ToString() == PerformanceId)
                            newPerformances.Rows[i].Delete(); // מחיקה מטבלת ההופעות החדשות
                    newPerformances.AcceptChanges();
                    GridView5.DataSource = newPerformances;
                    GridView5.DataBind();
                    Session["NewPerformances"] = newPerformances;

                    NotificationService.AddNotification(PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer, "Your performance was confirmed by the admin!"); //הודעה לרקדן
                    EmailService.SendEmail("Your performance was confirmed by the admin!", "Your performance was confirmed by the admin!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));       

                }

                if (e.CommandName == "Delete") // מחיקה
                {
                    if (MessageBox.Show("Are you sure you want to delete this performance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string PerformanceId = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                        string filePath = Server.MapPath((PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"])).PerformancePhoto.ToString());
                        if (File.Exists(filePath) && (PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"])).PerformancePhoto.ToString() != "/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת ההופעה מהתיקייה

                        PerformanceService.DeletePerformance(PerformanceId); // מחיקה ממסד הנתונים

                        DataTable Performances = (DataTable)Session["Performances"];
                        for (int i = 0; i < Performances.Rows.Count; i++)
                            if (Performances.Rows[i]["PerformanceId"].ToString() == PerformanceId)
                                Performances.Rows[i].Delete(); // מחיקה מטבלת הופעות
                        Performances.AcceptChanges();
                        Session["Performances"] = Performances;
                        
                        DataTable newPerformances = (DataTable)Session["newPerformances"];
                        for (int i = 0; i < newPerformances.Rows.Count; i++)
                            if (newPerformances.Rows[i]["PerformanceId"].ToString() == PerformanceId)
                                newPerformances.Rows[i].Delete(); // מחיקה מטבלת הופעות חדשות
                        newPerformances.AcceptChanges();
                        GridView5.DataSource = newPerformances;
                        GridView5.DataBind();
                        Session["NewPerformances"] = newPerformances;
                        
                        ((localhost.WebService1)Session["x"]).DeletePerformance(Session["SelectedPerformance"].ToString()); //מחיקה משירות רשת
                    Session["PerformancesDates"] = ((localhost.WebService1)Session["x"]).GetTblByQuery("SELECT Performances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace, [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour] AS Expr1 FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId ORDER BY [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour];"); // תאריכי הופעות

                    NotificationService.AddNotification(PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer, "Your performance was deleted!"); //הודעה לרקדן
                    EmailService.SendEmail("Your performance was deleted!", "Your performance was deleted!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));       

                    }
                }
            }

            protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {

            }

            protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {

            }
            protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור עמוד בית
            {
                Response.Redirect("HomePage.aspx");
            }

            protected void ImageButton2_Click(object sender, ImageClickEventArgs e) // כפתור התראות
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

            protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox1.Text == "") // אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView2.DataSource = (DataTable)Session["BlockedUsers"];
                    GridView2.DataBind();  
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["BlockedUsers"]).Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת משתמשים
                    foreach (DataRow r in ((DataTable)Session["BlockedUsers"]).Rows)
                        if (r["UserId"].ToString() == TextBox1.Text) // מציאת המשתמש
                            dt.ImportRow(r);
                                
                    GridView2.DataSource = dt;
                    GridView2.DataBind(); 
                }
                if (GridView2.Rows.Count <= 0) // הודעה אם המשתמש לא נמצא
                {
                    GridView2.DataSource = (DataTable)Session["BlockedUsers"];
                    GridView2.DataBind(); 
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This user was not found.\");", true);    
                }
            }

            protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox2.Text == "")// אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView2.DataSource = (DataTable)Session["BlockedUsers"];
                    GridView2.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["BlockedUsers"]).Columns) dt.Columns.Add(c.ColumnName);// העתקת השדות מטבלת משתמשים
                    foreach (DataRow r in ((DataTable)Session["BlockedUsers"]).Rows)
                        if (r["UserFirstName"].ToString() + " " + r["UserLastName"].ToString() == TextBox2.Text)// מציאת המשתמש
                            dt.ImportRow(r);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                if (GridView2.Rows.Count <= 0) // הודעה אם המשתמש לא נמצא
                {
                    GridView2.DataSource = (DataTable)Session["BlockedUsers"];
                    GridView2.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This user was not found.\");", true);
                }   
            }

            protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox3.Text == "")// אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView3.DataSource = (DataTable)Session["NewUsers"];
                    GridView3.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["NewUsers"]).Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת משתמשים
                    foreach (DataRow r in ((DataTable)Session["NewUsers"]).Rows)
                        if (r["UserId"].ToString() == TextBox3.Text) // מציאת המשתמש
                            dt.ImportRow(r);
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                if (GridView3.Rows.Count <= 0) // הודעה אם המתשמש לא נמצא
                {
                    GridView3.DataSource = (DataTable)Session["NewUsers"];
                    GridView3.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This user was not found.\");", true); 
                }  
            }

            protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox4.Text == "")// אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView3.DataSource = (DataTable)Session["NewUsers"];
                    GridView3.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["NewUsers"]).Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת משתמשים
                    foreach (DataRow r in ((DataTable)Session["NewUsers"]).Rows)
                        if (r["UserFirstName"].ToString() + " " + r["UserLastName"].ToString() == TextBox4.Text)// מציאת המשתמש
                            dt.ImportRow(r);
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                if (GridView3.Rows.Count <= 0) // הודעה אם לא נמצא משתמש
                {
                    GridView3.DataSource = (DataTable)Session["NewUsers"];
                    GridView3.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This user was not found.\");", true); 
                } 
            }

            protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox5.Text == "")// אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView4.DataSource = (DataTable)Session["NewDances"];
                    GridView4.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["NewDances"]).Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת ריקודים
                    foreach (DataRow r in ((DataTable)Session["NewDances"]).Rows)
                        if (r["DanceId"].ToString() == TextBox5.Text) // מציאת הריקוד
                            dt.ImportRow(r);
                    GridView4.DataSource = dt;
                    GridView4.DataBind();
                }
                if (GridView4.Rows.Count <= 0) // הודעה אם לא נמצא ריקוד
                {
                    GridView4.DataSource = (DataTable)Session["NewDances"];
                    GridView4.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This dance was not found.\");", true);
                }
            }

            protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox6.Text == "")// אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView4.DataSource = (DataTable)Session["NewDances"];
                    GridView4.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["NewDances"]).Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת ריקודים
                    foreach (DataRow r in ((DataTable)Session["NewDances"]).Rows)
                        if (r["DanceName"].ToString() == TextBox6.Text) // מציאת הריקוד
                            dt.ImportRow(r);
                    GridView4.DataSource = dt;
                    GridView4.DataBind();
                }
                if (GridView4.Rows.Count <= 0) // הודעה אם לא נמצא ריקוד
                {
                    GridView4.DataSource = (DataTable)Session["NewDances"];
                    GridView4.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This dance was not found.\");", true);
                } 
            }

            protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox7.Text == "")// אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView5.DataSource = (DataTable)Session["NewPerformances"];
                    GridView5.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["NewPerformances"]).Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת הופעות
                    foreach (DataRow r in ((DataTable)Session["NewPerformances"]).Rows)
                        if (r["PerformanceId"].ToString() == TextBox7.Text) // מציאת ההופעה
                            dt.ImportRow(r);
                    GridView5.DataSource = dt;
                    GridView5.DataBind();
                }
                if (GridView5.Rows.Count <= 0) // הודעה אם לא נמצאה הופעה
                {
                    GridView5.DataSource = (DataTable)Session["NewPerformances"];
                    GridView5.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This performance was not found.\");", true);
                }
            }

            protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
            {
                if (TextBox8.Text == "")// אם לא מחפשים שום דבר תוצג כל הטבלה
                {
                    GridView5.DataSource = (DataTable)Session["NewPerformances"];
                    GridView5.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["NewPerformances"]).Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת הופעות
                    foreach (DataRow r in ((DataTable)Session["NewPerformances"]).Rows)
                        if (r["PerformanceName"].ToString() == TextBox8.Text) // מציאת שם ההופעה
                            dt.ImportRow(r);
                    GridView5.DataSource = dt;
                    GridView5.DataBind();
                }
                if (GridView5.Rows.Count <= 0) // הודעה אם לא נמצאה הופעה
                {
                    GridView5.DataSource = (DataTable)Session["NewPerformances"];
                    GridView5.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This performance was not found.\");", true); 
                }
            }
        }
    }
