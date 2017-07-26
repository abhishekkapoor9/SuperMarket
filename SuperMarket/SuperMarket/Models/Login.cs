using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public String UCustomerId { get; set; }
        public string  UserName { get; set; }
        public string Password { get; set; }
        public string LastModified { get; set; }
        public string oldPassword { get; set; }
    }
}