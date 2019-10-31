using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User_withDB_2.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required, DisplayName("First Name")]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(128)]
        public string LastName { get; set; }

        [DisplayName("Date of Birth"), Required]
        public DateTime DOB { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DOB.Year;
                if (DOB > today.AddYears(-age))
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