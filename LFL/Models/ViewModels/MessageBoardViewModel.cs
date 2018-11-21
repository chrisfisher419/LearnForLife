using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LFL.Models.ViewModels
{
    public class MessageBoardViewModel
    {

        //public int TopicID { get; set; }
        [Display(Name = "Topic Name")]
        public string TopicName { get; set; }
        //public int UserID { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Subject")]
        public string TopicSubject { get; set; }
        [Display(Name = "Message")]
        public string TopicMessage { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("tinymce_jquery_full")]
        public Replies Reply { get; set; }

        public IEnumerable<Replies> Replies { get; set; }
    }
}