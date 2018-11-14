using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models
{
    public class Subject
    {
        [Key]
        [Display(Name="Subject")]
        public int SubjectID { get; set; }
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        public IEnumerable<Course> Course { get; set; }
    }
}