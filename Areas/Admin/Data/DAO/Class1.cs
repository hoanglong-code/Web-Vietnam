using WEB_ENGLISH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_ENGLISH.Areas.Admin.Data.DAO
{
    public class Class1
    {
        private static Models.WEBEntities db = new Models.WEBEntities();
        public Class1()
        {
        }
        public static int CheckLogin(String Username, String Passwords)
        {
            int num = db.admins.Count(x => x.Username == Username && x.Password == Passwords);
            if (num > 0) { return 1; }
            return 0;
        }
    }
}