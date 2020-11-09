using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public int StateCode { get; set; }
        
        public int CityCode { get; set; }

        public string CityName { get; set; }

    }
}