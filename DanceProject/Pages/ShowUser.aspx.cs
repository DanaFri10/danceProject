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
    public partial class ShowUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User u=UserService.FindUserById((DataTable)Session["Users"], Session["SelectedUser"].ToString());

                if (u.UserId==((User)Session["User"]).UserId.ToString()) ImageButton4.Visible = true; // אם המשתמש הוא המשתמש שנכנס לאתר הוא יוכל לערוך פרטים
                else
                    if (((User)Session["User"]).IsAdmin) ImageButton5.Visible = true; // אם הוא אדמין הוא יוכל לחסום את המשתמש

                Image1.ImageUrl = u.ProfilePicture;// תצוגת פרטים
                Label2.Text = u.UserId;
                Label4.Text = u.UserFirstName + " " + u.UserLastName;
                Label6.Text = u.UserBirthDate;
                Label8.Text = u.UserPhoneNumber;
                Label10.Text = u.UserEmail;
                Label16.Text = u.IsAdmin.ToString();
                Label17.Text = u.IsBlocked.ToString();

                DataTable dances = new DataTable();
                if (u.UserCategory.ToString() == "1")// אם המשתמש הוא כראוגרף
                {
                    Label13.Text = "Choreographer";                    
                    Label18.Visible = true;
                    Button9.Visible = true;

                    foreach (DataColumn c in ((DataSet)Session["Dances"]).Tables["Dances"].Columns) dances.Columns.Add(c.ColumnName);//תצוגת ריקודים של הכראוגרף
                    foreach (DataRow r in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                        if (r["ChoreographerId"].ToString() == u.UserId) 
                            dances.ImportRow(r);
                    GridView1.DataSource = dances;

                    //GridView2.DataSource = DbManagement.GetTableByQuery("SELECT Performances.PerformanceId,Performances.PerformanceName, Performances.PerformancePhoto, Dances.ChoreographerId FROM Performances INNER JOIN (Dances INNER JOIN PerformancesDances ON Dances.DanceId = PerformancesDances.DanceId) ON Performances.PerformanceId = PerformancesDances.PerformanceId GROUP BY Performances.PerformanceId,Performances.PerformanceName, Performances.PerformancePhoto, Dances.ChoreographerId HAVING (((Dances.ChoreographerId)=\"" + u.UserId + "\"));");

                    DataTable Performances = new DataTable();//תצוגת הופעות של הכראוגרף
                    foreach (DataColumn c in ((DataTable)Session["Performances"]).Columns) Performances.Columns.Add(c.ColumnName);
                    foreach (DataRow r in ((DataTable)Session["Performances"]).Rows)
                        if (r["ChoreographerId"].ToString() == u.UserId)
                            Performances.ImportRow(r);
                    GridView3.DataSource = Performances;
                    GridView3.DataBind();
                }
                else // אם המשתמש הוא רקדן
                {
                    Label13.Text = "Dancer";

                    foreach (DataColumn c in ((DataTable)Session["DancesDancers"]).Columns) dances.Columns.Add(c.ColumnName);//תצוגת ריקודים של הרקדן
                    foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                        if (r["DancerId"].ToString() == u.UserId)
                            dances.ImportRow(r);
                    GridView1.DataSource = dances;
                }

                GridView1.DataBind();                    
                
                DataTable PerformancesOfDances = new DataTable();//ההופעות שבהן יש לרקדן/לכראוגרף ריקוד
                    foreach (DataColumn c in ((DataTable)Session["PerformancesDances"]).Columns) PerformancesOfDances.Columns.Add(c.ColumnName);
                    foreach (DataRow r1 in dances.Rows)
                        foreach (DataRow r2 in ((DataTable)Session["PerformancesDances"]).Rows)
                            if (r1["DanceId"].ToString() == r2["DanceId"].ToString())
                                PerformancesOfDances.ImportRow(r2);
                    PerformancesOfDances = PerformanceService.RemoveDoubles(PerformancesOfDances);
                    GridView2.DataSource = PerformancesOfDances;
                GridView2.DataBind();

                if((DataTable)GridView1.DataSource !=null) if (((DataTable)GridView1.DataSource).Rows.Count <= 0) Label15.Text = "This user has no dances";
                if ((DataTable)GridView2.DataSource != null) if (((DataTable)GridView2.DataSource).Rows.Count <= 0) Label14.Text = "This user has no performances";
                if ((DataTable)GridView3.DataSource != null)  if (((DataTable)GridView3.DataSource).Rows.Count <= 0) Label19.Text = "This user has no performances";

                if (((User)Session["User"]).IsAdmin) // תפריט לאדמין
                {
                    Menu1.Visible = true;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                }
                else
                {
                    if (((User)Session["User"]).UserCategory.ToString() == "1") //תפריט לכראוגרף
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowDance") // תצוגת ריקוד
            {
                string danceName = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                Session["SelectedDance"] = DanceService.FindDanceId(danceName);
                Session["from"] = "ShowUser.aspx";
                Response.Redirect("ShowDance.aspx");
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPerformance") // תצוגת הופעה
            {
                string performanceName = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                Session["SelectedPerformance"] = PerformanceService.FindPerformanceId(performanceName);
                Session["from"] = "ShowUser.aspx";
                Response.Redirect("ShowPerformance.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e) // תצוגת פרטים
        {
            Button6.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;

            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;

        }

        protected void Button7_Click(object sender, EventArgs e) // תצוגת ריקודים
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.White;

            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
        }

        protected void Button8_Click(object sender, EventArgs e) // תצוגת הופעות שבהן למשתמש יש ריקוד
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button9.BackColor = System.Drawing.Color.White;

            Panel2.Visible =false; 
            Panel3.Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
        }

        protected void Button9_Click(object sender, EventArgs e) // תצוגת הופעות של הכראוגרף
        {
            Button6.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;
            Button9.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

            Panel2.Visible =false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//כפתור לדף בית
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)// כפתור להתראות
        {
            Response.Redirect("Notifications.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)// כפתור לדף פרופיל אישי
        {
            Session["SelectedUser"] = ((User)Session["User"]).UserId.ToString();
            Response.Redirect("ShowUser.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)// התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)//עריכת פרטים אישיים
        {
            Response.Redirect("UpdatePersonalData.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)//חסימת משתמש
        {
            if (MessageBox.Show("Are you sure you want to block this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                UserService.BlockUser(Label2.Text, true);
                if (Label13.Text == "Choreographer") Response.Redirect("ShowChoreographers.aspx"); // אם המשתמש שנחסם הוא כראוגרף מעבר לתצוגת כראוגרפים
                else Response.Redirect("ShowDancers.aspx"); // אם המשתמש שנחסם הוא רקדן מעבר לתצוגת רקדנים
            }
        }

    }
}