using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using DanceProject.ServiceClasses;
using System.Windows.Forms;

namespace DanceProject.TypeClasses
{
    public class PerformancesDances
    {
        public ArrayList dances; // רשימת הריקודים

        public PerformancesDances() // פעולה בונה
        {
            dances = new ArrayList();
        }

        public int GetLength() // החזרת מספר הריקודים בהופעה 
        {
            return dances.Count;
        }

        public void Add(string DanceId) // הוספת ריקוד לרשימה
        {
            dances.Add(DanceId);
        }

        public void Remove(string DanceId) // הסרת ריקוד מהרשימה
        {
            dances.Remove(DanceId);
        }

        public void AddToDB(string PerformanceId) // הוספת רשימת הריקודים להופעה במסד הנתונים
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command1;
                DataTable dt;
                foreach (string s in dances) // הוספת כל ריקוד להופעה
                {
                    dt = DbManagement.GetTableByQuery("Select * from PerformancesDances where PerformanceId=" + PerformanceId + " and DanceId=" + s); // בדיקה האם הריקוד כבר נמצא בהופעה

                    if (dt.Rows.Count <= 0)
                    {
                        command1 = new OleDbCommand("INSERT INTO PerformancesDances(PerformanceId, DanceId) Values(" + PerformanceId + "," + s + ")", Conn);
                        command1.ExecuteNonQuery();
                    }
                }
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public void DeleteFromDB(string PerformanceId) // מחיקת ריקוד מהופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command1;
                foreach (string s in dances)
                {
                    command1 = new OleDbCommand("Delete from PerformancesDances where PerformanceId=" + PerformanceId + " and DanceId=" + s, Conn);
                    command1.ExecuteNonQuery();
                }
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public DataTable TurnToDT(DataTable dt1) // הפיכת הרשימה לטבלה
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("DanceName");
            dt2.Columns.Add("DancePhoto");
            dt2.Columns.Add("DanceLength");

            foreach (string s in dances)
                foreach (DataRow row in dt1.Rows)
                    if (row["DanceId"].ToString() == s)
                        dt2.ImportRow(row);
            return dt2;
        }

        public ArrayList ChoreographersList(string ChoreographerId, DataTable tbl) // רשימת הכיראוגרפים בהופעה
        {
            bool found;
            ArrayList choreographers = new ArrayList();
            foreach (string s in dances)
            {
                found = false;
                foreach (string choreographer in choreographers)
                    if (DanceService.FindDance(tbl, s).ChoreographerId == choreographer) found = true;
                if (DanceService.FindDance(tbl, s).ChoreographerId == ChoreographerId) found = true;
                if (!found) choreographers.Add(DanceService.FindDance(tbl, s).ChoreographerId);
            }
            return choreographers;
        }

        public ArrayList DancersList() // רשימת הרקדנים בהופעה
        {
            bool found;
            ArrayList dancers1 = new ArrayList();
            DataTable dancers2;
            foreach (string s in dances)
            {
                dancers2 = DbManagement.GetTableByQuery("SELECT DancerId from DancesDancers where DanceId=" + s);
                foreach (DataRow row in dancers2.Rows)
                { 
                    found = false;
                    foreach (string s1 in dancers1)
                        if (s1.ToString()== row[0].ToString()) found = true;
                    if (!found) dancers1.Add(row[0]);
                }
            }
            return dancers1;
        }
    }
}