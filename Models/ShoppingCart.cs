﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ENGLISH.Models;
using System.Web.Security;
using System.Data;

namespace WEB_ENGLISH.Models
{
    public class ShoppingCart
    {
        public int id { get; set; }
        public Nullable<int> total { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> qty { get; set; }
        public string avatar { get; set; }
        public string name { get; set; }
        public ShoppingCart(int iid, int sl)
        {
            using (WEBEntities db = new WEBEntities())
            {
                this.id = iid;
                product prd = db.products.Single(x => x.id == iid);
                this.avatar = prd.avatar;
                this.name = prd.name;
                this.qty = sl;
                this.price = prd.price;
                this.total = price * qty;
            }
        }
    }
}