using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class DocumentUploaded
    {
        [Key]
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string FileName { get; set; }
        public int FileType { get; set; }
    }
}