using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using DanceProject.TypeClasses;
using System.Windows.Forms;

namespace DanceProject.ServiceClasses
{
    public class PerformanceService
    {
        public static Performance FindPerformance(string PerformanceId, DataTable tbl) // מציאת הופעה לפי קוד ההופעה
        {
            Performance p=new Performance();
            foreach(DataRow r in tbl.Rows)
                if (r["PerformanceId"].ToString() == PerformanceId)
                {
                    p.PerformanceId = r["PerformanceId"].ToString();
                    p.PerformanceName = r["PerformanceName"].ToString();
                    p.PerformancePhoto = r["PerformancePhoto"].ToString();
                    //p.PerformanceDate = r["PerformanceDate"].ToString();
                    //p.PerformancePlace = r["PerformancePlace"].ToString();
                    p.PerformanceChoreographer = r["ChoreographerId"].ToString();
                    p.CreationDate = r["CreationDate"].ToString();
                    return p;
                }
            return null;     
        }

        

        public static DataTable RemoveDoubles(DataTable Performances) // הורדת כפילויות מטבלת הופעות
        {
            DataTable dt = new DataTable();
            foreach (DataColumn c in Performances.Columns) dt.Columns.Add(c.ColumnName);

            bool found = false;
            foreach (DataRow r1 in Performances.Rows)
            {
                found = false;
                foreach (DataRow r2 in dt.Rows)
                    if (r1["PerformanceId"].ToString() == r2["PerformanceId"].ToString()) found = true;
                if (!found) dt.ImportRow(r1);
            }
            return dt;
        }

        public static string FindPerformanceId(string PerformanceName) //מציאת קוד ההופעה לפי שם ההופעה
        {
            DataTable dt = DbManagement.GetTable("Performances");
            foreach (DataRow dr in dt.Rows)
                if (dr["PerformanceName"].ToString() == PerformanceName) return dr["PerformanceId"].ToString();
            return null;
        }

        public static void AddPerformance(string PerformanceName, string PerformancePhoto, string ChoreographerId) // הוספת הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO Performances(PerformanceName,PerformancePhoto, CreationDate, ChoreographerId) VALUES(@PerformanceName, @PerformancePhoto, Date(), @ChoreographerId)", Conn);
                command.Parameters.AddWithValue("@PerformanceName", PerformanceName);
                command.Parameters.AddWithValue("@PerformancePhoto", PerformancePhoto);
                command.Parameters.AddWithValue("@ChoreographerId", ChoreographerId);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void DeletePerformance(string PerformanceId) // מחיקת הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Performances WHERE PerformanceId=" + PerformanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void Update(string PerformanceId, string PerformanceName, string PerformancePhoto) // עדכון הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Performances SET PerformanceName=\"" + PerformanceName + "\", PerformancePhoto=\"" + PerformancePhoto + "\"  WHERE PerformanceId=" + PerformanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void UpdateLength(string PerformanceId, decimal PerformanceLength) // עדכון אורך ההופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();

            Conn.Open();

            OleDbCommand command = new OleDbCommand("UPDATE Performances SET PerformanceLength=" + PerformanceLength + " WHERE PerformanceId=" + PerformanceId, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static void ConfirmPerformance(string PerformanceId, bool IsConfirmed) // אישור הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Performances SET IsConfirmed=" + IsConfirmed + " WHERE PerformanceId=" + PerformanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void AddComment(string UserId, string PerformanceId, string CommentContent) // הוספת תגובה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO PerformanceComments(UserId, PerformanceId, CommentDate, CommentContent) VALUES(@UserId, @PerformanceId,Now(), @CommentContent)", Conn);
                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@PerformanceId", PerformanceId);
                command.Parameters.AddWithValue("@CommentContent", CommentContent);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void DeleteComment(string CommentId) // מחיקת תגובה מהופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM PerformanceComments WHERE CommentId=" + CommentId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }
        

    }
}