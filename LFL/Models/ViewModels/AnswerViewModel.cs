using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LFL.Models.ViewModels
{
    public class AnswerViewModel
    {
        //public int QuestionID { get; set; }
        public string Answers { get; set; }
        public bool Correct { get; set; }

        public virtual Question Question { get; set; }
    }
}