using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LFL.Models.DomainModels;

namespace LFL.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public int LessonID { get; set; }
        public string Questions { get; set; }

        public virtual Course Course { get; set; }
        public virtual Lesson Lesson { get; set; }
        public IEnumerable<Answer> Answers { get; set; }

    }
}