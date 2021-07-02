












using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;

namespace WebService1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable GetTblByQuery(string query) // שליפת טבלה משירות הרשת לפי שאילתה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            DataTable dt = new DataTable("Dances");
            OleDbCommand command;
            OleDbDataAdapter adapter;
            Conn.Open();
            try
            {
                command = new OleDbCommand(query, Conn);
                adapter = new OleDbDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                Conn.Close();
            } 
            
        }

        [WebMethod]
        public void AddPerformance(string PerformanceName, string PerformancePhoto, string ChoreographerId) // הוספת הופעה לשירות הרשת
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
            catch { }
            finally { Conn.Close(); }
        }

        [WebMethod]
        public void DeleteDate(string PerformanceId, string PerformanceDate, string PerformanceHour) // מחיקת תאריך הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();
            
            try
            {
                OleDbCommand command = new OleDbCommand("Delete from PerformancesDates where PerformanceId=" + PerformanceId + " and PerformanceDate=#" + PerformanceDate + "# and PerformanceHour=#" + PerformanceHour + "#", Conn);
                command.ExecuteNonQuery();
            }
            catch { }
            finally { Conn.Close(); }
        }

        [WebMethod]
        public void AddPerformanceDate(string PerformanceId, string PerformanceDate, string PerformanceHour, string PerformancePlace) // הוספת תאריך הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO PerformancesDates(PerformanceId,PerformanceDate, PerformanceHour, PerformancePlace) VALUES(" + PerformanceId + ", #" + PerformanceDate + "#, #" + PerformanceHour + "# ,\"" + PerformancePlace + "\")", Conn);
                command.ExecuteNonQuery();
            }
            catch { }
            finally { Conn.Close(); }
        }

        [WebMethod]
        public void DeletePerformance(string PerformanceId) // מחיקת הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Performances WHERE PerformanceId=" + PerformanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { }
            finally { Conn.Close(); }
        }

        [WebMethod]
        public void Update(string PerformanceId, string PerformanceName, string PerformancePhoto) // עדכון הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Performances SET PerformanceName=\"" + PerformanceName + "\", PerformancePhoto=\"" + PerformancePhoto + "\"  WHERE PerformanceId=" + PerformanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { }
            finally { Conn.Close(); }
        }

        [WebMethod]
        public void UpdateLength(string PerformanceId, decimal PerformanceLength) // עדכון אורך הופעה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Performances SET PerformanceLength=" + PerformanceLength + " WHERE PerformanceId=" + PerformanceId, Conn);
                command.ExecuteNonQuery();
            }
            catch { }
            finally { Conn.Close(); }
        }
    }
}
