using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User_NoDB.Models
{
    public class User
    {
        [DisplayName("First")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [DisplayName("Last")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
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