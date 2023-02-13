using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ENGLISH.Models;
using System.Web.Security;
using System.Data;

namespace WEB_ENGLISH.Models
{
    public class DapAnMetaData
    {
        public int Id { get; set; }
        public Nullable<int> MaCauHoi { get; set; }
        public string Dap_an_A { get; set; }
        public string Dap_an_B { get; set; }
        public string Dap_an_C { get; set; }
        public string Dap_an_D { get; set; }

        public virtual CauHoi CauHoi { get; set; }
    }
}