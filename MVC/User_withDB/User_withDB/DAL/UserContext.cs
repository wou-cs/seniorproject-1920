using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User_withDB.Models;

namespace User_withDB.DAL
{
    public class UserContext : DbContext
    {
        // UserDB is the name of the database (in a config file)
        public UserContext() : base("name=UserDB")
        {

        }

        // "Users" is the name of the table to access
        // <User> is the entity that resides in each row of the table
        public virtual DbSet<User> Users { get; set; }
    }
}