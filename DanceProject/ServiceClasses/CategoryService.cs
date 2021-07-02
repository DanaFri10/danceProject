using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DanceProject.ServiceClasses
{
    public class CategoryService
    {
        public static bool FindCategory(string Category, DataTable dt) // בדיקה האם הקטגוריה נמצאת בטבלה
        {
            foreach(DataRow r in dt.Rows)
                if (r["CategoryName"].ToString()==Category) 
                    return true;
            return false;
        }

        public static DataTable InsertCategory(string CategoryName,string tbl) // הכנסת קטגוריה חדשה לטבלת קטגוריות וקבלת הטבלה החדשה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();
            DataTable dt = new DataTable("Dances");

            try
            {
                OleDbCommand command1 = new OleDbCommand(("INSERT INTO " + tbl + "(CategoryName, IsValid) VALUES(@CategoryName, Yes)").ToString(), Conn);
                command1.Parameters.AddWithValue("@CategoryName", CategoryName);
                command1.ExecuteNonQuery();

                OleDbCommand command2 = new OleDbCommand("Select * from " + tbl, Conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command2);
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null; 
            }
            finally
            {
                Conn.Close();
            } 
        }

        public static void InvalidCategory(string CategoryName, string tbl, bool IsValid) // הפיכת הקטגוריה לתקפה או לא תקפה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("Update " + tbl + " set IsValid=" + IsValid + " where CategoryName=\"" + CategoryName + "\"", Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void DeleteCategory(string CategoryName, string tbl) // מחיקת קטגוריה מטבלה מסויימת
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("Delete from " + tbl + " where CategoryName=\"" + CategoryName + "\"", Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

    }
}