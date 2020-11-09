using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class BuyerDetailViewModel
    {
        public string SearchText { get; set; }
        public int BuyerId { get; set; }

        [Required(ErrorMessage = "First Name Is Required")]
        [Display(Name = "First Name")]
        public string BuyerName { get; set; }

        [Display(Name = "Middle Name")]
        public string BuyerMiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string BuyerLastName { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Aadhar Card")]
        public string AadharCard { get; set; }

        [Display(Name = "Pan Card")]
        public string PanCard { get; set; }

        [Required(ErrorMessage = "Mobile No Is Required")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        
        public string ManagerAssigned { get; set; }

        [Display(Name = "Current Status")]
        public string currenStatus { get; set; }

        //other Information
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth Is Required")]
        [Display(Name = "Date of Birth")]
        public string dob { get; set; }

        [Display(Name = "Father First Name")]
        public string FatherFirstName { get; set; }

        [Display(Name = "Father Middle Name")]
        public string FatherMiddleName { get; set; }

        [Display(Name = "Father Last Name")]
        public string FatherLastName { get; set; }

        [Display(Name = "Mother First Name")]
        public string MotherFirstName { get; set; }

        [Display(Name = "Mother Middle Name")]
        public string MotherMiddleName { get; set; }

        [Display(Name = "Mother Last Name")]
        public string MotherLastName { get; set; }

        [Display(Name = "Personal Comments")]
        public string PersonalComments { get; set; }

        //Current Residence Details
        [Display(Name = "Ownership")]
        public string Ownership { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "Living @address Since")]
        public string LivingSince { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "Living in city Since")]
        public string LivingInCitySince { get; set; }

        [Display(Name = "Home Address")]
        public string Address { get; set; }

        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "City")]
        public Nullable<int> City { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "State")]
        public Nullable<int> State { get; set; }

        [Display(Name = "Pincode")]
        public string pincode { get; set; }

        //employment Details
        [Required(ErrorMessage = "Please Choose Employment Type")]
        [Display(Name = "Employment Type")]
        public string EmploymentStatus { get; set; }

        [Display(Name = "Organization Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "Salary Credit Type")]
        public string SalaryCreditType { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "Month & Year of Joining")]
        public string JoiningYearandMonth { get; set; }

        [Range(15000,15000000,ErrorMessage ="Please Enter More than 15000")]
        [Display(Name = "Monthly Salary")]
        public int MonthlySalary { get; set; }
        
        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "Constitution of Company")]
        public string ConstitutionOfCompany { get; set; }

        //office address
        [Display(Name = "Address Line 1")]
        public string officeAddressLine { get; set; }

        [Display(Name = "Address Line 2")]
        public string officeAddressLine2 { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "City")]
        public Nullable<int> OfficeCity { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Display(Name = "State")]
        public Nullable<int> OfficeState { get; set; }

        [Display(Name = "Pincode")]
        public string Officepincode { get; set; }


        [Display(Name = "LoanAmount")]
        public string LoanAmount { get; set; }

        [Required(ErrorMessage = "Please Select Title")]
        public string Title { get; set; }

        //Address Proof
        public int AddressProofDetailId { get; set; }

        public bool PassportCopy { get; set; }

        public bool DrivingLicenceWithDob { get; set; }

        public bool VotersId { get; set; }

        public bool ElectricityBill { get; set; }

        public bool TelephoneBill { get; set; }

        public bool LeaveLicenceAggrCopy { get; set; }

        public bool CompanyAccoLetter { get; set; }

        public bool OtherBankStatmnt { get; set; }

        public bool TelephoneProof { get; set; }

        public bool AadharCardCopy { get; set; }

        public string AddressProofFileName { get; set; }

        //ApplicationForm
        public int ApplicationFormDetailId { get; set; }

        public bool ApplicationFormImaging { get; set; }
        
        public string ApplicationFormFileName { get; set; }

        //Income proof
        public int IncomeProofDetailId { get; set; }

        public bool Form16 { get; set; }

        public bool AppointmentLetter { get; set; }

        public bool SalarySlip { get; set; }

        public bool Itr { get; set; }

        public bool GstCertification { get; set; }

        public string IncomeProofFileName { get; set; }

        //Bank Statement
        public int BankStatementDetailId { get; set; }

        public bool BankStatementLatestSixMonths { get; set; }

        public bool BankStatmentThreeMonths { get; set; }

        public bool BankStatementYear { get; set; }

        public string BankStatementFileName { get; set; }

        //Identity Proof
        public int IdentityProofDetailId { get; set; }

        public bool VotersIdCard { get; set; }

        public string IdentityProofFileName { get; set; }

        //Profile Documents
        public int ProfileDocumentDetailId { get; set; }

        public bool PanCardId { get; set; }

        public bool ProfilePhoto { get; set; }

        public string ProfileDocumentFileName { get; set; }

        //HTTPPOSTED Files

        public HttpPostedFileBase[] addressProof { get; set; }

        public HttpPostedFileBase[] applicationForm { get; set; }

        public HttpPostedFileBase[] incomeProof { get; set; }

        public HttpPostedFileBase[] bankStatement { get; set; }

        public HttpPostedFileBase[] identityProof { get; set; }

        public HttpPostedFileBase[] profileDocumet { get; set; }

        //appointment Details
        [Display(Name ="Appointmen Date & Time")]
        [Required]
        public string AppointmentDate{ get; set; }
        [Required]
        public string AppointmentTime { get; set; }

        public string AppointmentTimeFromDb { get; set; }

    }
}