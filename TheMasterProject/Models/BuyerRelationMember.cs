using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class BuyerRelationMember
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MemberDetail")]
        public string MemberId { get; set; }
        [ForeignKey("BuyerDetail")]
        public int BuyerId { get; set; }


        public BuyerRelation BuyerDetail { get; set; }

        public ApplicationUser MemberDetail { get; set; }
    }
}