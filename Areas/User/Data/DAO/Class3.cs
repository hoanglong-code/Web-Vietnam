using WEB_ENGLISH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_ENGLISH.Areas.User.Data.DAO
{
    public class Class3
    {
        private static Models.WEBEntities db = new Models.WEBEntities();
        public Class3()
        {
        }
        public static int CheckLogin(String Username,String Passwords)
        {
            int num = db.ThanhViens.Count(x => x.Username == Username && x.Password == Passwords );
            if (num > 0) { return 1; }        
            return 0;
        }
    }
}
