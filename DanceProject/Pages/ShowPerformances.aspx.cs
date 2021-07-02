using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DanceProject.ServiceClasses;
using System.Collections;
using DanceProject.TypeClasses;
using System.Windows.Forms;
using Label = System.Web.UI.WebControls.Label;
using Button = System.Web.UI.WebControls.Button;
using System.IO;

namespace DanceProject.Pages
{
    public partial class ShowPerformances : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                localhost.WebService1 x = new localhost.WebService1();
                Session["x"] = x;

                DataTable performances = new DataTable();
                foreach (DataColumn c in ((DataTable)Session["Performances"]).Columns) performances.Columns.Add(c.ColumnName);
                if (((User)Session["User"]).UserCategory == "1")
                {
                    foreach (DataRow r in ((DataTable)Session["Performances"]).Rows)
                        if (r["ChoreographerId"].ToString() == ((User)Session["User"]).UserId)
                            performances.ImportRow(r);
                }
                else
                {
                    DataTable dances = new DataTable();
                    foreach (DataColumn c in ((DataTable)Session["DancesDancers"]).Columns) dances.Columns.Add(c.ColumnName);//תצוגת ריקודים של הרקדן
                    foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                        if (r["DancerId"].ToString() == ((User)Session["User"]).UserId)
                            dances.ImportRow(r);

                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["PerformancesDances"]).Rows)
                        if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                            performances.ImportRow(r2);
                performances = PerformanceService.RemoveDoubles(performances);
            }
                Session["DisplayedPerformances"] = performances;
                DataList1.DataSource = performances;
                DataList1.DataBind();
                if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No performances found.\");", true);
                
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Rows) //הכנסת הקטגוריות של הריקודים לdropdownlist
                    CheckBoxList1.Items.Add(row["CategoryName"].ToString());
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                    DropDownList2.Items.Add(row["DanceName"].ToString());
                
                DataTable choreographers = new DataTable(); //הכנסת רקדנים וכראוגרפים לdropwownlist
                foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Users"].Columns)
                    choreographers.Columns.Add(c.ColumnName);
                DataTable dancers = new DataTable();
                foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Users"].Columns)
                    dancers.Columns.Add(c.ColumnName);
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Users"].Rows)
                {
                    if (row["IsBlocked"].ToString() == "False")
                    {
                        if ((int)row["UserCategory"] == 1)
                        {
                            DropDownList1.Items.Add(row["UserFirstName"].ToString() + " " + row["UserLastName"].ToString());
                            DropDownList6.Items.Add(row["UserFirstName"].ToString() + " " + row["UserLastName"].ToString());
                            choreographers.ImportRow(row);
                        }
                        else
                        {
                            DropDownList3.Items.Add(row["UserFirstName"].ToString() + " " + row["UserLastName"].ToString());
                            dancers.ImportRow(row);
                        }
                    }
                }
                Session["Choreographers"] = choreographers;
                Session["Dancers"] = dancers;

                foreach (DataRow r in ((DataTable)Session["PerformancesDates"]).Rows) //מקומות של הופעות בdropdownlist
                {
                    bool found = false;
                    foreach (ListItem s in DropDownList4.Items)
                        if (s.Text == r["PerformancePlace"].ToString()) found = true;
                    if (!found) 
                        DropDownList4.Items.Add(r["PerformancePlace"].ToString());
                }

                    if (Session["from"] != null)
                        if (Session["from"].ToString() == "AddPerformance.aspx")
                            for (int i = 0; i < performances.Rows.Count; i++)
                                if (((Label)(DataList1.Items[i].FindControl("Label2"))).Text == Session["PerformanceName"].ToString())
                                    DataList1.Items[i].Visible = false;                

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

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ShowPerformance")//תצוגת הופעה
            {
                Session["SelectedPerformance"] = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label12")).Text;
                Response.Redirect("ShowPerformance.aspx");
            }
            if (e.CommandName == "EditPerformance") //עריכת הופעה
            {
                Session["SelectedPerformance"] = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label12")).Text;
                Response.Redirect("EditPerformance.aspx");
            }
            if (e.CommandName == "DeletePerformance")//מחיקת הופעה
            {
                if (MessageBox.Show("Are you sure you want to delete this performance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string PerformanceId=((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label12")).Text;

                    DataTable dances = new DataTable(); // תצוגת ריקודים בהופעה
                    foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dances.Columns.Add(c.ColumnName);
                    foreach (DataRow r1 in ((DataTable)Session["PerformancesDances"]).Rows)
                        if (r1["PerformanceId"].ToString() == PerformanceId)
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

                    NotificationService.AddNotification(PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer, "Your performance was deleted! Performance Name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName); //הודעה לכראוגרף
                    EmailService.SendEmail("Your performance was deleted! Performance Name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "Your performance was deleted!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));

                    foreach(DataRow r in dancers.Rows)
                    {
                        NotificationService.AddNotification(r["UserId"].ToString(), "A performance you are dancing in was deleted! Performance Name: " + PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceName); //הודעה לכראוגרף
                        EmailService.SendEmail("A performance you are dancing in was deleted! Performance Name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A performance you are dancing in was deleted!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));
                    }
                    foreach(DataRow r in choreographers.Rows)
                    {
                        NotificationService.AddNotification(r["UserId"].ToString(), "A performance you have a dance in was deleted! Performance Name: " + PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceName); //הודעה לכראוגרף
                        EmailService.SendEmail("A performance you have a dance in was deleted! Performance Name: " + PerformanceService.FindPerformance(Session["SelectedPerformance"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A performance you have a dance in was deleted!", UserService.GetEmail((DataTable)Session["Users"], PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformanceChoreographer));
                    }
                    
                    string filePath = Server.MapPath((PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"]).PerformancePhoto.ToString()));
                    if (File.Exists(filePath) && (PerformanceService.FindPerformance(PerformanceId, (DataTable)Session["Performances"])).PerformancePhoto.ToString() != "/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת ההופעה מהתיקייה

                    DataTable dt1 = (DataTable)Session["DisplayedPerformances"];
                    for (int i = 0; i < dt1.Rows.Count; i++)//מחיקה מDataTable
                    {
                        DataRow dr = dt1.Rows[i];
                        if (dr["PerformanceId"].ToString() == PerformanceId)
                            dr.Delete();
                    }
                    dt1.AcceptChanges();

                    DataTable dt2 = (DataTable)Session["Performances"];
                    for (int i = 0; i < dt2.Rows.Count; i++)//מחיקה מDataTable
                    {
                        DataRow dr = dt2.Rows[i];
                        if (dr["PerformanceId"].ToString() ==PerformanceId)
                            dr.Delete();
                    }
                    dt2.AcceptChanges();

                    PerformanceService.DeletePerformance(PerformanceId); // מחיקה ממסד הנתונים
                    ((localhost.WebService1)Session["x"]).DeletePerformance(PerformanceId); //מחיקה משירות רשת
                    Session["PerformancesDates"] = ((localhost.WebService1)Session["x"]).GetTblByQuery("SELECT Performances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace, [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour] AS Expr1 FROM Performances INNER JOIN PerformancesDates ON Performances.PerformanceId = PerformancesDates.PerformanceId ORDER BY [PerformancesDates]![PerformanceDate]+[PerformancesDates]![PerformanceHour];"); // תאריכי הופעות
                    DataList1.DataSource = dt1;
                    DataList1.DataBind();
                }
            }
        }

      
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((Label)(e.Item.FindControl("Label2"))).Text.Length > 10)//שינוי אורך של שם ריקוד
                    ((Label)(e.Item.FindControl("Label2"))).Text = ((Label)(e.Item.FindControl("Label2"))).Text.Substring(0, 7) + "...";

                User u = (User)Session["User"];
                if (PerformanceService.FindPerformance(((Label)e.Item.FindControl("Label12")).Text, (DataTable)Session["Performances"]).PerformanceChoreographer == u.UserId || u.IsAdmin) // רק הכראוגרף של הריקוד או אדמין יכול למחוק ולערוך ריקוד
                {
                    e.Item.FindControl("ImageButton12").Visible = true;
                    e.Item.FindControl("ImageButton13").Visible = true;
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string choreographer = ""; // סינון לפי כראוגרף
                if (DropDownList1.SelectedIndex != 0) choreographer = "And Dances.ChoreographerID=\"" + ((DataTable)Session["Choreographers"]).Rows[DropDownList1.SelectedIndex - 1]["UserId"] + "\"";

                string PerformancesLength = "";// סינון לפי אורך ההופעה
                if (TextBox1.Text != "" || TextBox2.Text != "")
                {
                    double from1 = 0.0, to1 = 0.0;
                    if (TextBox1.Text != "") from1 = Convert.ToDouble(TextBox1.Text);
                    if (TextBox2.Text != "") to1 = Convert.ToDouble(TextBox2.Text);
                    if (TextBox1.Text != "" && TextBox2.Text != "") PerformancesLength = "Performances.PerformanceLength>=" + from1 + " And Performances.PerformanceLength<=" + to1;
                    if (TextBox1.Text != "" && TextBox2.Text == "") PerformancesLength = "Performances.PerformanceLength>=" + from1;
                    if (TextBox1.Text == "" && TextBox2.Text != "") PerformancesLength = "Performances.PerformanceLength<=" + to1;
                }
                else PerformancesLength = "Performances.PerformanceLength>=0";

                string PerformancesDate = ""; // סינון לפי הופעות עבר ועתיד
                if (DropDownList5.SelectedValue != "All")
                {
                    if (DropDownList5.SelectedValue == "Past Performances") PerformancesDate = "AND PerformancesDates.PerformanceDate<=Date()";
                    else PerformancesDate = "AND PerformancesDates.PerformanceDate>=Date()";
                }

                string from2 = TextBox4.Text, to2 = TextBox5.Text; // סינון לפי תאריך ההופעה
                if (from2 != "" || to2 != "")
                {
                    if (from2 != "" && to2 != "") PerformancesDate += " And PerformancesDates.PerformanceDate>=#" + from2 + "# And PerformancesDates.PerformanceDate<=#" + to2 + "#";
                    if (from2 != "" && to2 == "") PerformancesDate += " And PerformancesDates.PerformanceDate>=#" + from2 + "#";
                    if (from2 == "" && to2 != "") PerformancesDate += " And PerformancesDates.PerformanceDate<=#" + to2 + "#";
                }

                string dance = ""; // סינון לפי ריקוד
                if (DropDownList2.SelectedIndex != 0) dance = "AND DancesDancers.DanceId=" + ((DataSet)Session["Dances"]).Tables["Dances"].Rows[DropDownList2.SelectedIndex - 1]["DanceId"] + "";

                string dancer = "";// סינון לפי רקדן
                if (DropDownList3.SelectedIndex != 0) dancer = "AND DancesDancers.DancerId=\"" + ((DataTable)Session["Dancers"]).Rows[DropDownList3.SelectedIndex - 1]["UserId"] + "\"";

                string CreationDate = ""; // סינון לפי תאריך יצירה
                string from3 = TextBox6.Text, to3 = TextBox7.Text;
                if (from3 != "" || to3 != "")
                {
                    if (from3 != "" && to3 != "") CreationDate = "AND Performances.CreationDate>=#" + from3 + "# And Performances.CreationDate<=#" + to3 + "#";
                    if (from3 != "" && to3 == "") CreationDate = "AND Performances.CreationDate>=#" + from3 + "#";
                    if (from3 == "" && to3 != "") CreationDate = "AND Performances.CreationDate<=#" + to3 + "#";
                }

                string creator = "";//סינון לפי הכראוגרף שיצר את ההופעה
                if (DropDownList6.SelectedIndex != 0) creator = "And Performances.ChoreographerID=\"" + ((DataTable)Session["Choreographers"]).Rows[DropDownList6.SelectedIndex - 1]["UserId"] + "\"";

                string hour = ""; // סינון לפי שעת ההופעה
                string from4 = TextBox8.Text, to4 = TextBox9.Text;
                if (from4 != "" || to4 != "")
                {
                    if (from4 != "" && to4 != "") hour = "PerformancesDates.PerformanceHour>=#" + from4 + "# And PerformancesDates.PerformanceHour<=#" + to4 + "#";
                    if (from4 != "" && to4 == "") hour = "PerformancesDates.PerformanceHour>=#" + from4 + "#";
                    if (from4 == "" && to4 != "") hour = "PerformancesDates.PerformanceHour<=#" + to4 + "#";
                }
                else hour = "PerformancesDates.PerformanceHour>=#00:00#";

                string place = "";// סינון לפי מקום ההופעה
                if (DropDownList4.SelectedValue != "All") place = " AND PerformancesDates.PerformancePlace=\"" + DropDownList4.SelectedValue + "\"";

                DataTable filteredPerformances = DbManagement.GetTableByQuery("SELECT Performances.PerformanceId, Performances.ChoreographerId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, PerformancesDances.DanceId, Dances.ChoreographerId, DancesDancers.DancerId FROM Performances INNER JOIN ((Dances INNER JOIN PerformancesDances ON Dances.DanceId = PerformancesDances.DanceId) INNER JOIN DancesDancers ON Dances.DanceId = DancesDancers.DanceId) ON Performances.PerformanceId = PerformancesDances.PerformanceId WHERE " + PerformancesLength + " " + CreationDate + " " + dance + " " + creator + " " + choreographer + " " + dancer + ";");

                DataTable filteredPerformances0 = new DataTable(); // סינון לפי תאריכים
                if (!(TextBox4.Text == "" && TextBox5.Text == "" && TextBox8.Text == "" && TextBox9.Text == "" && DropDownList4.SelectedValue == "All"))
                {
                    string y = "SELECT PerformancesDates.PerformanceId, PerformancesDates.PerformanceDate, PerformancesDates.PerformanceHour, PerformancesDates.PerformancePlace FROM PerformancesDates WHERE " + hour + PerformancesDate + place;
                    DataTable filteredPerformancesFromWS = ((localhost.WebService1)Session["x"]).GetTblByQuery(y);
                    foreach (DataColumn column in filteredPerformances.Columns)//העברת השדות מטבלת הופעות לטבלת הופעות אחרי סינונים
                        filteredPerformances0.Columns.Add(column.ColumnName.ToString());
                    foreach (DataRow row in filteredPerformances.Rows)
                        foreach (DataRow row1 in filteredPerformancesFromWS.Rows)
                            if (row["PerformanceId"].ToString() == row1["PerformanceId"].ToString())
                                filteredPerformances0.ImportRow(row);
                }
                else filteredPerformances0 = filteredPerformances;

                DataTable filteredPerformances1 = new DataTable(); //סינון לפי ריקודים
                if (CheckBoxList1.SelectedIndex != -1)
                {
                    DataTable dances = (DanceService.GetDancesWithConn(null)).Tables["Dances"];
                    ArrayList SelectedValues = new ArrayList();//הקטגוריות לסינון

                    foreach (ListItem item in CheckBoxList1.Items)
                        if (item.Selected) SelectedValues.Add(item.Text);
                    dances = DbManagement.FilterByCategory(dances, SelectedValues, "DanceStyle");//סינון ריקודים לפי סגנון

                    foreach (DataColumn column in filteredPerformances0.Columns)//העברת השדות מטבלת הופעות לטבלת הופעות אחרי סינונים
                        filteredPerformances1.Columns.Add(column.ColumnName.ToString());
                    if (dances.Rows.Count > 0)
                    {
                        foreach (DataRow row in filteredPerformances0.Rows)
                            foreach (DataRow row1 in dances.Rows)
                                if (row["DanceId"].ToString() == row1["DanceId"].ToString())
                                    filteredPerformances1.ImportRow(row);
                    }
                }
                else filteredPerformances1 = filteredPerformances0;

                DataTable filteredPerformances2 = new DataTable(); //ההופעות אחרי הסינון יחד עם ההופעות שמופיעות כרגע
                foreach (DataColumn column in filteredPerformances1.Columns)//העברת השדות מטבלת הופעות לטבלת הופעות אחרי סינונים
                    filteredPerformances2.Columns.Add(column.ColumnName.ToString());
                DataTable dt = (DataTable)Session["DisplayedPerformances"];
                foreach (DataRow row in dt.Rows)
                    foreach (DataRow row1 in filteredPerformances1.Rows)
                        if (row["PerformanceId"].ToString() == row1["PerformanceId"].ToString())
                            filteredPerformances2.ImportRow(row1);

                DataTable filteredPerformances3 = new DataTable(); // הורדת כפילויות
                foreach (DataColumn column in filteredPerformances2.Columns)//העברת השדות מטבלת הופעות לטבלת הופעות אחרי סינונים
                    filteredPerformances3.Columns.Add(column.ColumnName.ToString());
                foreach (DataRow row in filteredPerformances2.Rows)
                {
                    bool found = false;
                    foreach (DataRow row1 in filteredPerformances3.Rows)
                        if (row["PerformanceId"].ToString() == row1["PerformanceId"].ToString()) found = true;
                    if (!found) filteredPerformances3.ImportRow(row);
                }

                DataList1.DataSource = filteredPerformances3;
                DataList1.DataBind();

                if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No performances found.\");", true); // הודעה אם אין הופעות
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Label28.Visible = true;
            DropDownList6.Visible = true;

            Session["DisplayedPerformances"] = (DataTable)Session["Performances"];
            DataList1.DataSource = (DataTable)Session["Performances"];
            DataList1.DataBind();

            if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No performances found.\");", true);

            Button7.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button8.BackColor = System.Drawing.Color.White;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Label28.Visible = false;
            DropDownList6.Visible = false;

            DataTable performances = new DataTable();
            foreach (DataColumn c in ((DataTable)Session["Performances"]).Columns) performances.Columns.Add(c.ColumnName);
            if (((User)Session["User"]).UserCategory == "1")
            {
                foreach (DataRow r in ((DataTable)Session["Performances"]).Rows)
                    if (r["ChoreographerId"].ToString() == ((User)Session["User"]).UserId)
                        performances.ImportRow(r);
            }
            else
            {
                DataTable dances = new DataTable();
                foreach (DataColumn c in ((DataTable)Session["DancesDancers"]).Columns) dances.Columns.Add(c.ColumnName);//תצוגת ריקודים של הרקדן
                foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                    if (r["DancerId"].ToString() == ((User)Session["User"]).UserId)
                        dances.ImportRow(r);

                foreach (DataColumn c in ((DataTable)Session["PerformancesDances"]).Columns) performances.Columns.Add(c.ColumnName);
                foreach (DataRow r1 in dances.Rows)
                    foreach (DataRow r2 in ((DataTable)Session["PerformancesDances"]).Rows)
                        if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                            performances.ImportRow(r2);
                performances = PerformanceService.RemoveDoubles(performances);
            }
            Session["DisplayedPerformances"] = performances;
            DataList1.DataSource = performances;
            DataList1.DataBind();
            
            if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No performances found.\");", true);

            Button8.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button7.BackColor = System.Drawing.Color.White;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            TextBox4.Text = "";
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            TextBox5.Text = "";
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            TextBox6.Text = "";
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            TextBox7.Text = "";
        }
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            TextBox8.Text = "";
        }
        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            TextBox9.Text = "";
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e) //כפתור לדף הבית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e) //חיפוש הופעה לפי שם ההופעה
        {
            DataTable performances = (DataTable)Session["Performances"];
            DataTable dt = new DataTable();
            if (TextBox3.Text != "")
            {
                foreach (DataColumn column in performances.Columns)
                    dt.Columns.Add(column.ColumnName.ToString());

                foreach (DataRow row in performances.Rows)
                    if (row["PerformanceName"].ToString() == TextBox3.Text.ToString())
                        dt.ImportRow(row);
                DataList1.DataSource = dt;
            }
            else DataList1.DataSource = performances;
            DataList1.DataBind();

            if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No performances found.\");", true);
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)//כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)//כפתור להתראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton14_Click(object sender, ImageClickEventArgs e)//התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }

        protected void ImageButton15_Click(object sender, ImageClickEventArgs e)//כפתור להתראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}