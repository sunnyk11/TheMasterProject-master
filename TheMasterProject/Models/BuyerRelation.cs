using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class BuyerRelation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ManagerDetail")]
        public string ManagerId { get; set; }
        [ForeignKey("BuyerDetail")]
        public int BuyerId { get; set; }
        [ForeignKey("MemberDetail")]
        public string MemberId { get; set; }
        [ForeignKey("AMDetail")]
        public string AssistantManagerId { get; set; }
        
        public DateTime UpdatedOn { get; set; }
        public Buyer_Detail BuyerDetail { get; set; }
       
        public ApplicationUser ManagerDetail { get; set; }
        public ApplicationUser MemberDetail { get; set; }
        public ApplicationUser AMDetail { get; set; }
    }
}