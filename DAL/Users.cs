using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class Users
    {
        //Data annotation validations 
        [Required (ErrorMessage = "Only uptil 30 characters!")]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required (ErrorMessage ="Please Enter Email")]
        public string Email { get; set; }

        [StringLength(12)]
        public string UserPassword { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        
        public int Phone { get; set; }
    }
}
