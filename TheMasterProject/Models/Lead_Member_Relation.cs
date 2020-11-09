using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class Lead_Member_Relation
    {
        [Key]
        public int id { get; set; }
       
        public string UserId { get; set; }

        public string ProjectLeadId { get; set; }

        [NotMapped]
        public IEnumerable<ApplicationUser> TeamLeadDetails { get; set; }

        [NotMapped]
        public string[] TeamLeads { get; set; }
    }
}