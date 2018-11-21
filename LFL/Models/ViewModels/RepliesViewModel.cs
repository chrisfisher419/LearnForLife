using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LFL.Models.ViewModels
{
    public class RepliesViewModel
    {
        //public int ReplyID { get; set; }
        //public int TopicID { get; set; }
        //public int UserID { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Reply")]
        [Required]
        [AllowHtml]
        [UIHint("tinymce_jquery_full")]
        public string ReplyMessage { get; set; }
        //[DataType(DataType.DateTime)]
        //public System.DateTime CreateDate
        //{
        //    get
        //    {
        //        return System.DateTime.Now;
        //    }
        //    set { CreateDate = value; }
        //}


        public virtual MessageBoard Topics { get; set; }
        public virtual User Users { get; set; }
    }
}