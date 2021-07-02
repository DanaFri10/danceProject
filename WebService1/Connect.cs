using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService1
{
    public class Connect
    {
        public static string GetConnectionString()
        {
            string FILE_NAME = "WebService.accdb";
            string location = HttpContext.Current.Server.MapPath("~/App_Data/" + FILE_NAME);
            string ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0; data source =" + location;
            return ConnectionString;
        }
    }
}