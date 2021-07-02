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

namespace DanceProject
{
    public partial class ShowDancesDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User u = (User)Session["User"];

                DataTable dances = new DataTable();
                foreach(DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dances.Columns.Add(c.ColumnName);
                if (u.UserCategory == "1") //אם המשתמש הוא כראוגרף מציגים את הריקודים שלו
                {
                    foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                        if (row["ChoreographerId"].ToString() == u.UserId && row["IsValid"].ToString()=="True")
                            dances.ImportRow(row);
                }
                else // אם המשתמש הוא רקדן מציגים את הריקודים שלו
                {
                    foreach(DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                        if(r["DancerId"].ToString()==u.UserId)
                            foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                                if(r["DanceId"].ToString()==row["DanceId"].ToString())
                                if (row["IsValid"].ToString() == "True")
                                    dances.ImportRow(row);
                    
                    Label24.Visible = false;
                    CheckBoxList3.Visible = false;
                    GridView1.Columns[4].Visible = false;
                } 

                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Rows) // הצגת הקטגוריות בצ'ק בוקס וdropdownlist
                    if(row["IsValid"].ToString()=="True")
                        CheckBoxList1.Items.Add(row["CategoryName"].ToString());
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["DanceTypesCategories"].Rows)
                    if (row["IsValid"].ToString() == "True")
                    CheckBoxList2.Items.Add(row["CategoryName"].ToString());
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Users"].Rows)
                    if ((int)row["UserCategory"] == 1 && row["IsBlocked"].ToString()=="False")
                        DropDownList1.Items.Add(row["UserFirstName"].ToString() + " " + row["UserLastName"].ToString());
                foreach (DataRow row in ((DataTable)Session["Performances"]).Rows)
                    DropDownList3.Items.Add(row["PerformanceName"].ToString());
                
                DataTable dancers = new DataTable(); // הצגת הרקדנים בdropdownlist
                if (Session["Dancers"] != null) dancers = (DataTable)Session["Dancers"];
                else
                {
                    DataTable users = (DataTable)Session["Users"];
                    foreach (DataColumn c in users.Columns) dancers.Columns.Add(c.ColumnName);
                    foreach (DataRow r in users.Rows)
                        if (int.Parse(r["UserCategory"].ToString()) == 2 && r["IsBlocked"].ToString() == "False")
                            dancers.ImportRow(r);                
                    Session["Dancers"]=dancers;
                }
                foreach (DataRow row in dancers.Rows)
                    DropDownList4.Items.Add(row["UserFirstName"].ToString()+" "+row["UserLastName"].ToString());

                dances = DanceService.RemoveDoubles(dances);
                Session["DisplayedDances"] = dances; 
                DataList1.DataSource = dances;
                DataList1.DataBind();
                if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No dances found.\");", true);
                
                if (Session["DancesInPerformance"] != null)
                {
                    PerformancesDances dancesInPerformance = (PerformancesDances)Session["DancesInPerformance"];
                    DataTable original= DbManagement.GetTableByQuery("Select DanceId from PerformancesDances where PerformanceId=" + Session["PerformanceName"].ToString());
                    ArrayList arr=new ArrayList();
                    foreach(DataRow r in original.Rows) arr.Add(r["DanceId"].ToString());
                    PerformancesDances OriginalDances=new PerformancesDances();
                    OriginalDances.dances=arr;
                    Session["OriginalDances"] = OriginalDances;
                    GridView1.DataSource = dancesInPerformance.TurnToDT(DbManagement.GetTable("Dances"));
                    GridView1.DataBind();
                }

                if (Session["from"] != null)
                {
                    if (Session["from"].ToString() == "AddPerformance.aspx" || Session["from"].ToString() == "EditPerformance.aspx")
                    {
                        Button12.Visible = false;
                        ImageButton11.Visible = true;
                    }
                    if (Session["from"].ToString() == "EditPerformance.aspx") ImageButton12.Visible = true;
                }

                if (u.IsAdmin) // תפריט לאדמין
                {
                    Menu1.Visible = true;
                    Menu2.Visible = false;
                    Menu3.Visible = false;

                    Button12.Visible = true;
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

                if (u.UserCategory == "1")
                {
                    Label21.Visible = false;
                    DropDownList1.Visible = false;
                }

                Hi.Text = "Hi, " + u.UserFirstName + " " + u.UserLastName + "!";
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Valid") // החזרת ריקוד להיות valid
            {
                if (MessageBox.Show("Are you sure you want to revalidate this dance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DanceService.DanceNotValid(((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text, true);
                    bool flag = false;
                    for (int i = 0; i < ((DataTable)Session["DisplayedDances"]).Rows.Count && !flag; i++)//מחיקה מDataTable
                    {
                        DataRow dr = ((DataTable)Session["DisplayedDances"]).Rows[i];
                        if (dr["DanceId"].ToString() == ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text)
                        {
                            dr.Delete();
                            flag = true;
                        }
                    }
                    ((DataTable)Session["DisplayedDances"]).AcceptChanges();
                    DataList1.DataSource = (DataTable)Session["DisplayedDances"];
                    DataList1.DataBind();

                    Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים
                }
            }

            if (e.CommandName == "Like") // לייק לריקוד
            {
                if(((ImageButton)DataList1.Items[e.Item.ItemIndex].FindControl("ImageButton3")).ImageUrl == "/Photos/EmptyLike.png")
                {
                    ((ImageButton)DataList1.Items[e.Item.ItemIndex].FindControl("ImageButton3")).ImageUrl = "/Photos/FullLike.png";
                    DanceService.LikeDance(((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text, ((User)Session["User"]).UserId);
                }
                else
                {
                    ((ImageButton)DataList1.Items[e.Item.ItemIndex].FindControl("ImageButton3")).ImageUrl = "/Photos/EmptyLike.png";
                    DanceService.UnlikeDance(((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text, ((User)Session["User"]).UserId);
                    Button11_Click(null, null);
                }
            }
            if (e.CommandName == "ShowDances") // תצוגת ריקוד
            {
                Session["SelectedDance"] = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text;
                Session["from"] = "ShowDances.aspx";
                Response.Redirect("ShowDance.aspx");
            }
            if (e.CommandName == "Delete") // מחיקת ריקוד
            {
                if (MessageBox.Show("Are you sure you want to delete this dance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string DanceId = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text;

                    if (!DanceService.IsInPerformance(DanceId, (DataTable)Session["PerformancesDances"])) // אם הריקוד לא בתוך הופעה מוחקים אותו
                    {
                        NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],DanceId).ChoreographerId, "Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!"); //הודעה לכראוגרף
                        EmailService.SendEmail("Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!", "Your dance was deleted", UserService.GetEmail(DbManagement.GetTable("Users"), DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],DanceId).ChoreographerId));

                        DataTable dancersInDance = new DataTable(); // הודעה לכל הרקדנים בריקוד שהריקוד נמחק
                        foreach (DataColumn c in ((DataTable)Session["DancesDancers"]).Columns) dancersInDance.Columns.Add(c.ColumnName);
                        foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                            if (r["DanceId"].ToString() == DanceId)
                                dancersInDance.ImportRow(r);
                        foreach (DataRow row in dancersInDance.Rows)
                        {
                            NotificationService.AddNotification(row[1].ToString(), "The dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" you were in was deleted!"); //הודעה לרקדן
                            EmailService.SendEmail("Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" was deleted!", "Your dance was deleted", UserService.GetEmail(DbManagement.GetTable("Users"), DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId));
                        }

                        if ((DataTable)Session["DisplayedDances"] != null)
                        {
                            bool flag = false;
                            for (int i = 0; i < ((DataTable)Session["DisplayedDances"]).Rows.Count && !flag; i++)//מחיקה מDataTable
                            {
                                DataRow dr = ((DataTable)Session["DisplayedDances"]).Rows[i];
                                if (dr["DanceId"].ToString() == DanceId)
                                {
                                    dr.Delete();
                                    flag = true;
                                }
                            }
                            ((DataTable)Session["DisplayedDances"]).AcceptChanges();

                            string filePath = Server.MapPath(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).DancePhoto.ToString());
                            if (File.Exists(filePath) && DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).DancePhoto.ToString()!="/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת הריקוד מהתיקייה

                            DanceService.DeleteDance(DanceId);//מחיקה ממסד נתונים
                            DataList1.DataSource = (DataTable)Session["DisplayedDances"];
                            DataList1.DataBind();

                            foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows) // מחיקה מטבלת ריקודים
                                if (row["DanceId"].ToString() == DanceId)
                                    row.Delete();
                            ((DataSet)Session["Dances"]).Tables["Dances"].AcceptChanges();
                        }
                    }
                    else // אם הריקוד בתוך הופעה אי אפשר למחוק אותו
                    {
                        NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId, "Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" is not valid!"); //הודעה לכראוגרף
                        EmailService.SendEmail("Your dance \"" + DanceService.FindDance(DbManagement.GetTable("Dances"), DanceId).DanceName + "\" is not valid!", "Your dance is not valid!", UserService.GetEmail(DbManagement.GetTable("Users"), DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], DanceId).ChoreographerId));

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"You can't delete this dance since it has been used already. From now on it will be invalid.\");", true);
                        DanceService.DanceNotValid(DanceId, false);

                        bool flag = false;
                        for (int i = 0; i < ((DataTable)Session["DisplayedDances"]).Rows.Count && !flag; i++)//מחיקה מDataTable
                        {
                            DataRow dr = ((DataTable)Session["DisplayedDances"]).Rows[i];
                            if (dr["DanceId"].ToString() == DanceId)
                            {
                                dr.Delete();
                                flag = true;
                            }
                        }
                        ((DataTable)Session["DisplayedDances"]).AcceptChanges();
                        DataList1.DataSource = (DataTable)Session["DisplayedDances"];
                        DataList1.DataBind();

                        foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows) //שינוי בטבלת ריקודים
                            if (row["DanceId"].ToString() == DanceId)
                                row["IsValid"] = false;
                    }
                }
                //Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים
            }

            if (e.CommandName == "EditDance") // עריכת ריקוד
            { 
                    Session["SelectedDance"] = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text;
                    Session["from"] = "ShowDances.aspx";
                    Response.Redirect("EditDance.aspx");
            }

            if (e.CommandName == "AddDance") // הוספת ריקוד להופעה
            {
                bool found=false;
                string DanceId=((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label17")).Text;
                PerformancesDances dancesInPerformance = (PerformancesDances)Session["dancesInPerformance"];
                for (int i = 0; i < dancesInPerformance.GetLength(); i++)
                    if (dancesInPerformance.dances[i].ToString() == DanceId)
                        found = true;
                if (!found) dancesInPerformance.Add(DanceId);
                else ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This dance is already in the performance.\");", true);
                GridView1.DataSource = dancesInPerformance.TurnToDT(DbManagement.GetTable("Dances"));
                GridView1.DataBind();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckBoxList1.SelectedIndex == -1 && CheckBoxList2.SelectedIndex == -1 && TextBox1.Text == "" && TextBox2.Text == "" && CheckBoxList3.SelectedIndex == -1 && TextBox4.Text == "" && TextBox5.Text == "" && DropDownList1.SelectedValue == "All" && DropDownList3.SelectedValue == "All" && DropDownList4.SelectedValue == "All")
            {
                DataList1.DataSource = (DataTable)Session["DisplayedDances"];
                DataList1.DataBind();
            }
            else
            {
                DataTable dances = (DataTable)Session["DisplayedDances"];
                DataTable filteredDances = new DataTable();

                ArrayList SelectedValues1 = new ArrayList(); //סגנונות הריקוד שרוצים לסנן לפיהם
                if (CheckBoxList1.SelectedIndex != -1)
                    foreach (ListItem item in CheckBoxList1.Items)
                        if (item.Selected) SelectedValues1.Add(item.Text);
                ArrayList SelectedValues2 = new ArrayList(); // סוגי הריקוד שרוצים לסנן לפיהם
                if (CheckBoxList2.SelectedIndex != -1)
                    foreach (ListItem item in CheckBoxList2.Items)
                        if (item.Selected) SelectedValues2.Add(item.Text);

                string ChoreographerName = null; // כראוגרף שרוצים לסנן לפיו
                if (DropDownList1.SelectedValue != "All") ChoreographerName = DropDownList1.SelectedValue;
                ArrayList SelectedValues3 = new ArrayList();
                if (ChoreographerName != null) SelectedValues3.Add(ChoreographerName);

                filteredDances = DbManagement.FilterByCategory(dances, SelectedValues1, "DanceStyle"); // סינון סגנונות ריקוד
                filteredDances = DbManagement.FilterByCategory(filteredDances, SelectedValues2, "DanceType"); // סינון סוגי ריקוד
                filteredDances = DbManagement.FilterByCategory(filteredDances, SelectedValues3, "ChoreographerName"); // סינון כראוגרף

                double from, to; // סינון לפי אורך ריקוד
                if (TextBox1.Text != "") from = Double.Parse(TextBox1.Text);
                else from = -1;
                if (TextBox2.Text != "") to = Double.Parse(TextBox2.Text);
                else to = -1;
                filteredDances = DbManagement.FilterByLength(filteredDances, from, to);

                filteredDances = DbManagement.FilterByDate(filteredDances, TextBox4.Text, TextBox5.Text); // סינון לפי תאריך יצירה

                if (DropDownList3.SelectedValue != "All") // סינון לפי הופעה
                    filteredDances = DbManagement.FilterByPerformance(filteredDances, DropDownList3.SelectedValue.ToString());

                User u = (User)Session["User"];
                    if (CheckBoxList3.SelectedIndex!=-1)// סינון לפי סגנון ריקוד מועדף - רק לכראוגרפים
                        filteredDances = DbManagement.FilterByFavoriteStyles(filteredDances, DanceService.GetDancesInFavoriteStyles(DbManagement.GetTableByQuery("SELECT Top 1 Dances.ChoreographerId, Count(Dances.DanceId) AS CountOfDanceId, Dances.DanStyleCatId FROM Dances GROUP BY Dances.ChoreographerId, Dances.DanStyleCatId HAVING (((Dances.ChoreographerId)=\"" + u.UserId + "\")) ORDER BY Count(Dances.DanceId) DESC;")));

                DataTable NewFilteredDances=new DataTable();
                foreach(DataColumn c in filteredDances.Columns)
                    NewFilteredDances.Columns.Add(c.ColumnName);
                int DancerIndex = -1; // רקדן שרוצים לסנן לפיו
                if (DropDownList4.SelectedValue != "All")
                {
                    DancerIndex = DropDownList4.SelectedIndex-1;
                    DataTable DancerDances = DbManagement.GetTableByQuery("Select * from DancesDancers where DancerId=\"" + ((DataTable)Session["Dancers"]).Rows[DancerIndex]["UserId"] + "\"");
                    foreach (DataRow r1 in filteredDances.Rows)
                        foreach (DataRow r2 in DancerDances.Rows)
                            if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                                NewFilteredDances.ImportRow(r1);
                }
                else NewFilteredDances = filteredDances;
                DataList1.DataSource = NewFilteredDances;
                DataList1.DataBind();

                if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No dances found.\");", true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            decimal sum = 0; //פוטר לאורך הופעה
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

            if (Session["from"] != null)
                if (Session["from"].ToString() == "AddPerformance.aspx" || Session["from"].ToString() == "EditPerformance.aspx")
                    if (((GridView)sender).Rows.Count > 0) //שינוי גודל הפאנל של הריקודים אם יש ריקודים בהופעה
                        Panel1.Visible = true;  
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowDance1") // תצוגת ריקוד
            {
                string danceName = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                Session["SelectedDance"] = DanceService.FindDanceId(danceName);
                Session["from"] = "ShowDances.aspx";
                Response.Redirect("ShowDance.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) // מחיקת ריקוד מהופעה
        {
            PerformancesDances dancesInPerformance = (PerformancesDances)Session["dancesInPerformance"];
            dancesInPerformance.Remove(DanceService.FindDanceId(GridView1.Rows[e.RowIndex].Cells[0].Text));

            GridView1.DataSource = dancesInPerformance.TurnToDT(((DataSet)Session["Dances"]).Tables["Dances"]);
            GridView1.DataBind();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Label21.Visible = true;
            DropDownList1.Visible = true;

            DataTable dances = new DataTable();
            foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dances.Columns.Add(c.ColumnName);
            foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                if (r["IsValid"].ToString() == "True") dances.ImportRow(r);
            Session["DisplayedDances"] = dances;
            DataList1.DataSource = dances;
            DataList1.DataBind();
            Button3_Click(null, null);

            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).ImageUrl = "/Photos/DeleteIcon.png";
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).CommandName = "Delete";
            }

            if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No dances found.\");", true);

            Button9.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.White;
            Button12.BackColor = System.Drawing.Color.White;

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            User u = (User)Session["User"];

            if (u.UserCategory == "1")
            {
                Label21.Visible = false;
                DropDownList1.Visible = false;
            }

            DataTable dances = new DataTable();
            foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dances.Columns.Add(c.ColumnName);
            if (u.UserCategory == "1") //אם המשתמש הוא כראוגרף מציגים את הריקודים שלו
            {
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                    if (row["ChoreographerId"].ToString() == u.UserId && row["IsValid"].ToString() == "True")
                        dances.ImportRow(row);
            }
            else // אם המשתמש הוא רקדן מציגים את הריקודים שלו
            {
                foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                    if (r["DancerId"].ToString() == u.UserId)
                        foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                            if (r["DanceId"].ToString() == row["DanceId"].ToString())
                                if (row["IsValid"].ToString() == "True")
                                    dances.ImportRow(row);
            }
            dances = DanceService.RemoveDoubles(dances);
            DataList1.DataSource = dances;
            DataList1.DataBind();
            Session["DisplayedDances"] = dances;

            Button3_Click(null, null);

            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).ImageUrl = "/Photos/DeleteIcon.png";
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).CommandName = "Delete";
            }
            if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No dances found.\");", true);

            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button11.BackColor = System.Drawing.Color.White;
            Button12.BackColor = System.Drawing.Color.White;
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((Label)(e.Item.FindControl("Label1"))).Text.Length > 10)//שינוי אורך של שם ריקוד
                    ((Label)(e.Item.FindControl("Label1"))).Text = ((Label)(e.Item.FindControl("Label1"))).Text.Substring(0, 10) + "...";

                if (Session["from"] != null)  //הצגת כפתור ההוספה להופעה רק אם הגיעו לדף מדף הוספת הופעה
                    if (Session["from"].ToString() == "AddPerformance.aspx" || Session["from"].ToString() == "EditPerformance.aspx")
                    {
                        e.Item.FindControl("ImageButton10").Visible = true;
                        Label12.Visible = true;
                        ImageButton11.Visible = true;
                        Panel4.Width = 820;
                        DataList1.RepeatColumns = 4;
                    }

                User u = (User)Session["User"];
                if (DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],((Label)e.Item.FindControl("Label17")).Text).ChoreographerId == u.UserId || u.IsAdmin) // רק הכראוגרף של הריקוד או אדמין יכול למחוק ולערוך ריקוד
                {
                    e.Item.FindControl("ImageButton8").Visible = true;
                    e.Item.FindControl("ImageButton9").Visible = true;
                }  

                DataTable LikedDances = DbManagement.GetTableByQuery("Select * from LikedDances where UserId=\"" + u.UserId + "\""); //סימון לייקים
                foreach (DataRow row in LikedDances.Rows)
                    if (row["DanceId"].ToString() == ((Label)e.Item.FindControl("Label17")).Text)
                        ((ImageButton)e.Item.FindControl("ImageButton3")).ImageUrl = "/Photos/FullLike.png";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            TextBox4.Text = "";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            TextBox5.Text = "";
        }

        protected void Button11_Click(object sender, EventArgs e) // ריקודים שאהבתי
        {
            Label21.Visible = true;
            DropDownList1.Visible = true;

            User u = (User)Session["User"];
            DataTable LikedDances = DbManagement.GetTableByQuery("SELECT LikedDances.UserId, LikedDances.DanceId, Dances.DanceName, Dances.DancePhoto, Dances.CreationDate, DanceStyleCategories.CategoryName as DanceStyle, DanceTypesCategories.CategoryName as DanceType, Dances.IsValid FROM DanceTypesCategories INNER JOIN (DanceStyleCategories INNER JOIN (Dances INNER JOIN LikedDances ON Dances.DanceId = LikedDances.DanceId) ON DanceStyleCategories.CategoryId = Dances.DanStyleCatId) ON DanceTypesCategories.CategoryId = Dances.DanTypeCatId WHERE Dances.IsValid=Yes and (((LikedDances.UserId)=\"" + ((User)Session["User"]).UserId + "\"));");
            DataList1.DataSource = LikedDances;
            DataList1.DataBind();
            Button3_Click(null, null); // לפי הסינונים הקיימים
            Session["DisplayedDances"] = LikedDances;

            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).ImageUrl = "/Photos/DeleteIcon.png";
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).CommandName = "Delete";
            }

            if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No dances found.\");", true);

            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button12.BackColor = System.Drawing.Color.White;
        }

        protected void Button12_Click(object sender, EventArgs e) // ריקודים שאינם תקפים
        {
            Label21.Visible = true;
            DropDownList1.Visible = true;

            DataTable InvalidDances = new DataTable();
            foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) InvalidDances.Columns.Add(c.ColumnName);
            foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                if (r["IsValid"].ToString() == "False")
                    InvalidDances.ImportRow(r);
            DataList1.DataSource = InvalidDances;
            DataList1.DataBind();
            Session["DisplayedDances"] = InvalidDances;

            Button3_Click(null, null);

            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).ImageUrl = "/Photos/TickIcon.png";
                ((ImageButton)DataList1.Items[i].FindControl("ImageButton9")).CommandName = "Valid";
            }

            if (DataList1.Items.Count <= 0) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"No dances found.\");", true);

            Button9.BackColor = System.Drawing.Color.White;
            Button10.BackColor = System.Drawing.Color.White;
            Button11.BackColor = System.Drawing.Color.White;
            Button12.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e) //כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox3.Text != "")
            {
                DataTable dance = new DataTable();
                foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dance.Columns.Add(c.ColumnName);
                foreach (DataRow r in ((DataTable)Session["DisplayedDances"]).Rows)
                    if (r["DanceName"].ToString() == TextBox3.Text)
                        dance.ImportRow(r);

                if (dance.Rows.Count > 0)
                {
                    DataList1.DataSource = dance;
                    DataList1.DataBind();
                    Session["DisplayedDances"] = dance;
                }
                else ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This dance was not found.\");", true);//הודעה אם לא נמצא ריקוד
            }
        }

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            PerformancesDances dancesInPerformance = (PerformancesDances)Session["dancesInPerformance"]; //הריקודים שנמצאים בהופעה כרגע
            PerformancesDances Original = (PerformancesDances)Session["OriginalDances"]; // הריקודים שהיו בהופעה לפני העריכה
            PerformancesDances newDances=new PerformancesDances(); // הריקודים החדשים
            PerformancesDances deleted=new PerformancesDances(); // הריקודים שנמחקו

            bool found=false; // מציאת הריקודים החדשים
            foreach (string s1 in dancesInPerformance.dances)
            {
                found = false;
                foreach (string s2 in Original.dances)
                    if (s1 == s2) found = true;
                if (!found) newDances.Add(s1);
            }

            foreach (string s2 in Original.dances) // מציאת הריקודים שנמחקו
            {
                found = false;
                foreach (string s1 in dancesInPerformance.dances)
                    if (s1 == s2) found = true;
                if (!found) deleted.Add(s2);
            }

            if (dancesInPerformance.dances.Count > 0)
            {
                dancesInPerformance.AddToDB(Session["PerformanceName"].ToString());
                deleted.DeleteFromDB(Session["PerformanceName"].ToString());

                ArrayList newChoreographers = newDances.ChoreographersList(((User)Session["User"]).UserId, ((DataSet)Session["Dances"]).Tables["Dances"]);
                ArrayList newDancers = newDances.DancersList();
                ArrayList deletedChoreographers = deleted.ChoreographersList(((User)Session["User"]).UserId, ((DataSet)Session["Dances"]).Tables["Dances"]);
                ArrayList deletedDancers = deleted.DancersList();

                if (Session["from"].ToString() == "AddPerformance.aspx" || Session["from"].ToString() == "EditPerformance.aspx")//שליחת הודעה לכראוגרפים שהוסיפו ריקוד שלהם להופעה חדשה
                {
                    foreach (string choreographer in newChoreographers)
                    {
                        NotificationService.AddNotification(choreographer, "Your dance was added to a performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName);
                        EmailService.SendEmail("A new performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A new performance!", UserService.GetEmail(DbManagement.GetTable("Users"), choreographer));
                    }
                    foreach (string dancer in newDancers)
                    {
                        NotificationService.AddNotification(dancer, "A new performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " DancerId: " + dancer);
                        EmailService.SendEmail("A new performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName + " DancerId: " + dancer, "A new performance!", UserService.GetEmail(DbManagement.GetTable("Users"), dancer));
                    }

                    foreach (string choreographer in deletedChoreographers)
                    {
                        NotificationService.AddNotification(choreographer, "Your dance was deleted from a performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName);
                        EmailService.SendEmail("Your dance was deleted from a performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "Your dance was deleted from a performance!", UserService.GetEmail(DbManagement.GetTable("Users"), choreographer));
                    }

                    foreach (string dancer in deletedDancers)
                    {
                        NotificationService.AddNotification(dancer, "A dance you were at was deleted from a performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName);
                        EmailService.SendEmail("A dance you were at was deleted from a performance! Performance name: " + PerformanceService.FindPerformance(Session["PerformanceName"].ToString(), (DataTable)Session["Performances"]).PerformanceName, "A dance you were at was deleted from a performance!", UserService.GetEmail(DbManagement.GetTable("Users"), dancer));
                    }
                }

                PerformanceService.UpdateLength(Session["PerformanceName"].ToString(), Convert.ToDecimal(((Label)GridView1.FooterRow.Cells[2].FindControl("Label13")).Text)); // עדכון אורך ההופעה במסד הנתונים
                foreach(DataRow row in ((DataTable)Session["Performances"]).Rows)
                    if(row["PerformanceId"].ToString()==Session["PerformanceName"].ToString())
                        row["PerformanceLength"]=Convert.ToDecimal(((Label)GridView1.FooterRow.Cells[2].FindControl("Label13")).Text);

                Session["SelectedPerformance"] = Session["PerformanceName"].ToString();
                Session["PerformancesDances"] = DbManagement.GetTableByQuery("SELECT PerformancesDances.DanceId, PerformancesDances.PerformanceId, Performances.PerformanceName, Performances.PerformanceLength, Performances.PerformancePhoto, Performances.CreationDate, Performances.IsConfirmed, Performances.ChoreographerId FROM Performances INNER JOIN PerformancesDances ON Performances.PerformanceId = PerformancesDances.PerformanceId;");
                
                if (MessageBox.Show("You have added dances succesfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    Response.Redirect("ShowPerformance.aspx");
            }
            else ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"You have to add atleat one dance.\");", true);

        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e) //ביטול הוספת ריקודים
        {
            Response.Redirect("EditPerformance.aspx");
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)//התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e) // כפתור התראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e) // כפתור בית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (((System.Web.UI.WebControls.Menu)sender).SelectedItem.Text == "Show dances")
            {
                Session["from"] = "ShowDances.aspx";
                Response.Redirect("ShowDances.aspx");
            }
        }
    }
}