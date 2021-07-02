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
    public partial class Catrgories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt1=null, dt2=new DataTable();
            foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Columns) dt2.Columns.Add(c.ColumnName);
            
            if (DropDownList1.SelectedValue == "Dance style") dt1=((DataSet)Session["Dances"]).Tables["DanceStyleCategories"];//טבלה לפי הקטגוריה שנבחרה
            if (DropDownList1.SelectedValue == "Dance types") dt1=((DataSet)Session["Dances"]).Tables["DanceTypesCategories"];
            
            if (DropDownList2.SelectedValue == "Valid Categories") //הקטגוריות שמאושרות
            {
                foreach (DataRow r in dt1.Rows)
                    if (r["IsValid"].ToString() == "True")
                        dt2.ImportRow(r);
                GridView1.Columns[1].HeaderText = "Delete Category";
            }
            else // הקטגוריות שמבוטלות
            {
                foreach (DataRow r in dt1.Rows)
                    if (r["IsValid"].ToString() == "False")
                        dt2.ImportRow(r);
                GridView1.Columns[1].HeaderText = "Valid";
            }
            
            GridView1.DataSource = dt2;
            GridView1.DataBind();

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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page_Load(sender, e); // כשמשנים את הערך הנבחר העמוד נטען מחדש
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string CatName = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;  // שם הקטגוריה
                DataTable dt = ((DataSet)Session["Dances"]).Tables["Dances"];
                if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (DropDownList2.SelectedValue == "Valid Categories")
                    {
                        if (DropDownList1.SelectedValue == "Dance style")
                        {
                            bool found = false; // חיפוש האם הסגנון שנבחר נמצא בריקוד כלשהוא
                            foreach (DataRow r in dt.Rows) if (r["DanceStyle"].ToString() == CatName) found = true;

                            if (found) // אם הוא נמצא לא מוחקים אותו
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(\"You can't delete this category since it has already been used. The category is invalid.\")", true);
                                CategoryService.InvalidCategory(CatName, "DanceStyleCategories", false);
                                ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Rows[Convert.ToInt32(e.CommandArgument)]["IsValid"] = false;
                            }
                            else
                            {
                                CategoryService.DeleteCategory(CatName, "DanceStyleCategories"); // אם הוא לא נמצא מוחקים אותו
                                foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Rows)
                                    if (r["CategoryName"].ToString() == CatName)
                                        r.Delete();
                                dt.AcceptChanges();
                            }
                        }
                        else
                        {
                            bool found = false; // חיפוש האם סוג הריקוד נמצא בריקוד כלשהוא
                            foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                                if (r["DanceType"].ToString() == CatName)
                                    found = true;

                            if (found) // אם הוא נמצא לא מוחקים אותו
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(\"You can't delete this category since it has already been used. The category is invalid.\")", true);
                                CategoryService.InvalidCategory(CatName, "DanceTypesCategories", false);
                                ((DataSet)Session["Dances"]).Tables["DanceTypesCategories"].Rows[Convert.ToInt32(e.CommandArgument)]["IsValid"] = false;
                            }
                            else CategoryService.DeleteCategory(CatName, "DanceTypesCategories"); // אם הוא לא נמצא מוחקים אותו
                            foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["DanceTypesCategories"].Rows)
                                if (r["CategoryName"].ToString() == CatName) r.Delete();
                            dt.AcceptChanges();
                        }

                    }
                    else
                    {
                        if (DropDownList1.SelectedValue == "Dance style")
                        {
                            CategoryService.InvalidCategory(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, "DanceStyleCategories", true);
                            ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Rows[Convert.ToInt32(e.CommandArgument)]["IsValid"] = true;
                        }
                        else
                        {
                            CategoryService.InvalidCategory(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, "DanceTypesCategories", true);
                            ((DataSet)Session["Dances"]).Tables["DanceTypesCategories"].Rows[Convert.ToInt32(e.CommandArgument)]["IsValid"] = true;
                        }
                    }

                    Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים
                    Page_Load(null, null);
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // כפתור לעמוד הבית
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e) // כפתור התראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e) // כפתור דף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (DropDownList1.SelectedValue == "Dance style") // הוספת סגנון ריקוד
            {
                if (CategoryService.FindCategory(TextBox1.Text, ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"])) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This category already exists.\");", true); // הודעה אם הקטגוריה כבר נמצאת
                else
                {
                    GridView1.DataSource=CategoryService.InsertCategory(TextBox1.Text, "DanceStyleCategories"); // הוספת הקטגוריה אם היא לא נמצאת
                    GridView1.DataBind();
                }
            }
            if (DropDownList1.SelectedValue == "Dance types") // הוספת סוג ריקוד
            {
                if (CategoryService.FindCategory(TextBox1.Text, ((DataSet)Session["Dances"]).Tables["DanceTypesCategories"])) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert(\"This category already exists.\");", true);// הודעה אם הקטגוריה כבר נמצאת
                else
                {
                    GridView1.DataSource = CategoryService.InsertCategory(TextBox1.Text, "DanceTypesCategories"); // הוספת הקטגוריה אם היא לא נמצאת
                    GridView1.DataBind();
                }
            }
            Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים
            
            TextBox1.Text = "";
            Page_Load(sender, e);
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e) // התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }
    }
}