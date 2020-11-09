using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class DealerToManagerRelation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DealerDetails")]
        public string DealerId { get; set; }

        [ForeignKey("ManagerDetails")]
        public string ManagerId { get; set; }

        [ForeignKey("BuyerDetails")]
        public Nullable<int> BuyerId { get; set; }
        public ApplicationUser DealerDetails { get; set; }
        public ApplicationUser ManagerDetails { get; set; }
        public Buyer_Detail BuyerDetails { get; set; }

    }
}