using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public string Answers { get; set; }
        public bool Correct { get; set; }

        public virtual Question Question { get; set; }
    }
}