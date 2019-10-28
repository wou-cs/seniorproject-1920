using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User_NoDB.Models;

namespace User_NoDB.DAL
{
    public class UserCollection
    {
        public List<User> Users;

        public UserCollection()
        {
            Users = new List<User>
            {
                new User {FirstName = "Henry", LastName = "Smith", DOB = new DateTime(1998, 4,1)},
                new User {FirstName = "Frasier", LastName = "Crane", DOB = new DateTime(1950, 5,18)},
                new User {FirstName = "Bob", LastName = "Saget", DOB = new DateTime(1965, 1,28)},
                new User {FirstName = "Arnold", LastName = "Shwarz", DOB = new DateTime(1990, 7,12)}
            };
        }
    }
}