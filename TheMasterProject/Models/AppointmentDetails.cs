using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class AppointmentDetails
    {
        [Key]
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
    }
}