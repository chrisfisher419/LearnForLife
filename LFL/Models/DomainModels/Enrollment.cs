using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int UserID { get; set; }
        //public int SubjectID { get; set; }
        public int CourseID { get; set; }

        public virtual User Users { get; set; }
        //public virtual Subject Subjects { get; set; }
        public virtual Course Courses { get; set; }

    }
}