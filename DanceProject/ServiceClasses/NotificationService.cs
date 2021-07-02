using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DanceProject.ServiceClasses
{
    public class NotificationService
    {
        public static void Watched(string UserId, string NotificationId) // שינוי התראה לנצפתה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Notifications SET Watched=Yes Where UserId=\"" + UserId + "\" and NotificationId=" + NotificationId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void AddNotification(string UserId, string NotificationContent) // הוספת התראה חדשה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO Notifications(UserId, NotificationContent, NotificationDate, Watched) VALUES(@UserId, @NotificationContent,Now(),No)", Conn);
                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@NotificationContent", NotificationContent);
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); } 
        }

        public static void DeleteNotification(string NotificationId) // מחיקת התראה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Notifications WHERE NotificationId=" + NotificationId, Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }
    }
}