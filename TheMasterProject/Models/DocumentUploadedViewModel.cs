using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class DocumentUploadedViewModel
    {
        public int BuyerId { get; set; }
        public string FileName { get; set; }
        public int Type { get; set; }
    }
}