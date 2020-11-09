using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class AssistantManagerToMemberRelation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("assistantManagerDetails")]
        public string AssistantManagerId { get; set; }

        [ForeignKey("teamMemberDetails")]
        public string TeamMemberId { get; set; }

        public ApplicationUser assistantManagerDetails { get; set; }

        public ApplicationUser teamMemberDetails { get; set; }
    }
}