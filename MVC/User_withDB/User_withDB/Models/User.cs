using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Needs to match our db:
 * [ID]		INT IDENTITY (1,1)	NOT NULL,
	[FirstName] NVARCHAR(64)		NOT NULL,
	[LastName]	NVARCHAR(128)		NOT NULL,
	[DOB]		DATETIME			NOT NULL,
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
 */

namespace User_withDB.Models
{
    public class User
    {
        // property named: ID, Id, or UserID, or maybe UserId is automatically
        // mapped to our ID primary key, by our ORM (Object Relational Mapper) Entity Framework
        [Key]
        public int ID { get; set; }

        [DisplayName("First")]
        [StringLength(64)]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last")]
        [StringLength(128),Required]
        public string LastName { get; set; }

        [DisplayName("Date of Birth"),Required]
        public DateTime DOB { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DOB.Year;
                if(DOB > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} DOB = {DOB} Age = {Age}"; 
        }
    }
}