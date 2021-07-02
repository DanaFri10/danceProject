using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanceProject.TypeClasses
{
    public class Dance
    {
        public string DanceId; //קוד הריקוד
        public string DanceName; // שם הריקוד
        public string DanStyleCatId; // סגנון הריקוד
        public string DanTypeCatId; // סוג הריקוד
        public string ChoreographerId; // ת"ז של הכיראוגרף
        public decimal DanceLength; // אורך הריקוד
        public string DanceSong; // שיר הריקוד
        public string DanceVideo; // סרטון הריקוד
        public string DancePhoto; // תמונת הריקוד
        public string CreationDate; // תאריך יצירת הריקוד

        public Dance() { } // פעולה בונה ללא פרמטרים

        public Dance(string DanceId, string DanceName, string DanStyleCatId, string DanTypeCatId, string ChoreographerId, decimal DanceLength, string DanceSong,string DancePhoto ,string DanceVideo,string CreationDate) // פעולה בונה שמקבלת פרמטרים
        {
            this.DanceId = DanceId;
            this.DanceName = DanceName;
            this.DanStyleCatId = DanStyleCatId;
            this.DanTypeCatId = DanTypeCatId;
            this.ChoreographerId = ChoreographerId;
            this.DanceLength = DanceLength;
            this.DanceSong = DanceSong;
            this.DancePhoto = DancePhoto;
            this.DanceVideo = DanceVideo;
            this.CreationDate = CreationDate;
        }
    }
}