using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class AppointmentViewModel
    {
        [Display(Name = "Appointmen Date & Time")]
        [Required]
        public string AppointmentDate { get; set; }
        [Required]
        public string AppointmentTime { get; set; }

        public string AppointmentTimeFromDb { get; set; }
    }
}