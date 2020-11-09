using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class ProjectLeadDetails
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CurrentlyLivingIn { get; set; }
        public string MaritalStatus { get; set; }
        public int AadharCard { get; set; }
        public int pincode { get; set; }
        public int MobileNo { get; set; }
        public DateTime TimestampCreated { get; set; }
        


        public string EmailId { get; set; }
        public string Password { get; set; }
        public Nullable<DateTime> TimestampUpdated { get; set; }
        public int UserType { get; set; }



        public int status { get; set; }
        [NotMapped]
        public string fullName
        {
            get
            {
                return FirstName + LastName;
            }
            set
            {
            }
        }
    }
}