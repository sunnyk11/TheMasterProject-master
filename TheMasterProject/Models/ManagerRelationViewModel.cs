using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class ManagerRelationViewModel
    {
        public string ManagerId { get; set; }
        
        public string AssistantManagerId { get; set; }

        public string ManagerName { get; set; }

        public string ManagerEmail { get; set; }

        public string AssistantManagerName { get;set; }

    }
}