using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DanceProject.TypeClasses;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace DanceProject.ServiceClasses
{
    public class UserService
    {
        public static User FindUser(DataTable dt, string UserId, string UserPassword) // מציאת משתמש לפי ת"ז וסיסמה
        {
            User u = null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserId"].ToString() == UserId && dr["UserPassword"].ToString() == UserPassword)
                {
                    u = new User();
                    u.UserId = dr["UserId"].ToString();
                    u.UserPassword = dr["UserPassword"].ToString();
                    u.UserCategory = dr["UserCategory"].ToString();
                    u.UserFirstName = dr["UserFirstName"].ToString();
                    u.UserLastName = dr["UserLastName"].ToString();
                    u.UserBirthDate = dr["UserBirthDate"].ToString();
                    u.UserPhoneNumber = dr["UserPhoneNumber"].ToString();
                    u.ProfilePicture = dr["ProfilePicture"].ToString();
                    u.UserEmail = dr["UserEmail"].ToString();
                    u.IsBlocked = (bool)dr["IsBlocked"];
                    u.IsAdmin = (bool)dr["IsAdmin"];
                }
            } 
            return u;
        }

        public static DataTable RemoveDoubles(DataTable Users) // הורדת כפילויות
        {
            DataTable dt = new DataTable();
            foreach (DataColumn c in Users.Columns) dt.Columns.Add(c.ColumnName);
            
            foreach (DataRow r1 in Users.Rows)
            {
                bool found=false;
                foreach (DataRow r2 in dt.Rows) if(r1["UserId"].ToString()==r2["UserId"].ToString()) found = true;
                if (!found) dt.ImportRow(r1);
            }
            return dt;
        }

        public static User FindUserById(DataTable dt, string UserId) // מציאת משתמש לפי ת"ז
        {
            User u = null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserId"].ToString() == UserId )
                {
                    u = new User();
                    u.UserId = dr["UserId"].ToString();
                    u.UserPassword = dr["UserPassword"].ToString();
                    u.UserCategory = dr["UserCategory"].ToString();
                    u.UserFirstName = dr["UserFirstName"].ToString();
                    u.UserLastName = dr["UserLastName"].ToString();
                    u.UserBirthDate = dr["UserBirthDate"].ToString();
                    u.UserPhoneNumber = dr["UserPhoneNumber"].ToString();
                    u.ProfilePicture = dr["ProfilePicture"].ToString();
                    u.UserEmail = dr["UserEmail"].ToString();
                    if (dr["IsBlocked"].ToString() == "False") u.IsBlocked = false;
                    else u.IsBlocked = true;
                    if (dr["IsAdmin"].ToString() == "False") u.IsBlocked = false;
                    else u.IsAdmin = true;
                }
            }
            return u;
        }

        public static void BlockUser(string UserId, bool IsBlocked) // חסימת משתמש
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Users SET IsBlocked=" + IsBlocked + " WHERE UserId=\"" + UserId + "\"", Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void ConfirmUser(string UserId, bool IsConfirmed) // אישור משתמש
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Users SET IsConfirmed=" + IsConfirmed + " WHERE UserId=\"" + UserId + "\"", Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }


        public static string GetPassword(DataTable dt,string UserId) // מציאת הסיסמה של המשתמש (שחזור סיסמה)
        {
            string pass = null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserId"].ToString() == UserId) pass = dr["UserPassword"].ToString();
            }
            return pass;
        }

        public static string GetEmail(DataTable dt, string UserId) // מציאת המייל של המשתמש
        {
            string email = null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserId"].ToString() == UserId) email = dr["UserEmail"].ToString();
            }
            return email;
        }

        public static void Register(string UserId, string UserPassword, string UserCategory, string UserFirstName, string UserLastName, string UserBirthDate, string UserPhoneNumber,string ProfilePicture,string UserEmail, bool IsBlocked, bool IsAdmin) // הרשמה לאתר
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO Users(UserId, UserPassword, UserCategory , UserFirstName, UserLastName, UserBirthDate, UserPhoneNumber,ProfilePicture,UserEmail, IsBlocked, IsAdmin) VALUES(@UserId,@UserPassword,@UserCategory , @UserFirstName, @UserLastName, @UserBirthDate, @UserPhoneNumber,@ProfilePicture,@UserEmail, @IsBlocked, @IsAdmin)", Conn);
                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@UserPassword", UserPassword);
                command.Parameters.AddWithValue("@UserCategory", UserCategory);
                command.Parameters.AddWithValue("@UserFirstName", UserFirstName);
                command.Parameters.AddWithValue("@UserLastName", UserLastName);
                command.Parameters.AddWithValue("@UserBirthDate", UserBirthDate);
                command.Parameters.AddWithValue("@UserPhoneNumber", UserPhoneNumber);
                command.Parameters.AddWithValue("@ProfilePicture", ProfilePicture);
                command.Parameters.AddWithValue("@UserEmail", UserEmail);
                command.Parameters.AddWithValue("@IsBlocked", IsBlocked);
                command.Parameters.AddWithValue("@IsAdmin", IsAdmin);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }

        public static void Update(string UserId ,string UserPassword, int UserCategory, string UserFirstName, string UserLastName, string UserBirthDate, string UserPhoneNumber, string ProfilePicture, string UserEmail, bool IsBlocked, bool IsAdmin) // עדכון פרטי משתמש
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = Connect.GetConnectionString();
            Conn.Open();

            try
            {
                OleDbCommand command = new OleDbCommand("UPDATE Users SET UserPassword=\"" + UserPassword + "\", UserCategory=" + UserCategory + " ,UserFirstName=\"" + UserFirstName + "\", UserLastName=\"" + UserLastName + "\" ,UserBirthDate=\"" + UserBirthDate + "\" ,UserPhoneNumber=\"" + UserPhoneNumber + "\" ,ProfilePicture=\"" + ProfilePicture + "\", UserEmail=\"" + UserEmail + "\", IsBlocked=" + IsBlocked + ", IsAdmin=" + IsAdmin + " WHERE UserId=\"" + UserId + "\"", Conn);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("There was an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { Conn.Close(); }
        }
    }
}