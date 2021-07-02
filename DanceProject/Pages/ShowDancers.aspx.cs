using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DanceProject.ServiceClasses;
using DanceProject.TypeClasses;
using System.Collections;
using System.Windows.Forms;
using Label = System.Web.UI.WebControls.Label;
using Button = System.Web.UI.WebControls.Button;

namespace DanceProject.Pages
{
    public partial class ShowDancers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dances = ((DataSet)Session["Dances"]).Tables["Dances"];
                DataTable performances = (DataTable)Session["Performances"];
                Session["Performances"] = performances;

                foreach (DataRow row in dances.Rows) // ריקודים והופעות בdropdownlist
                    if(row["IsValid"].ToString()=="True")
                    DropDownList1.Items.Add(row["DanceName"].ToString());
                foreach (DataRow row in performances.Rows)
                    DropDownList2.Items.Add(row["PerformanceName"].ToString());
                                
                DataTable dancers = new DataTable(); //טבלת רקדנים
                foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) dancers.Columns.Add(c.ColumnName);
                foreach (DataRow r in ((DataTable)Session["Users"]).Rows)
                    if (int.Parse(r["UserCategory"].ToString()) == 2 && r["IsBlocked"].ToString() == "False")
                        dancers.ImportRow(r);
                DataList1.DataSource = dancers;
                DataList1.DataBind();
                Session["Dancers"] = dancers;
                
                if (dancers.Rows.Count <= 0) Label24.Text = "No dancers found"; //הודעה אם אין רקדנים
                else Label24.Text = "";

                if (Session["dancersInDance"] != null)
                {
                    DancesDancers dancersInDance = (DancesDancers)Session["dancersInDance"];
                    GridView1.DataSource = dancersInDance.TurnToDT(dancers);
                    GridView1.DataBind();
                }

                if (Session["from"] != null)
                {
                    if (Session["from"].ToString() == "AddDance.aspx")
                    {
                        DataTable OriginalDancers = DbManagement.GetTableByQuery("SELECT Users.UserId, Users.IsBlocked, DancesDancers.DanceId, * FROM Users INNER JOIN DancesDancers ON Users.UserId = DancesDancers.DancerId WHERE (((Users.IsBlocked)=No) AND ((DancesDancers.DanceId)=" + DanceService.FindDanceId(Session["DanceName"].ToString()) + "));");
                        Session["OriginalDancers"] = OriginalDancers;
                    }
                }

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
            if (e.CommandName == "ShowDancer") //מעבר לתצוגת משתמש
            {
                Session["SelectedUser"] = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label23")).Text;
                Session["from"] = "ShowDancers.aspx";
                 Response.Redirect("ShowUser.aspx");
            }

            if (e.CommandName == "EditUser") // עריכת דף משתמש
            {
                Session["from"] = "ShowDancers.aspx";
                Session["SelectedUser"] = UserService.FindUserById((DataTable)Session["Dancers"], ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label23")).Text);
                Response.Redirect("UpdatePersonalData.aspx");
            }

            if (e.CommandName == "AddDancer") // הוספת משתמש להופעה
            {
                DancesDancers dancersInDance = (DancesDancers)Session["dancersInDance"];
                bool found = false;
                foreach (string s in dancersInDance.dancers)
                    if (s == ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label23")).Text)
                        found = true;
                if(!found) dancersInDance.Add(((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label23")).Text);
                else ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This dancer is in the dance already.\");", true);
                GridView1.DataSource = dancersInDance.TurnToDT((DataTable)Session["Dancers"]);
                GridView1.DataBind();
            }
            if (e.CommandName == "Block") // חסימת משתמש
            {
                if (MessageBox.Show("Are you sure you want to block this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string UserId = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label23")).Text;
                    UserService.BlockUser(UserId, true); //חסימה במסד הנתונים

                    DataTable dancers = (DataTable)Session["Dancers"]; // מחיקה מהטבלה
                    foreach (DataRow r in dancers.Rows)
                        if (r["UserId"].ToString() == ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label23")).Text)
                            r.Delete();
                    dancers.AcceptChanges();

                    foreach (DataRow row in ((DataTable)Session["Users"]).Rows) //שינוי בטבלה
                        if (row["UserId"].ToString() == UserId)
                            row["IsBlocked"] = true;
                    ((DataTable)Session["Users"]).AcceptChanges();

                    Session["Dancers"] = dancers;
                    Button6_Click(null, null);

                    EmailService.SendEmail("You are blocked", "You are blocked", UserService.GetEmail((DataTable)Session["Users"], UserId));//שליחת אימייל
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowDancer1")
            {
                DancesDancers dancersInDance = (DancesDancers)Session["dancersInDance"];
                Object index = e.CommandArgument;
                Session["SelectedUser"] = dancersInDance.dancers[Convert.ToInt32(index)];
                Session["from"] = "ShowDancers.aspx";
                 Response.Redirect("ShowUser.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DancesDancers dancersInDance = (DancesDancers)Session["dancersInDance"]; // מחיקת רקדן 
            dancersInDance.Remove(dancersInDance.dancers[Convert.ToInt32(e.RowIndex)].ToString(), DanceService.FindDanceId(Session["DanceName"].ToString()));
            Session["dancersInDance"] = dancersInDance;
            GridView1.DataSource = dancersInDance.TurnToDT(((DataTable)Session["Dancers"]));
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e) // סינונים
        {
            Label24.Text = "";

            DataTable dancers = (DataTable)Session["Dancers"];
            DataTable filteredDancers1 = new DataTable();
            DataTable filteredDancers2 = new DataTable();
            DataTable filteredDancers3 = new DataTable();
            foreach (DataColumn c in dancers.Columns)
            {
                filteredDancers1.Columns.Add(c.ColumnName);
                filteredDancers2.Columns.Add(c.ColumnName);
                filteredDancers3.Columns.Add(c.ColumnName);
            }

            if (TextBox1.Text == "" && TextBox2.Text == "" && DropDownList1.SelectedValue == "All" && DropDownList2.SelectedValue == "All")
            {
                DataList1.DataSource = dancers;
                DataList1.DataBind();
            }
            else
            {
                if (TextBox1.Text == "" && TextBox2.Text == "") filteredDancers1 = dancers;
                if (TextBox1.Text != "" && TextBox2.Text != "") filteredDancers1 = DbManagement.GetTableByQuery("SELECT Users.UserCategory, Users.UserId, Users.UserFirstName, Users.UserLastName, Users.UserBirthDate, Users.UserPhoneNumber, Users.ProfilePicture, Users.UserEmail, Fix((Date()-[UserBirthDate])/365) AS Expr1 FROM Users WHERE Users.IsBlocked=NO and (((Users.UserCategory)=2) AND ((Fix((Date()-[UserBirthDate])/365))>=" + TextBox1.Text + ")) and (((Fix((Date()-[UserBirthDate])/365))<=" + TextBox2.Text + "));");
                if (TextBox1.Text != "" && TextBox2.Text == "") filteredDancers1 = DbManagement.GetTableByQuery("SELECT Users.UserCategory, Users.UserId, Users.UserFirstName, Users.UserLastName, Users.UserBirthDate, Users.UserPhoneNumber, Users.ProfilePicture, Users.UserEmail, Fix((Date()-[UserBirthDate])/365) AS Expr1 FROM Users WHERE Users.IsBlocked=NO and (((Users.UserCategory)=2) AND ((Fix((Date()-[UserBirthDate])/365))>=" + TextBox1.Text + "));");
                if (TextBox1.Text == "" && TextBox2.Text != "") filteredDancers1 = DbManagement.GetTableByQuery("SELECT Users.UserCategory, Users.UserId, Users.UserFirstName, Users.UserLastName, Users.UserBirthDate, Users.UserPhoneNumber, Users.ProfilePicture, Users.UserEmail, Fix((Date()-[UserBirthDate])/365) AS Expr1 FROM Users WHERE Users.IsBlocked=NO and (((Users.UserCategory)=2) AND (((Fix((Date()-[UserBirthDate])/365))<=" + TextBox2.Text + ")));");

                if (DropDownList1.SelectedValue != "All")
                {
                    int DanceIndex = DropDownList1.SelectedIndex-1;
                    DataTable dancersId = DbManagement.GetTableByQuery("SELECT Dances.DanceName, DancesDancers.DanceId, DancesDancers.DancerId FROM Dances INNER JOIN DancesDancers ON Dances.DanceId = DancesDancers.DanceId WHERE (((Dances.DanceName)=\""+DropDownList1.SelectedValue.ToString()+"\"));");
                    foreach (DataRow row in filteredDancers1.Rows)
                        foreach (DataRow row1 in dancersId.Rows)
                            if (row["UserId"].ToString() == row1["DancerId"].ToString())
                                filteredDancers2.ImportRow(row);
                }
                else filteredDancers2=filteredDancers1;
                    
                if (DropDownList2.SelectedValue != "All")
                {
                    DataTable dt1 = DbManagement.GetTableByQuery("SELECT DancesDancers.DancerId, Performances.PerformanceName FROM Performances INNER JOIN ((Dances INNER JOIN DancesDancers ON Dances.DanceId = DancesDancers.DanceId) INNER JOIN PerformancesDances ON Dances.DanceId = PerformancesDances.DanceId) ON Performances.PerformanceId = PerformancesDances.PerformanceId GROUP BY DancesDancers.DancerId, Performances.PerformanceName HAVING (((Performances.PerformanceName)=\""+DropDownList2.SelectedValue.ToString()+"\"));");
                    foreach (DataRow row in filteredDancers2.Rows)
                        foreach (DataRow row1 in dt1.Rows)
                            if (row["UserId"].ToString() == row1["DancerId"].ToString())
                                filteredDancers3.ImportRow(row);
                }
                else filteredDancers3=filteredDancers2;

                DataList1.DataSource = filteredDancers3;
                DataList1.DataBind();

                if (filteredDancers3.Rows.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No dancers found.\");", true);//הודעה אם לא נמצא רקדן
                else Label24.Text = "";
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((Label)(e.Item.FindControl("Label2"))).Text.Length > 10)//שינוי אורך של שם ריקוד
                    ((Label)(e.Item.FindControl("Label2"))).Text = ((Label)(e.Item.FindControl("Label2"))).Text.Substring(0, 10) + "...";
                if (((Label)(e.Item.FindControl("Label15"))).Text.Length> 10)//שינוי אורך של שם ריקוד
                    ((Label)(e.Item.FindControl("Label15"))).Text = ((Label)(e.Item.FindControl("Label15"))).Text.Substring(0, 10) + "...";

                if (Session["from"] != null)  //הצגת כפתור ההוספה לריקוד רק אם הגיעו לדף מדף הוספת ריקוד
                {
                    if (Session["from"].ToString() == "AddDance.aspx")
                    {
                        e.Item.FindControl("ImageButton7").Visible = true;
                        ImageButton8.Visible = true;
                    }
                    if (Session["from"].ToString() == "EditDance.aspx")
                    {
                        e.Item.FindControl("ImageButton7").Visible = true;
                        ImageButton8.Visible = true;
                        ImageButton9.Visible = true;
                    }
                }

                if (((User)Session["User"]).IsAdmin) e.Item.FindControl("ImageButton6").Visible = true;

                if(((User)Session["User"]).UserId.ToString()==((Label)(e.Item.FindControl("Label23"))).Text) e.Item.FindControl("ImageButton5").Visible = true;

            }
        }

        protected void Button8_Click(object sender, EventArgs e) // חיפוש ריקוד
        {
            Label24.Text = "";

            if (TextBox3.Text != "")
            {
                DataTable dt = (DataTable)Session["Dancers"];
                DataTable dancer = new DataTable();
                foreach (DataColumn c in dt.Columns)
                    dancer.Columns.Add(c.ColumnName);
                foreach (DataRow r in dt.Rows)
                    if (r["UserFirstName"].ToString() + " " + r["UserLastName"].ToString() == TextBox3.Text && r["IsBlocked"].ToString() == "False")
                        dancer.ImportRow(r);
                DataList1.DataSource = dancer;
                DataList1.DataBind();
                if (dancer.Rows.Count <= 0) Label24.Text = "User not found";
                else Label24.Text = "";
            }
            else
            {
                Button6_Click(null, null);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["from"].ToString() != "ShowDancers.aspx")
            {
                if (((GridView)sender).Rows.Count > 0) // שינוי הגודל של הפאנל אם יש רקדנים בגריד
                {
                    Panel1.Width = 810;
                    DataList1.RepeatColumns = 4;
                    Panel2.Visible = true;
                }
            }
            else Panel2.Visible = false;

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור לעמוד הבית
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

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],DanceService.FindDanceId(Session["DanceName"].ToString())).ChoreographerId, "Your dance was edited! Dance name: " + TextBox2.Text); // הודעה לכראוגרף של הריקוד
            EmailService.SendEmail("Your dance was edited! Dance name: " + TextBox2.Text, "Your dance was edited!", UserService.GetEmail((DataTable)Session["Users"], DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],DanceService.FindDanceId(Session["DanceName"].ToString())).ChoreographerId));

            Dance d = DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceService.FindDanceId(Session["DanceName"].ToString()));
            DancesDancers dancersInDance = (DancesDancers)Session["dancersInDance"];

            if (dancersInDance.dancers.Count > 0)
            {
                DataTable OriginalDancers = (DataTable)Session["OriginalDancers"];

                dancersInDance.AddToDB(DanceService.FindDanceId(Session["DanceName"].ToString())); // הוספת הרקדנים לריקוד

                string DanceType = null, DanceTypeName=null; // קביעת סוג הריקוד לפי מספר הרקדנים
                int NumOfDancers = dancersInDance.dancers.Count;
                if (NumOfDancers != 0)
                {
                    if (NumOfDancers == 1) 
                    {
                        DanceType = "1";
                        DanceTypeName="Solo";
                    }
                    if (NumOfDancers == 2) 
                    {
                        DanceType = "2";
                        DanceTypeName="Duet";
                    }
                    if (NumOfDancers == 3) 
                    {
                        DanceType = "3";
                        DanceTypeName="Trio";
                    }
                    if (NumOfDancers > 3 && NumOfDancers < 8) 
                    {
                        DanceType = "4";
                        DanceTypeName="Small group";
                    }
                    if (NumOfDancers > 8) 
                    {
                        DanceType = "5";
                        DanceTypeName="Large group";
                    }
                    DanceService.AddDanceType(d.DanceId, DanceType); // הוספת סוג הריקוד למסד הנתונים

                    foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows) //הוספת סוג הריקוד לטבלה
                        if (row["DanceId"].ToString() == d.DanceId)
                        {
                            row["DanTypeCatId"] = DanceType;
                            row["DanceType"] = DanceTypeName;
                        }
                }

                User u = null; // הודעות לרקדנים שהוסיפו אותם לריקוד
                bool found = false;
                foreach (string s in dancersInDance.dancers)
                {
                    found = false;
                    foreach (DataRow row in OriginalDancers.Rows) if (row["DancerId"].ToString() == s) found = true;
                    if (!found)
                    {
                        u = UserService.FindUserById(DbManagement.GetTable("Users"), s);
                        EmailService.SendEmail("You were added to a new dance! Dance name: " + d.DanceName + ". Check website for more information", "A new dance!", u.UserEmail);
                        NotificationService.AddNotification(u.UserId, "You were added to a new dance! Dance name: " + d.DanceName + ".");
                    }
                }

                foreach (DataRow row in OriginalDancers.Rows) // הודעות לרקדנים שמחקו אותם מהריקוד
                {
                    found = false;
                    foreach (string s in dancersInDance.dancers) if (row["DancerId"].ToString() == s) found = true;
                    if (!found)
                    {
                        u = UserService.FindUserById(DbManagement.GetTable("Users"), row["DancerId"].ToString());
                        EmailService.SendEmail("You were deleted from a dance! Dance name: " + d.DanceName + ". Check website for more information", "A new dance!", u.UserEmail);
                        NotificationService.AddNotification(row["DancerId"].ToString(), "You were deleted from a dance! Dance name: " + d.DanceName + ".");
                    }
                }

                Session["DancesDancers"] = DbManagement.GetTableByQuery("SELECT DancesDancers.DanceId, DancesDancers.DancerId, Dances.DanceName, Dances.DancePhoto, Dances.IsValid FROM DanceTypesCategories INNER JOIN (DanceStyleCategories INNER JOIN (Dances INNER JOIN DancesDancers ON Dances.DanceId = DancesDancers.DanceId) ON DanceStyleCategories.CategoryId = Dances.DanStyleCatId) ON DanceTypesCategories.CategoryId = Dances.DanTypeCatId;");
                if (MessageBox.Show("You have added dancers succesfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Session["SelectedDance"] = DanceService.FindDanceId(Session["DanceName"].ToString());
                    Response.Redirect("ShowDance.aspx"); // מעבר לדף ריקוד
                }
            }
            else ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"You have to add atleat one dancer.\");", true);
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e) // עריכת ריקוד
        {
            Response.Redirect("EditDance.aspx");
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e) // התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }

        protected void Button8_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox3.Text != "")
            {
                DataTable user = new DataTable();
                foreach (DataColumn c in ((DataTable)Session["Dancers"]).Columns) user.Columns.Add(c.ColumnName);
                foreach (DataRow r in ((DataTable)Session["Dancers"]).Rows)
                    if (r["UserFirstName"].ToString() + " " + r["UserLastName"].ToString() == TextBox3.Text)
                        user.ImportRow(r);

                if (user.Rows.Count > 0)
                {
                    DataList1.DataSource = user;
                    DataList1.DataBind();
                }
                else ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This dancer was not found.\");", true);//הודעה אם לא נמצא רקדן
            }
        }

        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (((System.Web.UI.WebControls.Menu)sender).SelectedItem.Text == "Dancers")
            {
                Session["from"] = "ShowDancers.aspx";
                Response.Redirect("ShowDancers.aspx");
            }
        }
    }
}