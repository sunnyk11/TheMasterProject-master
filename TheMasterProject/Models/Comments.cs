using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public int BuyerId { get; set; }
        public string CommentDetails { get; set; }
        public DateTime CommentDateTime { get; set; }
     
    }
}