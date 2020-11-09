using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMasterProject.Models
{
    public class BuyerDocumentUploadViewModel
    {
        public int BuyerId { get; set; }
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

    }
}