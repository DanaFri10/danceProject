using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Collections;
using DanceProject.ServiceClasses;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DanceProject
{
    public static class DbManagement
    {
        public static DataTable GetTable(string tbl) // שליפת טבלה לפי שם הטבלה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            DataTable dt = new DataTable(tbl.ToString());
            OleDbCommand command;
            OleDbDataAdapter adapter;
            Conn.Open();
            try
            {
                command = new OleDbCommand(("SELECT * from " + tbl).ToString(), Conn);
                adapter = new OleDbDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }
            catch { 
                MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            finally { Conn.Close(); }
            
        }

        public static DataTable GetTableByQuery(string query) // שליפת טבלה לפי שאילתה
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            DataTable dt = new DataTable("Dances");
            OleDbCommand command;
            OleDbDataAdapter adapter;
            Conn.Open();
            try
            {
                command = new OleDbCommand(query.ToString(), Conn);
                adapter = new OleDbDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            finally { Conn.Close(); }
            
        }

        public static DataTable FilterByCategory(DataTable tbl, ArrayList SelectedValues, string category) // סינון לפי קטגוריה
        {
            if (SelectedValues.Count != 0)
            {
                DataTable dt = new DataTable();
                foreach (DataColumn column in tbl.Columns)
                    dt.Columns.Add(column.ColumnName.ToString());

                foreach (DataRow row in tbl.Rows)
                    foreach (string s in SelectedValues)
                        if (row[category].ToString() == s)
                            dt.ImportRow(row);
                return dt;
            }
            return tbl;
        }

        public static DataTable Top5(DataTable tbl) // חמש הרשומות העליונות בטבלה
        {
            DataTable dt = new DataTable();
            foreach (DataColumn c in tbl.Columns) dt.Columns.Add(c.ColumnName);

            for (int i = 0; i < 5; i++)
                dt.ImportRow(tbl.Rows[i]);
            return dt;
        }

        public static DataTable FilterByFavoriteStyles(DataTable tbl, DataTable dances)  // סינון לפי סגנונות אהובים
        {
                DataTable dt = new DataTable();
                foreach (DataColumn column in tbl.Columns)
                    dt.Columns.Add(column.ColumnName.ToString());

                foreach (DataRow row in tbl.Rows)
                    foreach (DataRow row1 in dances.Rows)
                        if (row["DanceId"].ToString() == row1["DanceId"].ToString())
                            dt.ImportRow(row);
                return dt;
        }

        public static DataTable FilterByDate(DataTable tbl, string from, string to) // סינון לפי תאריך
        {
            if (from != "" && to != "")
            {
                DataTable dt = new DataTable();
                foreach (DataColumn column in tbl.Columns)
                    dt.Columns.Add(column.ColumnName.ToString());

                foreach (DataRow row in tbl.Rows)
                    if (Convert.ToDateTime(row["CreationDate"]) >= Convert.ToDateTime(from) && Convert.ToDateTime(row["CreationDate"]) <= Convert.ToDateTime(to))
                        dt.ImportRow(row);
                return dt;
            }
            if (from !="" && to == "")
            {
                DataTable dt = new DataTable();
                foreach (DataColumn column in tbl.Columns)
                    dt.Columns.Add(column.ColumnName.ToString());

                foreach (DataRow row in tbl.Rows)
                    if (Convert.ToDateTime(row["CreationDate"]) >= Convert.ToDateTime(from))
                        dt.ImportRow(row);
                return dt;
            }
            if (from == "" && to != "")
            {
                DataTable dt = new DataTable();
                foreach (DataColumn column in tbl.Columns)
                    dt.Columns.Add(column.ColumnName.ToString());

                foreach (DataRow row in tbl.Rows)
                    if (Convert.ToDateTime(row["CreationDate"]) <= Convert.ToDateTime(to))
                        dt.ImportRow(row);
                return dt;
            }
            return tbl;
        }

        public static DataTable FilterByPerformance(DataTable tbl, string performance) // סינון לפי הופעה
        {
            string performanceId = PerformanceService.FindPerformanceId(performance);
            DataTable dt = DbManagement.GetTableByQuery("Select * from PerformancesDances where PerformanceId=" + performanceId);

            DataTable dt1 = new DataTable();
                foreach (DataColumn column in tbl.Columns)
                    dt1.Columns.Add(column.ColumnName.ToString());

                foreach (DataRow row in tbl.Rows)
                    foreach (DataRow row1 in dt.Rows)
                        if (row["DanceId"].ToString() == row1["DanceId"].ToString())
                            dt1.ImportRow(row);

                return dt1;
        }

        public static DataTable FilterByLength(DataTable dances, double from, double to) // סינון לפי אורך 
        {
            if (from == -1 && to == -1) return dances;

            DataTable dt = new DataTable();
            foreach (DataColumn column in dances.Columns)
                dt.Columns.Add(column.ColumnName.ToString());

            if (from == -1)
            {
                foreach (DataRow row in dances.Rows)
                    if (Convert.ToDouble(row["DanceLength"]) <= to)
                        dt.ImportRow(row);
                return dt;
            }

            if (to == -1)
            {
                foreach (DataRow row in dances.Rows)
                    if (Convert.ToDouble(row["DanceLength"]) >= from)
                        dt.ImportRow(row);
                return dt;
            }

            foreach (DataRow row in dances.Rows)
                if (Convert.ToDouble(row["DanceLength"]) >= from && Convert.ToDouble(row["DanceLength"]) <= to)
                    dt.ImportRow(row);
            return dt;
        }
    }
}