using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheMasterProject.Models;

namespace TheMasterProject.Controllers
{
    public class LeadController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public string GetUserId()
        {
            string userId = null;
            if(Session["UserId"] != null)
            {
                userId = Session["UserId"].ToString();
            }
            return userId;
        }
        public ActionResult Index()
        {
            var userId = GetUserId();
            return View();
        }
        
        public ActionResult Search(BuyerDetailViewModel search)
        {
            var BuyerId = db.BuyerDetails.Where(x => x.PanCard == search.SearchText || x.MobileNo == search.SearchText.ToString()).Select(x => x.BuyerId).FirstOrDefault();
            if(BuyerId != 0)
            {
                var buyerFileDetails = db.BuyerDocuments.Where(x => x.BuyerId == BuyerId).FirstOrDefault();

                var buyerCityList = db.BuyerDetails.Where(x => x.BuyerId == BuyerId).Select(x => x.State).FirstOrDefault();

                var buyerOfficeCityList = db.BuyerDetails.Where(x => x.BuyerId == BuyerId).Select(x => x.OfficeState).FirstOrDefault();

                List<State> StateList = db.States.ToList();
                ViewBag.StateList = new SelectList(StateList, "StateCode", "StateName");

                List<City> CityList = db.City.Where(x => x.StateCode == buyerCityList).ToList();
                ViewBag.CityList = new SelectList(CityList, "CityCode", "CityName");

                ViewBag.OfficeStateList = new SelectList(StateList, "StateCode", "StateName");

                List<City> OfficeCityLists = db.City.Where(x => x.StateCode == buyerOfficeCityList).ToList();
                ViewBag.officeCityList = new SelectList(OfficeCityLists, "CityCode", "CityName");

                var buyerDetail = db.BuyerDetails.Find(BuyerId);

                var buyer = new BuyerDetailViewModel
                {
                    BuyerId = BuyerId,
                    BuyerName = buyerDetail.BuyerName,
                    BuyerMiddleName = buyerDetail.BuyerMiddleName,
                    BuyerLastName = buyerDetail.BuyerLastName,
                    MaritalStatus = buyerDetail.MaritalStatus,
                    AadharCard = buyerDetail.AadharCard,
                    PanCard = buyerDetail.PanCard,
                    MobileNo = buyerDetail.MobileNo,
                    ManagerAssigned = buyerDetail.ManagerAssigned,
                    Email = buyerDetail.Email,
                    dob = buyerDetail.dob,
                    FatherFirstName = buyerDetail.FatherFirstName,
                    FatherMiddleName = buyerDetail.FatherMiddleName,
                    FatherLastName = buyerDetail.FatherLastName,
                    MotherFirstName = buyerDetail.MotherFirstName,
                    MotherLastName = buyerDetail.MotherLastName,
                    MotherMiddleName = buyerDetail.MotherMiddleName,
                    PersonalComments = buyerDetail.PersonalComments,
                    LivingSince = buyerDetail.LivingSince,
                    LivingInCitySince = buyerDetail.LivingInCitySince,
                    Address = buyerDetail.Address,
                    Address2 = buyerDetail.Address2,
                    City = buyerDetail.City,
                    State = buyerDetail.State,
                    pincode = buyerDetail.pincode,
                    EmploymentStatus = buyerDetail.EmploymentStatus,
                    CompanyName = buyerDetail.CompanyName,
                    SalaryCreditType = buyerDetail.SalaryCreditType,
                    JoiningYearandMonth = buyerDetail.JoiningYearandMonth,
                    MonthlySalary = Convert.ToInt32(buyerDetail.MonthlySalary),
                    ConstitutionOfCompany = buyerDetail.ConstitutionOfCompany,
                    officeAddressLine = buyerDetail.officeAddressLine,
                    officeAddressLine2 = buyerDetail.officeAddressLine2,
                    OfficeCity = buyerDetail.OfficeCity,
                    OfficeState = buyerDetail.OfficeState,
                    Officepincode = buyerDetail.Officepincode,
                    LoanAmount = buyerDetail.LoanAmount,
                    Title = buyerDetail.Gender,

                };
                if (buyerFileDetails != null)
                {
                    buyer.PassportCopy = buyerFileDetails.PassportCopy;
                    buyer.DrivingLicenceWithDob = buyerFileDetails.DrivingLicenceWithDob;
                    buyer.VotersId = buyerFileDetails.VotersId;
                    buyer.ElectricityBill = buyerFileDetails.ElectricityBill;
                    buyer.TelephoneBill = buyerFileDetails.TelephoneBill;
                    buyer.LeaveLicenceAggrCopy = buyerFileDetails.LeaveLicenceAggrCopy;
                    buyer.CompanyAccoLetter = buyerFileDetails.CompanyAccoLetter;
                    buyer.OtherBankStatmnt = buyerFileDetails.OtherBankStatmnt;
                    buyer.TelephoneProof = buyerFileDetails.TelephoneProof;
                    buyer.AadharCardCopy = buyerFileDetails.AadharCardCopy;
                    buyer.AddressProofDetailId = buyerFileDetails.AddressDetailId;
                    //Application Form Details
                    buyer.ApplicationFormImaging = buyerFileDetails.ApplicationFormImaging;
                    buyer.ApplicationFormDetailId = buyerFileDetails.ApplicationFormDetailId;
                    //Income Proof
                    buyer.Form16 = buyerFileDetails.Form16;
                    buyer.AppointmentLetter = buyerFileDetails.AppointmentLetter;
                    buyer.SalarySlip = buyerFileDetails.SalarySlip;
                    buyer.Itr = buyerFileDetails.Itr;
                    buyer.GstCertification = buyerFileDetails.GstCertification;
                    buyer.IncomeProofDetailId = buyerFileDetails.IncomeProofDetailId;
                    //Bank Statement
                    buyer.BankStatementDetailId = buyerFileDetails.BankStatementDetailId;
                    buyer.BankStatementLatestSixMonths = buyerFileDetails.BankStatementLatestSixMonths;
                    buyer.BankStatmentThreeMonths = buyerFileDetails.BankStatmentThreeMonths;
                    buyer.BankStatementYear = buyerFileDetails.BankStatementYear;
                    //Identity Proof
                    buyer.VotersIdCard = buyerFileDetails.VotersIdCard;
                    buyer.IdentityProofDetailId = buyerFileDetails.IdentityProofDetailId;
                    //Profile Documents
                    buyer.PanCardId = buyerFileDetails.PanCardId;
                    buyer.ProfilePhoto = buyerFileDetails.ProfilePhoto;
                    buyer.ProfileDocumentDetailId = buyerFileDetails.ProfileDocumentDetailId;
                }
                //count of files
                ViewBag.AddressDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == BuyerId && x.FileType == 1).Count();
                ViewBag.ApplicationDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == BuyerId && x.FileType == 2).Count();
                ViewBag.IncomeProofDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == BuyerId && x.FileType == 3).Count();
                ViewBag.BankStatementDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == BuyerId && x.FileType == 4).Count();
                ViewBag.IdentityProofDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == BuyerId && x.FileType == 5).Count();
                ViewBag.ProfileDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == BuyerId && x.FileType == 6).Count();
                //
                ViewBag.docUploaded = db.DocumentUploadeds.Where(x => x.BuyerId == BuyerId).ToList();
                //buyer ownership
                var leadOwner = db.BuyerRelation.Include("ManagerDetail").Include("AMDetail").Include("MemberDetail").Where(x => x.BuyerId == BuyerId).FirstOrDefault();
                ViewBag.Manager = leadOwner.ManagerDetail.FirstName;
                ViewBag.AssistantManager = leadOwner.AMDetail.FirstName;
                ViewBag.Member = leadOwner.MemberDetail.FirstName;
                return View("UpdateLeadDetailsPartial", buyer);

            }
            return View("UpdateLeadDetailsPartial");


        }

        public JsonResult GetCityList(int StateId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<City> CityList = db.City.Where(x => x.StateCode == StateId).ToList();
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateDetails(BuyerDetailViewModel bv)
        {
            var BuyerDetails = db.BuyerDetails.Where(x => x.BuyerId == bv.BuyerId).FirstOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    BuyerDetails.BuyerName = bv.BuyerName;
                    BuyerDetails.BuyerMiddleName = bv.BuyerMiddleName;
                    BuyerDetails.BuyerLastName = bv.BuyerLastName;
                    BuyerDetails.MaritalStatus = bv.MaritalStatus;
                    BuyerDetails.AadharCard = bv.AadharCard;
                    BuyerDetails.PanCard = bv.PanCard;
                    BuyerDetails.MobileNo = bv.MobileNo;
                    BuyerDetails.ManagerAssigned = bv.ManagerAssigned;
                    BuyerDetails.Email = bv.Email;
                    BuyerDetails.dob = bv.dob;
                    BuyerDetails.FatherFirstName = bv.FatherFirstName;
                    BuyerDetails.FatherMiddleName = bv.FatherMiddleName;
                    BuyerDetails.FatherLastName = bv.FatherLastName;
                    BuyerDetails.MotherFirstName = bv.MotherFirstName;
                    BuyerDetails.MotherLastName = bv.MotherLastName;
                    BuyerDetails.MotherMiddleName = bv.MotherMiddleName;
                    BuyerDetails.PersonalComments = bv.PersonalComments;
                    BuyerDetails.LivingSince = bv.LivingSince;
                    BuyerDetails.LivingInCitySince = bv.LivingInCitySince;
                    BuyerDetails.Address = bv.Address;
                    BuyerDetails.Address2 = bv.Address2;
                    BuyerDetails.City = bv.City;
                    BuyerDetails.State = bv.State;
                    BuyerDetails.pincode = bv.pincode;
                    BuyerDetails.EmploymentStatus = bv.EmploymentStatus;
                    BuyerDetails.CompanyName = bv.CompanyName;
                    BuyerDetails.SalaryCreditType = bv.SalaryCreditType;
                    BuyerDetails.JoiningYearandMonth = bv.JoiningYearandMonth;
                    BuyerDetails.MonthlySalary = Convert.ToInt32(bv.MonthlySalary).ToString();
                    BuyerDetails.ConstitutionOfCompany = bv.ConstitutionOfCompany;
                    BuyerDetails.officeAddressLine = bv.officeAddressLine;
                    BuyerDetails.officeAddressLine2 = bv.officeAddressLine2;
                    BuyerDetails.OfficeCity = bv.OfficeCity;
                    BuyerDetails.OfficeState = bv.OfficeState;
                    BuyerDetails.Officepincode = bv.Officepincode;
                    BuyerDetails.LoanAmount = bv.LoanAmount;
                    BuyerDetails.Gender = bv.Title;

                    // db.BuyerDetails.Attach(BuyerDetails);
                    Comments newcomment = new Comments();
                    var lastComment = db.Comments.Where(x => x.BuyerId == bv.BuyerId).OrderByDescending(x => x.CommentId).Take(1).Select(x => x.CommentDetails).FirstOrDefault();

                    if (lastComment != bv.PersonalComments)
                    {
                        newcomment.BuyerId = bv.BuyerId;
                        newcomment.CommentDetails = bv.PersonalComments;
                        newcomment.CommentDateTime = DateTime.Now;

                        db.Comments.Add(newcomment);
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult UpdateFileDetails(BuyerDetailViewModel vm)
        {
            List<DocumentUploaded> dm = new List<DocumentUploaded>();

            var AddressDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == vm.BuyerId && x.FileType == 1).Count();
            var ApplicationDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == vm.BuyerId && x.FileType == 2).Count();
            var IncomeProofDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == vm.BuyerId && x.FileType == 3).Count();
            var BankStatementDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == vm.BuyerId && x.FileType == 4).Count();
            var IdentityProofDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == vm.BuyerId && x.FileType == 5).Count();
            var ProfileDetailFileCount = db.DocumentUploadeds.Where(x => x.BuyerId == vm.BuyerId && x.FileType == 6).Count();

            var CheckAddressDetailCount = AddressDetailFileCount + vm.addressProof.Count();
            var CheckApplicationDetailCount = ApplicationDetailFileCount + vm.applicationForm.Count();
            var CheckIncomeProofDetailCount = IncomeProofDetailFileCount + vm.incomeProof.Count();
            var CheckBankStatementDetailCount = BankStatementDetailFileCount + vm.bankStatement.Count();
            var CheckIndentityDetailCount = IdentityProofDetailFileCount + vm.identityProof.Count();
            var CheckProfileDetailCount = ProfileDetailFileCount + vm.profileDocumet.Count();

            if (vm.addressProof != null && CheckAddressDetailCount <= 5)
            {
                foreach (var fileitem in vm.addressProof)
                {
                    if (fileitem != null)
                    {
                        var fileName = Path.GetFileName(fileitem.FileName);

                        var docDetail = new DocumentUploaded
                        {
                            BuyerId = vm.BuyerId,
                            FileName = fileName,
                            FileType = 1
                        };
                        dm.Add(docDetail);

                        var serverPath = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                        fileitem.SaveAs(serverPath);
                    }
                }

                foreach (var item in dm)
                {
                    db.DocumentUploadeds.Add(item);
                }
            }

            else
            {
                ViewBag.Message = "The No Of Files You are Uploading and Already Uploaded Should Not Exceed More Than 5";
            }

            if (vm.applicationForm != null && CheckApplicationDetailCount <= 5)
            {
                foreach (var fileitem in vm.applicationForm)
                {
                    if (fileitem != null)
                    {
                        var fileName = Path.GetFileName(fileitem.FileName);

                        var docDetail = new DocumentUploaded
                        {
                            BuyerId = vm.BuyerId,
                            FileName = fileName,
                            FileType = 2
                        };
                        dm.Add(docDetail);

                        var serverPath = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                        fileitem.SaveAs(serverPath);
                    }
                }

                foreach (var item in dm)
                {
                    db.DocumentUploadeds.Add(item);
                }

            }

            if (vm.incomeProof != null && CheckIncomeProofDetailCount <= 5)
            {
                foreach (var fileitem in vm.incomeProof)
                {
                    if (fileitem != null)
                    {
                        var fileName = Path.GetFileName(fileitem.FileName);

                        var docDetail = new DocumentUploaded
                        {
                            BuyerId = vm.BuyerId,
                            FileName = fileName,
                            FileType = 3
                        };
                        dm.Add(docDetail);

                        var serverPath = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                        fileitem.SaveAs(serverPath);
                    }
                }

                foreach (var item in dm)
                {
                    db.DocumentUploadeds.Add(item);
                }

            }

            if (vm.bankStatement != null && CheckBankStatementDetailCount <= 5)
            {
                foreach (var fileitem in vm.bankStatement)
                {
                    if (fileitem != null)
                    {
                        var fileName = Path.GetFileName(fileitem.FileName);

                        var docDetail = new DocumentUploaded
                        {
                            BuyerId = vm.BuyerId,
                            FileName = fileName,
                            FileType = 4
                        };
                        dm.Add(docDetail);

                        var serverPath = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                        fileitem.SaveAs(serverPath);
                    }
                }

                foreach (var item in dm)
                {
                    db.DocumentUploadeds.Add(item);
                }

            }

            if (vm.identityProof != null && CheckIndentityDetailCount <= 5)
            {
                foreach (var fileitem in vm.identityProof)
                {
                    if (fileitem != null)
                    {
                        var fileName = Path.GetFileName(fileitem.FileName);

                        var docDetail = new DocumentUploaded
                        {
                            BuyerId = vm.BuyerId,
                            FileName = fileName,
                            FileType = 5
                        };
                        dm.Add(docDetail);

                        var serverPath = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                        fileitem.SaveAs(serverPath);
                    }
                }

                foreach (var item in dm)
                {
                    db.DocumentUploadeds.Add(item);
                }

            }

            if (vm.profileDocumet != null && CheckProfileDetailCount <= 5)
            {
                foreach (var fileitem in vm.profileDocumet)
                {
                    if (fileitem != null)
                    {
                        var fileName = Path.GetFileName(fileitem.FileName);

                        var docDetail = new DocumentUploaded
                        {
                            BuyerId = vm.BuyerId,
                            FileName = fileName,
                            FileType = 6
                        };
                        dm.Add(docDetail);

                        var serverPath = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                        fileitem.SaveAs(serverPath);
                    }
                }

                foreach (var item in dm)
                {
                    db.DocumentUploadeds.Add(item);
                }
            }

            var buyerDocuments = db.BuyerDocuments.Where(x => x.BuyerId == vm.BuyerId).FirstOrDefault();

            if (buyerDocuments != null)
            {
                //Address Proof Details
                buyerDocuments.PassportCopy = vm.PassportCopy;
                buyerDocuments.DrivingLicenceWithDob = vm.DrivingLicenceWithDob;
                buyerDocuments.VotersId = vm.VotersId;
                buyerDocuments.ElectricityBill = vm.ElectricityBill;
                buyerDocuments.TelephoneBill = vm.TelephoneBill;
                buyerDocuments.LeaveLicenceAggrCopy = vm.LeaveLicenceAggrCopy;
                buyerDocuments.CompanyAccoLetter = vm.CompanyAccoLetter;
                buyerDocuments.OtherBankStatmnt = vm.OtherBankStatmnt;
                buyerDocuments.TelephoneProof = vm.TelephoneProof;
                buyerDocuments.AadharCardCopy = vm.AadharCardCopy;
                buyerDocuments.AddressDetailId = vm.AddressProofDetailId;
                //Application Form Details
                buyerDocuments.ApplicationFormImaging = vm.ApplicationFormImaging;
                buyerDocuments.ApplicationFormDetailId = vm.ApplicationFormDetailId;
                //Income Proof
                buyerDocuments.Form16 = vm.Form16;
                buyerDocuments.AppointmentLetter = vm.AppointmentLetter;
                buyerDocuments.SalarySlip = vm.SalarySlip;
                buyerDocuments.Itr = vm.Itr;
                buyerDocuments.GstCertification = vm.GstCertification;
                buyerDocuments.IncomeProofDetailId = vm.IncomeProofDetailId;
                //Bank Statement
                buyerDocuments.BankStatementDetailId = vm.BankStatementDetailId;
                buyerDocuments.BankStatementLatestSixMonths = vm.BankStatementLatestSixMonths;
                buyerDocuments.BankStatmentThreeMonths = vm.BankStatmentThreeMonths;
                buyerDocuments.BankStatementYear = vm.BankStatementYear;
                //Identity Proof
                buyerDocuments.VotersIdCard = vm.VotersIdCard;
                buyerDocuments.IdentityProofDetailId = vm.IdentityProofDetailId;
                //Profile Documents
                buyerDocuments.PanCardId = vm.PanCardId;
                buyerDocuments.ProfilePhoto = vm.ProfilePhoto;
                buyerDocuments.ProfileDocumentDetailId = vm.ProfileDocumentDetailId;
            }
            else
            {
                var buyerDocChecks = new FileUploadDetails
                {
                    PassportCopy = vm.PassportCopy,
                    DrivingLicenceWithDob = vm.DrivingLicenceWithDob,
                    VotersId = vm.VotersId,
                    ElectricityBill = vm.ElectricityBill,
                    TelephoneBill = vm.TelephoneBill,
                    LeaveLicenceAggrCopy = vm.LeaveLicenceAggrCopy,
                    CompanyAccoLetter = vm.CompanyAccoLetter,
                    OtherBankStatmnt = vm.OtherBankStatmnt,
                    TelephoneProof = vm.TelephoneProof,
                    AadharCardCopy = vm.AadharCardCopy,
                    BuyerId = vm.BuyerId,
                    AddressDetailId = 1,
                    //Application Form Details
                    ApplicationFormImaging = vm.ApplicationFormImaging,
                    ApplicationFormDetailId = 2,
                    //Income Proof
                    Form16 = vm.Form16,
                    AppointmentLetter = vm.AppointmentLetter,
                    SalarySlip = vm.SalarySlip,
                    Itr = vm.Itr,
                    GstCertification = vm.GstCertification,
                    IncomeProofDetailId = 3,
                    //Bank Statement
                    BankStatementDetailId = 4,
                    BankStatementLatestSixMonths = vm.BankStatementLatestSixMonths,
                    BankStatmentThreeMonths = vm.BankStatmentThreeMonths,
                    BankStatementYear = vm.BankStatementYear,
                    //Identity Proof
                    VotersIdCard = vm.VotersIdCard,
                    IdentityProofDetailId = 5,
                    //Profile Documents
                    PanCardId = vm.PanCardId,
                    ProfilePhoto = vm.ProfilePhoto,
                    ProfileDocumentDetailId = 6
                };
                db.BuyerDocuments.Add(buyerDocChecks);
            }
            Comments newcomment = new Comments();
            newcomment.BuyerId = vm.BuyerId;
            newcomment.CommentDetails = vm.PersonalComments;
            newcomment.CommentDateTime = DateTime.Now;

            db.Comments.Add(newcomment);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult DeleteFile(int id)
        {
            try
            {
                var findDoc = db.DocumentUploadeds.Where(x => x.Id == id).FirstOrDefault();
                if (findDoc == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                db.DocumentUploadeds.Remove(findDoc);
                db.SaveChanges();

                var path = Path.Combine(Server.MapPath("~/Content/Files/"), findDoc.FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult openComment(int buyerId)
        {
            var comment = db.Comments.Where(x => x.BuyerId == buyerId).ToList();
            return View("openComment", comment);
        }
    }
}