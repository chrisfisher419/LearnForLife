using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        //public string TimeStamp { get; set; }

        public IEnumerable<Replies> Replies { get; set; }
    }
}