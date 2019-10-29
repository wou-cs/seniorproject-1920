using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User_noDB_2.Models;

namespace User_noDB_2.DAL
{
    public class UserCollection
    {
        public List<User> Users;

        public UserCollection()
        {
            Users = new List<User> { 
                new User {FirstName = "Joe", LastName = "Morse", DOB = new DateTime(1988,5,16)},
                new User {FirstName = "Max", LastName = "Love", DOB = new DateTime(2000,8,2)},
                new User {FirstName = "Deborah", LastName = "Deborah", DOB = new DateTime(1950,1,1)},
                new User {FirstName = "Judy", LastName = "Judge", DOB = new DateTime(2006,9,28)}
            };
        }
    }
}