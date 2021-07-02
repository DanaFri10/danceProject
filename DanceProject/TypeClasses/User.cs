using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanceProject.TypeClasses
{
    public class User
    {
        public string UserId;
        public string UserPassword;
        public string UserCategory;
        public string UserFirstName;
        public string UserLastName;
        public string UserBirthDate;
        public string UserPhoneNumber;
        public string ProfilePicture;
        public string UserEmail;
        public bool IsBlocked;
        public bool IsAdmin;

        public User() { }

        public User(string UserId,string UserPassword,string UserCategory,string UserFirstName,string UserLastName,string UserBirthDate,string UserPhoneNumber,string ProfilePicture,string UserEmail, bool IsBlocked,bool IsAdmin) 
        {
            this.UserId = UserId;
            this.UserPassword = UserPassword;
            this.UserCategory = UserCategory;
            this.UserFirstName = UserFirstName;
            this.UserLastName = UserLastName;
            this.UserBirthDate = UserBirthDate;
            this.UserPhoneNumber = UserPhoneNumber;
            this.UserPhoneNumber = UserPhoneNumber;
            this.ProfilePicture = ProfilePicture;
            this.UserEmail = UserEmail;
            this.IsBlocked = IsBlocked;
            this.IsAdmin = IsAdmin;
        }
    }
}