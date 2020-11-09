using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        public int StateCode { get; set; }

        public string StateName { get; set; }
    }
}