using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanceProject.TypeClasses
{
    public class Performance
    {
        public string PerformanceId; // קוד ההופעה
        public string PerformanceName; // שם ההופעה
        public string PerformancePhoto; // תמונת ההופעה
        public string PerformanceChoreographer; // כיראוגרף ההופעה
        public string CreationDate; // תאריך יצירת ההופעה

        public Performance() { } // פעולה בונה ללא פרמטרים

        public Performance(string PerformanceId, string PerformanceName, string PerformancePhoto,string PerformanceChoreographer, string CreationDate) // פעולה בונה שלא מקבלת פרמטרים
        {
            this.PerformanceId = PerformanceId;
            this.PerformanceName = PerformanceName;
            this.PerformancePhoto = PerformancePhoto;
            this.PerformanceChoreographer = PerformanceChoreographer;
            this.CreationDate = CreationDate;
        }
    }
}