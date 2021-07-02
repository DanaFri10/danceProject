using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.TypeClasses;
using System.Data;
using DanceProject.ServiceClasses;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using Label = System.Web.UI.WebControls.Label;
using Menu = System.Web.UI.WebControls.Menu;

namespace DanceProject.Pages
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                localhost.WebService1 x = new localhost.WebService1(); // שירות רשת
                Session["x"] = x;

                //טבלאות שבשימוש בכל העמודים
                Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים
                Session["Performances"] = DbManagement.GetTable("Performances"); // טבלת הופעות
                Session["PerformancesDates"] = x.GetTblByQuery("SELECT Performances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace, [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour] AS Expr1 FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId ORDER BY [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour];"); // תאריכי הופעות
                Session["Styles"] = DbManagement.GetTable("DanceStyleCategories");// טבלת סגנונות ריקוד
                Session["DancesDancers"]=DbManagement.GetTableByQuery("SELECT DancesDancers.DanceId, DancesDancers.DancerId, Dances.DanceName, Dances.DancePhoto, Dances.IsValid FROM DanceTypesCategories INNER JOIN (DanceStyleCategories INNER JOIN (Dances INNER JOIN DancesDancers ON Dances.DanceId = DancesDancers.DanceId) ON DanceStyleCategories.CategoryId = Dances.DanStyleCatId) ON DanceTypesCategories.CategoryId = Dances.DanTypeCatId;");
                Session["PerformancesDances"] = DbManagement.GetTableByQuery("SELECT PerformancesDances.DanceId, PerformancesDances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId FROM Performances INNER JOIN PerformancesDances ON Performances.PerformanceId = PerformancesDances.PerformanceId;");
                Session["Users"] = DbManagement.GetTable("Users"); // טבלת משתמשים
                
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                foreach (DataColumn c in ((DataTable)Session["PerformancesDates"]).Columns) dt1.Columns.Add(c.ColumnName);

                User u = (User)Session["User"]; // המשתמש שמחובר

                if (u.UserCategory == "1") // אם המשתמש שמחובר הוא כראוגרף
                {
                    Label16.Visible = false;
                    DataList3.Visible = false;

                    foreach (DataRow r in ((DataTable)Session["PerformancesDates"]).Rows)// ההופעות העתידיות של הכראוגרף שנכנס
                        if (u.UserId == r["ChoreographerId"].ToString()&& (DateTime)r["Expr1"] >= DateTime.Now )
                            dt1.ImportRow(r);
                    //dt1 = x.GetTblByQuery("SELECT Performances.ChoreographerId, [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour] AS Expr1, Performances.PerformanceId, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace, Performances.PerformanceName FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId WHERE (((Performances.ChoreographerId)=\"" + u.UserId + "\") AND (([PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour])>Now())) ORDER BY [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour];");
                    if (dt1.Rows.Count <= 0) Label9.Text = "No upcoming performances"; // הודעה במקרה שאין הופעות
                    if (dt1.Rows.Count > 5) dt1 = DbManagement.Top5(dt1); 

                    dt2 = DanceService.GetDancesInFavoriteStyles(DbManagement.GetTableByQuery("SELECT Top 1 Dances.ChoreographerId, Count(Dances.DanceId) AS CountOfDanceId, Dances.DanStyleCatId FROM Dances GROUP BY Dances.ChoreographerId, Dances.DanStyleCatId HAVING (((Dances.ChoreographerId)=\"" + u.UserId + "\")) ORDER BY Count(Dances.DanceId) DESC;")); // ריקודים בסגנון המועדף על הכאוגרף
                    if (dt2.Rows.Count <= 0) Label15.Text = "You do not have any dances"; // הודעה במקרה שאין ריקודים
                    if (dt2.Rows.Count > 5) dt2 = DbManagement.Top5(dt1);

                    DataList2.DataSource = dt2;
                    DataList2.DataBind();
                    
                    for (int i = 0; i < dt2.Rows.Count; i++) // החלפת קוד הסגנון בשם
                        foreach (DataRow row1 in ((DataTable)(Session["Styles"])).Rows)
                            if (((Label)(DataList2.Items[i].FindControl("Label13"))).Text == row1[0].ToString())
                                ((Label)(DataList2.Items[i].FindControl("Label13"))).Text = row1[1].ToString();
                }
                else // אם המשתמש שמחובר הוא רקדן
                {
                    Label14.Visible = false;
                    DataList2.Visible = false;

                    //DataTable DancerPerformances = DbManagement.GetTableByQuery("SELECT DancesDancers.DancerId, PerformancesDances.PerformanceId FROM (Dances INNER JOIN DancesDancers ON Dances.DanceId = DancesDancers.DanceId) INNER JOIN PerformancesDances ON Dances.DanceId = PerformancesDances.DanceId GROUP BY DancesDancers.DancerId, PerformancesDances.PerformanceId HAVING (((DancesDancers.DancerId)=\""+u.UserId+"\"));");
                    
                    DataTable FuturePerformances = new DataTable();// הופעות עתידיות
                    foreach (DataColumn c in ((DataTable)Session["PerformancesDates"]).Columns) FuturePerformances.Columns.Add(c.ColumnName);
                    foreach (DataRow r in ((DataTable)Session["PerformancesDates"]).Rows)
                        if (DateTime.Parse(((DateTime)r["PerformanceDate"]).ToShortDateString() +" "+ ((DateTime)r["PerformanceHour"]).ToLongTimeString()) > DateTime.Now)
                            FuturePerformances.ImportRow(r);

                    DataTable DancerDances = new DataTable(); // ריקודים של הרקדן
                    foreach (DataColumn c in ((DataTable)Session["DancesDancers"]).Columns) DancerDances.Columns.Add(c.ColumnName);
                    foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                        if (r["DancerId"].ToString() == u.UserId) DancerDances.ImportRow(r);

                    DataTable DancerPerformances = new DataTable(); // הופעות עם הריקודים של הרקדן
                    foreach (DataColumn c in ((DataTable)Session["Performances"]).Columns) DancerPerformances.Columns.Add(c.ColumnName);
                    foreach (DataRow r1 in ((DataTable)Session["PerformancesDances"]).Rows)
                        foreach (DataRow r2 in DancerDances.Rows)
                            if (r1["DanceId"].ToString() == r2["DanceId"].ToString()) DancerPerformances.ImportRow(r1);

                    DancerPerformances = PerformanceService.RemoveDoubles(DancerPerformances);// הורדת כפילויות

                    int RowsCount = 0;
                    dt1 = new DataTable(); // ההופעות העתידיות מתוך ההופעות של הרקדן
                    foreach (DataColumn c in FuturePerformances.Columns) dt1.Columns.Add(c.ColumnName);
                    foreach (DataRow r2 in FuturePerformances.Rows)
                        foreach (DataRow r1 in DancerPerformances.Rows)
                            if (r1["PerformanceId"].ToString() == r2["PerformanceId"].ToString() && RowsCount<5)
                            {
                                RowsCount++;
                                dt1.ImportRow(r2);
                            }

                    if (dt1.Rows.Count <= 0)Label9.Text = "You don't have any upcoming performances"; // הודעות אם אין הופעות
                    dt2 = FuturePerformances; 
                    if (dt2.Rows.Count <= 0) Label17.Text = "No upcoming performances";

                    if (dt2.Rows.Count > 5) dt2 = DbManagement.Top5(dt2);

                    DataList3.DataSource = dt2;
                    DataList3.DataBind();
                    }

                    DataList1.DataSource = dt1;
                    DataList1.DataBind();
                
                    DataTable NewNotifications = DbManagement.GetTableByQuery("Select * from Notifications where UserId=\"" + u.UserId + "\" and Watched=No"); // מציאת מספר ההתראות החדשות
                    Label8.Text = "   " + NewNotifications.Rows.Count.ToString();

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

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Show") // הצגת הופעה
            {
                Session["SelectedPerformance"] = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label7")).Text; // מציאת הid
                Session["from"] = "ShowPerformances.aspx";
                Response.Redirect("ShowPerformance.aspx");
            }
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ShowDance") // הצגת ריקוד
            {
                Session["SelectedDance"] = ((Label)DataList2.Items[e.Item.ItemIndex].FindControl("Label16")).Text;// מציאת הid
                Response.Redirect("ShowDance.aspx");
            }
        }
        
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                ((Label)(e.Item.FindControl("Label5"))).Text = ((Label)(e.Item.FindControl("Label5"))).Text.Substring(0, 10); // הורדת השעה מהתאריך     
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                if (((Label)(e.Item.FindControl("Label11"))).Text.Length > 10)//שינוי אורך של שם ריקוד
                    ((Label)(e.Item.FindControl("Label11"))).Text = ((Label)(e.Item.FindControl("Label11"))).Text.Substring(0, 10) + "...";
        }
        
        protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                ((Label)(e.Item.FindControl("Label5"))).Text = ((Label)(e.Item.FindControl("Label5"))).Text.Substring(0, 10); // הורדת השעה מהתאריך     
        }

        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור לעמוד בית
        {
            Response.Redirect("HomePage.aspx"); 
        }        
        
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e) // כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)// כפתור להתראות
        {
            Response.Redirect("Notifications.aspx"); 
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)// כפתור להתנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }


    }
}