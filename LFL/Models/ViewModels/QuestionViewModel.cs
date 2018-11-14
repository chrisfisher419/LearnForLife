using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LFL.Models.ViewModels
{
    public class QuestionViewModel
    {
        //public int CourseID { get; set; }
        public string Questions { get; set; }

        public virtual Course Course { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}