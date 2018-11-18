using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models.ViewModels
{
    public class CourseViewModel
    {
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Information")]
        public string CourseInfo { get; set; }
        public int SubjectID { get; set; }
        [Display(Name="Course Content")]
        public string CourseContent { get; set; }

        public virtual Subject Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}