using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Common
{
    public class User
    {
        public string UserID { get; set; }
        public User()
        {
            UserID = "TestUserID";
        }
    }
}