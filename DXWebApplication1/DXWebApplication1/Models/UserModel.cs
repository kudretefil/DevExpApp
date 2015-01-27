using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool rememberme { get; set; }
    }
}