﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Display(Name="Course Name")]
        public string CourseName { get; set; }
        [Display(Name="Course Information")]
        public string CourseInfo { get; set; }
        public int SubjectID { get; set; }

        public virtual Subject Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}