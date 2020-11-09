using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models.IdentityModel
{
    public class UserRegistrationIdentityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string DateOfBirth {get;set;}
        public string Gender { get; set; }
        public string CurrentlyLivingIn { get; set; }
        public string MaritalStatus { get; set; }
        public int AadharCard { get; set; }
        public int pincode { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        
        public int MobileNo { get; set; }

        public string LeadAssigned { get; set; }

        public int UserType { get; set; }
        public int AssignedTeam { get; set; }

        
    }
}