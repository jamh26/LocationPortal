using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { UserName = "admin", EmailAddress = "admin@local.com", Password = "password", GivenName = "Jacob", Surname = "Admin", Role = "Admin" },
            new UserModel() { UserName = "user", EmailAddress = "user@local.com", Password = "password", GivenName = "James", Surname = "User", Role = "User" }
        };
    }
}
