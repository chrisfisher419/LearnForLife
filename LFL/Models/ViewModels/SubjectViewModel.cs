using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models.ViewModels
{
    public class SubjectViewModel
    {
        [Display(Name="Subject Name")]
        public string SubjectName { get; set; }

        public IEnumerable<Course> Course { get; set; }
    }
}