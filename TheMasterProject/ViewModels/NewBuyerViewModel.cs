﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMasterProject.ViewModels
{
    public class NewBuyerViewModel
    {
        public int BuyerId { get; set; }

        [Required(ErrorMessage = "Please Select Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string BuyerName { get; set; }

        [Required(ErrorMessage = "Aadhar Number is Required")]
        [Display(Name = "Aadhar Card")]
        public string AadharCard { get; set; }

        [Required(ErrorMessage = "PAN Number is Required")]
        [Display(Name = "Pan Card")]
        public string PanCard { get; set; }

        [Required(ErrorMessage = "Mobile No Is Required")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        public string ManagerAssigned { get; set; }

    }
}