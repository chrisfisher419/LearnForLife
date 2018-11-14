using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LFL.Models
{
    public class Replies
    {
        [Key]
        public int ReplyID { get; set; }
        public int TopicID { get; set; }
        public int UserID { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Reply")]
        public string ReplyMessage { get; set; }

        public virtual MessageBoard Topics { get; set; }
        public virtual User Users { get; set; }

    }
}