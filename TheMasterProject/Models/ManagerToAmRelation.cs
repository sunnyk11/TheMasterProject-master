using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class ManagerToAmRelation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("managerDetails")]
        public string ManagerId { get; set; }

        [ForeignKey("assistantManagerDetails")]
        public string AssitantManagerId { get; set; }

        public ApplicationUser managerDetails { get; set; }
        public ApplicationUser assistantManagerDetails { get; set; }

        [NotMapped]
        public string[] AMIds { get; set; }

        [NotMapped]
        public IEnumerable<ApplicationUser> AMList { get; set; }
    }
}