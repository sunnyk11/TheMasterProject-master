using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class ManagerToAssistantMViewModel
    {
        public string ManagerName { get; set; }

        public string AssistantManagerName { get; set; }

        public List<string> Assistant { get; set; }
    }
}