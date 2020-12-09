using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TheMasterProject.Models;
using TheMasterProject.Models.IdentityModel;

namespace TheMasterProject.Controllers
{
    [Authorize]
    public class UserDetailController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.BuyerDetails.Include("ManagerDetail").ToList();
            ViewBag.TotalLeads = list.Count();
            ViewBag.DealerLeads = list.Where(x => x.LeadCreatedBy != null).Count();
            ViewBag.CompletedLeads = list.Where(x => x.currenStatus == Convert.ToString(TheMasterProject.Enum.LeadStatus.Completed)).Count();
            return View(list);
        }

        public ActionResult AssignLeadToManager(int BuyerId)
        {
            List<SelectListItem> Managers = new List<SelectListItem>();
            var list = db.BuyerDetails.Find(BuyerId);
            var managerlist = db.Users.Where(x => x.UserType == 1).ToList();
            foreach (var item in managerlist)
            {
                Managers.Add(new SelectListItem
                {
                    Text = item.FirstName,
                    Value = item.Id
                });
            }
            ViewBag.Managers = Managers;
            return PartialView("AssignLeadToManagerPartial", list);
        }

        [HttpPost]
        public ActionResult AssignLeadToManager(Buyer_Detail bd)
        {
            try
            {
                Buyer_Detail BuyerDetail = new Buyer_Detail();
                BuyerRelation BuyerRelation = new BuyerRelation();

                var currentBuyerDetail = db.BuyerDetails.FirstOrDefault(b => b.BuyerId == bd.BuyerId);
                if (currentBuyerDetail == null)
                    return HttpNotFound();
                currentBuyerDetail.ManagerAssigned = bd.ManagerAssigned;
                
                var currentBuyerRelation = db.BuyerRelation.FirstOrDefault(b => b.BuyerId == bd.BuyerId);
                if (currentBuyerRelation == null)
                {
                    BuyerRelation.BuyerId = bd.BuyerId;
                    BuyerRelation.ManagerId = bd.ManagerAssigned;
                    BuyerRelation.UpdatedOn = DateTime.Now;
                    db.BuyerRelation.Add(BuyerRelation);
                }
                else
                {
                    currentBuyerRelation.ManagerId = bd.ManagerAssigned;
                    currentBuyerRelation.UpdatedOn = DateTime.Now;
                    currentBuyerRelation.AssistantManagerId = null;
                    currentBuyerRelation.MemberId = null;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        //This Function is still under construction
        public ActionResult ViewLeadDetails(int BuyerId)
        {
            var list = db.BuyerDetails.Find(BuyerId);
            var userlist = db.BuyerRelation.Include("ManagerDetail").Include("AMDetail").Include("MemberDetail").Where(x => x.BuyerId == BuyerId).OrderByDescending(x => x.UpdatedOn).FirstOrDefault();

            ViewBag.leadDetails = userlist;
            return PartialView("DetailsPartial", list);
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult UploadExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadExcel(HttpPostedFileBase FileUpload)
        {
            string data = "";
            if (FileUpload != null)
            {
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;

                    if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
                    {
                        string targetpath = Server.MapPath("~/Content/Doc");
                        FileUpload.SaveAs(targetpath + filename);
                        string pathToExcelFile = targetpath + filename;

                        string sheetName = "Sheet1";

                        var excelFile = new ExcelQueryFactory(pathToExcelFile);
                        var empDetails = from a in excelFile.Worksheet<Buyer_Detail>(sheetName) select a;
                        foreach (var a in empDetails)
                        {
                            if (a.BuyerName != null && a.MobileNo != null)
                            {

                                int resullt = PostExcelData(a.BuyerName, a.MobileNo);
                                if (resullt <= 0)
                                {
                                    data = "Hello User, Found some duplicate values! Only unique employee were inserted";
                                    ViewBag.Message = data;
                                    continue;
                                }
                                else
                                {
                                    data = "Successful uploaded records";
                                    ViewBag.Message = data;
                                }
                            }

                            else
                            {
                                
                                ViewBag.Message = data;
                                return View("UploadExcel");
                            }

                        }
                    }

                    else
                    {
                        data = "This file is not valid format";
                        ViewBag.Message = data;
                    }
                    return View("UploadExcel");

                }
                else
                {

                    data = "Only Excel file format is allowed";

                    ViewBag.Message = data;
                    return View("UploadExcel");

                }

            }
            else
            {

                if (FileUpload == null)
                {
                    data = "Please choose Excel file";
                }

                ViewBag.Message = data;
                return View("UploadExcel");

            }
        }

        public int PostExcelData(string BuyerName, string MobileNo)
        {
            Buyer_Detail bd = new Buyer_Detail();
            int val = 0;
            var alreadyBuyer = db.BuyerDetails.Where(x => x.MobileNo == MobileNo).FirstOrDefault();
            if(alreadyBuyer == null)
            {
                bd.BuyerName = BuyerName;
                bd.LeadIncomingFrom = TheMasterProject.Enum.LeadComingFrom.Excel.ToString();
                bd.MobileNo = MobileNo;
                db.BuyerDetails.Add(bd);
                val = 1;
            }
            else
            {
                val = -1;
            }
           
            db.SaveChanges();
            return val;
        }

        public ActionResult DealerDetail()
        {
            var dealerDetail = db.Users.Where(x => x.UserType == 5).ToList();
            
            List<DealerToManagerViewModel> relation = new List<DealerToManagerViewModel>();

            var managerDetails = (from m in db.DealerToManagerRelations
                                  join d in db.Users on m.ManagerId equals d.Id
                                  select new
                                  {
                                      m.DealerId,
                                      m.ManagerId,
                                      m.ManagerDetails.FirstName
                                  }).ToList();
            foreach(var item in managerDetails)
            {
                relation.Add(new DealerToManagerViewModel
                {
                    DealerId = item.DealerId,
                    ManagerId = item.ManagerId,
                    ManagerName = item.FirstName
                });
            }
            ViewBag.ManagerDetails = relation;

            return View(dealerDetail);
        }
    }
}
