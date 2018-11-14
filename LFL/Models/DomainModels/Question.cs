using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public int CourseID { get; set; }
        public string Questions { get; set; }

        public virtual Course Course { get; set; }
        public IEnumerable<Answer> Answers { get; set; }

    }
}