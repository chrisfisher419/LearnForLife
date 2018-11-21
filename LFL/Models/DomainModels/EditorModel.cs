using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LFL.Models.DomainModels
{
    public class EditorModel
    {
        [UIHint("tinymce_full"), AllowHtml]
        public string TextField { get; set; }
    }
}