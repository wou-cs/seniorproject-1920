using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using User_withDB_2.Models;

namespace User_withDB_2.DAL
{
    // Class that gives us access to a DB
    public class UserContext : DbContext
    {
        // Which database to connect to (details in web.config)
        public UserContext() : base("name=OurUserDB")
        {

        }

        // Access to our Users table
        public virtual DbSet<User> Users { get; set; }
    }
}