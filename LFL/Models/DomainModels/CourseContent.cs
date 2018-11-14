using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models.DomainModels
{
    public class CourseContent
    {
        [Key]
        public int ContentID { get; set; }
        public int CourseID { get; set; }
        public string Content { get; set; }

        public virtual Course Courses { get; set; }
    }
}