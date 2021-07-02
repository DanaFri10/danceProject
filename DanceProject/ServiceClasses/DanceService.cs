using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using DanceProject.TypeClasses;
using System.Collections;
using System.Web.UI;
using System.Windows.Forms;

namespace DanceProject.ServiceClasses
{
    public class DanceService
    {
        public static Dance FindDance(DataTable dt, string DanceId) // מציאת הריקוד לפי הקוד שלו
        {
            Dance d = new Dance();
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["DanceId"].ToString() == DanceId)
                {
                    d = new Dance();
                    d.DanceId = dr["DanceId"].ToString();
                    d.DanceName = dr["DanceName"].ToString();
                    d.DanStyleCatId = dr["DanStyleCatId"].ToString();
                    d.DanTypeCatId = dr["DanTypeCatId"].ToString();
                    d.ChoreographerId = dr["ChoreographerId"].ToString();
                    d.DanceLength = Convert.ToDecimal(dr["DanceLength"]);
                    d.DanceSong = dr["DanceSong"].ToString();
                    d.DancePhoto = dr["DancePhoto"].ToString();
                    d.DanceVideo = dr["DanceVideo"].ToString();
                    d.CreationDate = dr["CreationDate"].ToString();
                }
            }
            return d;
        }

        public static string FindDanceId(string DanceName) // מציאת קוד הריקוד לפי שמו
        {
            DataTable dt = DbManagement.GetTable("Dances");
            foreach (DataRow dr in dt.Rows)
                if (dr["DanceName"].ToString() == DanceName) return dr["DanceId"].ToString();
            return null;
        }

        public static void AddDance(string DanceName, string DanStyleCatId, string DanTypeCatId, string ChoreographerId, string DanceLength, string DanceSong, string DanceVideo, string DancePhoto) // הוספת ריקוד חדש
        {                
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO Dances(DanceName, DanStyleCatId, DanTypeCatId, ChoreographerId, DanceLength, DanceSong, DanceVideo, DancePhoto, CreationDate, IsValid) VALUES(@DanceName, @DanStyleCatId,@DanTypeCatId,@ChoreographerId, @DanceLength, @DanceSong, @DanceVideo, @DancePhoto, Date(), true)", Conn);
                command.Parameters.AddWithValue("@DanceName", DanceName);
                command.Parameters.AddWithValue("@DanStyleCatId", DanStyleCatId);
                command.Parameters.AddWithValue("@DanTypeCatId", DanTypeCatId);
                command.Parameters.AddWithValue("@ChoreographerId", ChoreographerId);
                command.Parameters.AddWithValue("@DanceLength", DanceLength);
                command.Parameters.AddWithValue("@DanceSong", DanceSong);
                command.Parameters.AddWithValue("@DanceVideo", DanceVideo);
                command.Parameters.AddWithValue("@DancePhoto", DancePhoto);

                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }        
        
        public static void DeleteDance(string DanceId) // מחיקת ריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Dances WHERE DanceId=" + DanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            finally { Conn.Close(); }
        }

        public static void AddDanceType(string DanceId, string DanTypeCatId) // הוספת סוג הריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Dances SET DanTypeCatId=" + DanTypeCatId + " WHERE DanceId=" + DanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void LikeDance(string DanceId, string UserId) // הוספת לייק לריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("Insert into LikedDances(DanceId,UserId) Values(@DanceId, @UserId)", Conn);
                command.Parameters.AddWithValue("@DanceId", DanceId);
                command.Parameters.AddWithValue("@UserId", UserId);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void UnlikeDance(string DanceId, string UserId) // מחיקת לייק מריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("Delete from LikedDances where DanceId=" + DanceId + " and UserId=\"" + UserId + "\"", Conn);
                command.Parameters.AddWithValue("@DanceId", DanceId);
                command.Parameters.AddWithValue("@UserId", UserId);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static DataSet GetDancesWithConn(DataTable x) // שליפת הריקודים כולל קשרי גומלין
        {
            DataSet ds = new DataSet();
            DataTable Dances=new DataTable(); // טבלת ריקודים
            if (x != null)
            {
                if (x.Rows.Count > 0) Dances = x;
                else Dances = DbManagement.GetTable("Dances");
            }
            else Dances = DbManagement.GetTable("Dances");
            
            DataTable Users = DbManagement.GetTable("Users"); // טבלת משתמשים
            DataTable DanceStyleCategories = DbManagement.GetTable("DanceStyleCategories"); // טבלת סגנונות ריקודים
            DataTable DanceTypesCategories = DbManagement.GetTable("DanceTypesCategories"); // טבלת סוגי ריקודים
            
            ds.Tables.Add(Dances); // הוספת הטבלאות לדאטה סט
            ds.Tables.Add(Users);
            ds.Tables.Add(DanceStyleCategories);
            ds.Tables.Add(DanceTypesCategories);

            ds.Tables["Users"].PrimaryKey = new DataColumn[] { ds.Tables["Users"].Columns["UserId"] }; // קביעת המפתחות הראשיים של הטבלאות
            ds.Tables["Dances"].PrimaryKey = new DataColumn[] { ds.Tables["Dances"].Columns["DanceId"] };
            ds.Tables["DanceStyleCategories"].PrimaryKey = new DataColumn[] { ds.Tables["DanceStyleCategories"].Columns["CategoryId"] };
            ds.Tables["DanceTypesCategories"].PrimaryKey = new DataColumn[] { ds.Tables["DanceTypesCategories"].Columns["CategoryId"] };

            DataRelation dr1 = new DataRelation("DanceChoreographers", ds.Tables["Users"].Columns["UserId"], ds.Tables["Dances"].Columns["ChoreographerId"]); // קשר גומלין בין טבלת ריקודים ומשתמשים
            DataRelation dr2 = new DataRelation("DanceStyles", ds.Tables["DanceStyleCategories"].Columns["CategoryId"], ds.Tables["Dances"].Columns["DanStyleCatId"]); // קשר גומלין בין טבלת סגנונות וריקודים
            DataRelation dr3 = new DataRelation("DanceTypes", ds.Tables["DanceTypesCategories"].Columns["CategoryId"], ds.Tables["Dances"].Columns["DanTypeCatId"]); // קשר גומלין בין טבלת סוגים וריקודים
            ds.Relations.Add(dr1); // הוספת קשרי הגומלין לדאטה סט
            ds.Relations.Add(dr2);
            ds.Relations.Add(dr3);

            ds.Tables["Dances"].Columns.Add("DanceStyle");
            ds.Tables["Dances"].Columns.Add("DanceType");
            ds.Tables["Dances"].Columns.Add("ChoreographerName");
            DataRow p;
            foreach (DataRow row in ds.Tables["Dances"].Rows)
            {
                p = row.GetParentRow("DanceStyles");
                row["DanceStyle"] = p["CategoryName"];
                p = row.GetParentRow("DanceChoreographers");
                row["ChoreographerName"] = p["UserFirstName"].ToString() + " " + p["UserLastName"].ToString();
                p = row.GetParentRow("DanceTypes");
                row["DanceType"] = p["CategoryName"].ToString();       
            }
            return ds;
        }

        public static void Update(string DanceId, string DanStyleCatId, string DanTypeCatId, string DanceLength, string DanceSong) // שינוי פרטי ריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Dances SET DanStyleCatId=" + DanStyleCatId + ", DanTypeCatId=" + DanTypeCatId + " ,DanceLength=" + DanceLength + " ,DanceSong=\"" + DanceSong + "\" WHERE DanceId=" + DanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void UpdateVideo(string DanceId, string DanceVideo) // עדכון סרטון הריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Dances SET DanceVideo=\"" + DanceVideo + "\" WHERE DanceId=" + DanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void UpdateNameAndPic(string DanceId, string DanceName, string DancePhoto) // עדכון שם ותמונת הריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Dances SET DanceName=\"" + DanceName + "\", DancePhoto=\"" + DancePhoto + "\" WHERE DanceId=" + DanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void ConfirmDance(string DanceId, bool IsConfirmed) // אישור הריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Dances SET IsConfirmed=" + IsConfirmed + " WHERE DanceId=" + DanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void DanceNotValid(string DanceId, bool IsValid) // הפיכת ריקוד לתקף או לא תקף
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Dances SET IsValid=" + IsValid + " WHERE DanceId=" + DanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static DataTable GetDancesInFavoriteStyles(DataTable FavoriteStyles) //מציאת הריקודים בסגנונות האהובים על הכראוגרף
        {
            DataTable dances = DbManagement.GetTable("Dances");
            DataTable FavoriteStylesDances = new DataTable();

            foreach (DataColumn c in dances.Columns) // העתקת השדות מטבלת ריקודים לטבלת ריקודים אהובים
                FavoriteStylesDances.Columns.Add(c.ColumnName.ToString());

            int DancesCount = 0; // העתקת הריקודים בסגנונות האהובים, מקסימום חמישה ריקודים
            foreach (DataRow r in FavoriteStyles.Rows)
                foreach (DataRow r1 in dances.Rows)
                    if (r[2].ToString() == r1[2].ToString() && r1["IsValid"].ToString() == "True" && DancesCount<5)
                    {
                        FavoriteStylesDances.ImportRow(r1);
                        DancesCount++;
                    }
            return FavoriteStylesDances;
        }

        public static void AddComment(string UserId, string DanceId, string CommentContent) // הוספת תגובה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO DanceComments(UserId, DanceId, CommentDate, CommentContent) VALUES(@UserId, @DanceId,Now(), @CommentContent)", Conn);
                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@DanceId", DanceId);
                command.Parameters.AddWithValue("@CommentContent", CommentContent);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }
        
        public static void DeleteComment(string CommentId) // מחיקת תגובה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM DanceComments WHERE CommentId=" + CommentId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static bool IsInPerformance(string DanceId, DataTable tbl)
        {
            foreach (DataRow r in tbl.Rows)
                if (r["DanceId"].ToString() == DanceId) return true;
            return false;
        }

        public static DataTable RemoveDoubles(DataTable Dances) //אם יש ריקודים שמופיעים יותר מפעם אחת הם יופיעו פעם אחת בלבד
        {
            DataTable dt = new DataTable();
            foreach (DataColumn c in Dances.Columns) dt.Columns.Add(c.ColumnName); // העתקת השדות מטבלת ריקודים לטבלה חדשה

            bool found = false;
            foreach (DataRow r1 in Dances.Rows)
            {
                found = false;
                foreach (DataRow r2 in dt.Rows)
                    if (r1["DanceId"].ToString() == r2["DanceId"].ToString()) found = true; // בדיקה אם ריקוד כלשהוא נמצא כבר
                if (!found) dt.ImportRow(r1); // אם הוא לא נמצא מוסיפים אותו
            }
            return dt;
        }
    }
}