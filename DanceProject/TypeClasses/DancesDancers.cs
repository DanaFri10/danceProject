using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace DanceProject.TypeClasses
{
    public class DancesDancers
    {
        public ArrayList dancers; // רשימת הרקדנים

        public DancesDancers() // פעולה בונה
        {
            dancers = new ArrayList();
        }

        public void Add(string UserId) // הוספת רקדנים לרשימת הרקדנים
        {
            dancers.Add(UserId);
        }

        public void Remove(string UserId, string DanceId)
        {
            dancers.Remove(UserId); // הסרת הרקדן מרשימת הרקדנים

            OleDbConnection Conn = new OleDbConnection(); // הסרת הרקדן מהריקוד במסד הנתונים
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("Delete From DancesDancers WHERE DanceId=" + DanceId + " AND DancerId=\"" + UserId + "\"", Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public void AddToDB(string DanceId) // הוספת רשימת הרקדנים לריקוד
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command;
                DataTable dt;
                foreach (string s in dancers) // הוספת כל רקדן לריקוד
                {
                    dt = DbManagement.GetTableByQuery("Select * from DancesDancers where DanceId=" + DanceId + " and DancerId='" + s + "'"); // בדיקה אם הרקדן נמצא כבר בריקוד

                    if (dt.Rows.Count <= 0)
                    {
                        command = new OleDbCommand("INSERT INTO DancesDancers(DanceId, DancerId) Values(" + DanceId + "," + s + ")", Conn);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public DataTable TurnToDT(DataTable dt1) // הפיכת הרשימה לטבלה
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("UserFirstName");
            dt2.Columns.Add("UserLastName");
            dt2.Columns.Add("ProfilePicture");

            foreach (string s in dancers)
                foreach (DataRow row in dt1.Rows)
                    if (row["UserId"].ToString() == s)
                        dt2.ImportRow(row);
            return dt2;
        }
    }
}