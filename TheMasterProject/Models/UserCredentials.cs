using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class UserCredentials
    {
        [Key]
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public DateTime TimeStampCreated { get; set; }
        public Nullable<DateTime> TimeStampUpdated { get; set; }
        [ForeignKey("UserDetails")]
        public int UserId { get; set; }

        public UserDetails UserDetails { get; set; }
    }
}