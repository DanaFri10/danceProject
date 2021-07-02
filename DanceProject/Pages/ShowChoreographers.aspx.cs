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
using Button = System.Web.UI.WebControls.Button;

namespace DanceProject.Pages
{
    public partial class ShowChoreographers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable Choreographers = new DataTable();//הצגת הכראוגרפים
                foreach(DataColumn c in ((DataTable)Session["Users"]).Columns) Choreographers.Columns.Add(c.ColumnName);
                foreach (DataRow row in ((DataTable)Session["Users"]).Rows) if(row["UserCategory"].ToString()=="1" && row["IsBlocked"].ToString()=="False")
                        Choreographers.ImportRow(row);
                DataList1.DataSource = Choreographers;
                DataList1.DataBind();
                Session["Choreographers"] = Choreographers;

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
            if (e.CommandName == "ShowChoreographer") // תצוגת כראוגרף
            {
                Session["SelectedUser"] = ((DataTable)Session["Choreographers"]).Rows[e.Item.ItemIndex]["UserId"].ToString();
                Session["from"] = "ShowChoreographers.aspx";
                Response.Redirect("ShowUser.aspx");
            }
            if (e.CommandName == "Block")//חסימת כראוגרף
            {
                string UserId=((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label16")).Text;
                if ((UserService.FindUserById(((DataTable)Session["Users"]), UserId).IsAdmin)) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This user is an admin therefore you can't block him.\");", true);
                else
                {
                    if (MessageBox.Show("Are you sure you want to block this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        UserService.BlockUser(UserId, true); // חסימה במסד הנתונים
                        ((DataTable)Session["Choreographers"]).Rows[e.Item.ItemIndex].Delete();// מחיקה מטבלת כראוגרפים
                        ((DataTable)Session["Choreographers"]).AcceptChanges();
                        DataList1.DataSource = ((DataTable)Session["Choreographers"]);
                        DataList1.DataBind();

                        foreach (DataRow row in ((DataTable)Session["Users"]).Rows) //שינוי בטבלה
                            if (row["UserId"].ToString() == UserId)
                                row["IsBlocked"] = true;
                        ((DataTable)Session["Users"]).AcceptChanges();

                        //Session["Users"] = DbManagement.GetTable("Users"); // טבלת משתמשים
                    }
                }
            }

            if (e.CommandName == "Edit") // עריכת פרטים
            {
                Session["from"] = "ShowDancers.aspx";
                //Session["SelectedUser"] = UserService.FindUserById((DataTable)Session["Choreographers"], ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label23")).Text);
                Session["SelectedUser"] = ((DataTable)Session["Choreographers"]).Rows[e.Item.ItemIndex]["UserId"].ToString();
                Response.Redirect("UpdatePersonalData.aspx");
            }
        }


        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((User)Session["User"]).IsAdmin) e.Item.FindControl("ImageButton5").Visible = true;
                if (((User)Session["User"]).UserId.ToString() == ((Label)(e.Item.FindControl("Label16"))).Text) e.Item.FindControl("ImageButton7").Visible = true;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//עמוד בית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)//עמוד התראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)//דף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)//התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }
    }
}