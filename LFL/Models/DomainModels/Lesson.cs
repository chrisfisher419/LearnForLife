using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LFL.Models.DomainModels
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public int CourseID { get; set; }
        public string LessonName { get; set; }
        [AllowHtml]
        [UIHint("tinymce_jquery_full")]
        public string Content { get; set; }

        public virtual Course Course { get; set; }
        public IList<Question> Questions { get; set; }
    }
}