using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }

    }
}