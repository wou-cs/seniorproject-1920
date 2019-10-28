﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User_WithDB.Models
{
    public class User
    {
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