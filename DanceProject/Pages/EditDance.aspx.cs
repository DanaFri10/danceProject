using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DanceProject.TypeClasses;
using System.Data;
using DanceProject.ServiceClasses;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace DanceProject.Pages
{
    public partial class EditDance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Rows)//הצגת הקטגוריות ב dropdownlist
                    if (row["IsValid"].ToString() == "True")
                        DropDownList1.Items.Add(row["CategoryName"].ToString());


                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["Dances"].Rows)
                    if (row["DanceId"].ToString() == Session["SelectedDance"].ToString())
                    {
                        Image1.ImageUrl = row["DancePhoto"].ToString();
                        Label19.Text = row["DanceId"].ToString();
                        TextBox2.Text = row["DanceName"].ToString();
                        DropDownList1.SelectedValue = row["DanceStyle"].ToString();
                        Label21.Text = row["DanceType"].ToString();
                        TextBox5.Text = row["DanceLength"].ToString();
                        TextBox6.Text = row["DanceSong"].ToString();

                        string src = row["DanceVideo"].ToString();//תצוגת סרטון
                        src = src.Trim(new char[] { '#' });
                        //src="\"\""+src+"\"\"";
                        I1.Attributes["src"] = src;  
                    }

                if (Session["DancersInDan"] == null)
                {
                    DataTable DancersId = new DataTable(); // מציאת ת"ז של הרקדנים שבריקוד
                    foreach (DataColumn c in ((DataTable)Session["DancesDancers"]).Columns) DancersId.Columns.Add(c.ColumnName);
                    foreach (DataRow r in ((DataTable)Session["DancesDancers"]).Rows)
                        if (r["DanceId"].ToString() == Session["SelectedDance"].ToString())
                            DancersId.ImportRow(r);
                    DataTable DancersInDance = new DataTable(); // מציאת השמות של הרקדנים
                    foreach (DataColumn c in ((DataTable)Session["Users"]).Columns) DancersInDance.Columns.Add(c.ColumnName);
                    foreach (DataRow r1 in ((DataTable)Session["Users"]).Rows)
                        foreach (DataRow r2 in DancersId.Rows)
                            if (r2["DancerId"].ToString() == r1["UserId"].ToString()) DancersInDance.ImportRow(r1);
                    GridView1.DataSource = DancersInDance;
                    GridView1.DataBind();
                    Session["DancersInDan"] = DancersInDance;
                }
                else
                {
                    GridView1.DataSource = (DataTable)Session["DancersInDan"];//תצוגת רקדנים
                    GridView1.DataBind();
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



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Show")//תצוגת רקדן
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["SelectedUser"] = ((DataTable)Session["DancersInDan"]).Rows[index]["UserId"].ToString();
                Session["from"] = "ShowDance2.aspx";
                Response.Redirect("ShowUser.aspx");
            }
        }

        protected void Button11_Click(object sender, EventArgs e)// תצוגת פרטי ריקוד
        {
            Button11.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.White;

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        protected void Button7_Click1(object sender, EventArgs e)//תצוגת רקדנים
        {
            Button11.BackColor =System.Drawing.Color.White;
            Button7.BackColor =  System.Drawing.Color.FromArgb(230, 230, 230);
            Button8.BackColor = System.Drawing.Color.White;

            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
        }

        protected void Button8_Click(object sender, EventArgs e)//תצוגת ריקוד
        {
            Button11.BackColor = System.Drawing.Color.White;
            Button7.BackColor = System.Drawing.Color.White;
            Button8.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//כפתור עמוד בית
        {
            Response.Redirect("HomePage.aspx");
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

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)//עדכון תמונה ושם הופעה
        {
            string filename, filelocation = Image1.ImageUrl, fileName;
            try
            {
                if (FileUpload1.HasFile) 
                {
                    string filePath = Server.MapPath(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Label19.Text).DancePhoto.ToString());
                    if (File.Exists(filePath) && DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Label19.Text).DancePhoto.ToString() != "/Photos/NoDance.png") File.Delete(filePath); // מחיקת תמונת הריקוד מהתיקייה

                    filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    filename = filename.Substring(0, filename.Length - 4);
                    fileName = String.Format(@"{0}{1}.jpg", filename, DateTime.Now.Ticks);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("/Photos/" + fileName)); // שמירה בתיקיה
                    filelocation = "/Photos/" + fileName;

                    Image1.ImageUrl = filelocation;
                }
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            DanceService.UpdateNameAndPic(Label19.Text, TextBox2.Text, filelocation);
            Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים

            NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Label19.Text).ChoreographerId, "Your dance was edited! Dance name: " + TextBox2.Text); // הודעה לכראוגרף של הריקוד
            EmailService.SendEmail("Your dance was edited! Dance name: " + TextBox2.Text, "Your dance was edited!", UserService.GetEmail((DataTable)Session["Users"], DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Label19.Text).ChoreographerId));

            foreach (DataRow r in ((DataTable)Session["DancersInDan"]).Rows)
            {
                NotificationService.AddNotification(r["UserId"].ToString(), "A dance you are in was edited! Dance name: " + TextBox2.Text); // הודעה לרקדנים של הריקוד
                EmailService.SendEmail("A dance you are in was edited! Dance name: " + TextBox2.Text, "A dance you are in was edited!",UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)//ביטול העריכה
        {
            Response.Redirect("ShowDance.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)//עריכת רקדנים
        {
            Session["from"] = "AddDance.aspx";
            Session["DanceName"] = TextBox2.Text;
            DancesDancers dancersInDance = new DancesDancers();
            foreach (DataRow row in ((DataTable)Session["DancersInDan"]).Rows)
                dancersInDance.Add(row["UserId"].ToString());
            Session["DancersInDance"] = dancersInDance;
            Response.Redirect("ShowDancers.aspx");
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            if (DanceService.FindDanceId(TextBox2.Text) != null && DanceService.FindDanceId(TextBox2.Text) != Session["SelectedDance"].ToString()) ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(\"This dance already exists.\")", true);//הודעה אם הריקוד כבר קיים
            else
            {
                string style = null;// מציאת קוד הקטגוריה
                foreach (DataRow row in ((DataSet)Session["Dances"]).Tables["DanceStyleCategories"].Rows)
                    if (row["CategoryName"].ToString() == DropDownList1.SelectedValue)
                        style = row["CategoryId"].ToString();

    string Type="1"; // קביעת סוג הריקוד
    if (Label21.Text == "Solo") Type = "1";
    if (Label21.Text == "Duet") Type = "2";
    if (Label21.Text == "Trio") Type = "3";
    if (Label21.Text == "Small group") Type = "4";
    if (Label21.Text == "Large group") Type = "5";

                DanceService.Update(Session["SelectedDance"].ToString(), style, Type, TextBox5.Text, TextBox6.Text);//עדכון במסד הנתונים

                PerformancesDances dancesInPerformance = (PerformancesDances)Session["dancesInPerformance"];
                string choreographer = DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Session["SelectedDance"].ToString()).ChoreographerId;
                DataTable dancers = (DataTable)Session["DancersInDan"];

                NotificationService.AddNotification(choreographer, "Your dance was edited! Dance name: " + DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"],Session["SelectedDance"].ToString()).DanceName);
                EmailService.SendEmail("Your dance was edited! Dance name: " + DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Session["SelectedDance"].ToString()).DanceName, "Your dance was edited!", UserService.GetEmail(DbManagement.GetTable("Users"), choreographer));
                    foreach (DataRow row in dancers.Rows)
                    {
                        NotificationService.AddNotification(row["UserId"].ToString(), "A dance you were in was edited! Dance name: " + TextBox2.Text);
                        EmailService.SendEmail("A dance you were in was edited! Dance name: " + TextBox2.Text, "A dance you were in was eidted!", UserService.GetEmail(DbManagement.GetTable("Users"), row["UserId"].ToString()));
                    }

                    Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים
            }
        }

        protected void Button8_Click(object sender, ImageClickEventArgs e)//עדכון הסרטון
        {
            string video = "";
            if (TextBox7.Text != "")
            {
                try
                {
                    video = TextBox7.Text;
                    video = video.Remove(video.IndexOf("title") - 2);
                    video = video.Remove(0, video.IndexOf("http"));
                }
                catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else video = I1.Attributes["src"];

            DanceService.UpdateVideo(Label19.Text, video);

            Session["Dances"] = DanceService.GetDancesWithConn(null); // טבלת ריקודים

            NotificationService.AddNotification(DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Label19.Text).ChoreographerId, "Your dance was edited! Dance name: " + TextBox2.Text); // הודעה לכראוגרף של הריקוד
            EmailService.SendEmail("Your dance was edited! Dance name: " + TextBox2.Text, "Your dance was edited!", UserService.GetEmail((DataTable)Session["Users"], DanceService.FindDance(((DataSet)Session["Dances"]).Tables["Dances"], Label19.Text).ChoreographerId));

            foreach (DataRow r in ((DataTable)Session["DancersInDan"]).Rows)
            {
                NotificationService.AddNotification(r["UserId"].ToString(), "A dance you are in was edited! Dance name: " + TextBox2.Text); // הודעה לרקדנים של הריקוד
                EmailService.SendEmail("A dance you are in was edited! Dance name: " + TextBox2.Text, "A dance you are in was edited!", UserService.GetEmail((DataTable)Session["Users"], r["UserId"].ToString()));
            }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)//התנתקות מהאתר
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Session["User"] = null;
                Response.Redirect("Entrance.aspx");
            }
        }
    }
}