using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMasterProject.Models;
using TheMasterProject.ViewModels;

namespace TheMasterProject.Controllers
{
    public class DealerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public string GetUserId()
        {
            var userId = Session["UserId"].ToString();
            return userId;
        }
        public ActionResult Index()
        {
            string userId = Session["UserId"].ToString(); ;
            ViewBag.ManagerAssigned = db.DealerToManagerRelations.Include("ManagerDetails").Where(x => x.DealerId == userId).FirstOrDefault();

            var model = db.DealerLeadRelations.Include("ManagerDetails").Where(x => x.LeadCreatedBy == userId || x.LeadVerifiedBy == userId).ToList();
            return View(model);
        }

        public JsonResult GetCityList(int StateId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<City> CityList = db.City.Where(x => x.StateCode == StateId).ToList();
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddLeadDetail()
        {
            List<State> StateList = db.States.ToList();
            ViewBag.StateList = new SelectList(StateList, "StateCode", "StateName");
            ViewBag.OfficeStateList = new SelectList(StateList, "StateCode", "StateName");

            ViewBag.Message = TempData["ErrorMessage"];

            
            return View();
        }
        
        [HttpPost]
        public ActionResult AddLeadDetail(NewBuyerViewModel model)
        {
            var currentUser = GetUserId();
            var userDetails = db.BuyerDetails.ToList();
            bool isValid = true;

            if(model.MobileNo != null || model.AadharCard != null || model.PanCard != null)
            {
                foreach (var item in userDetails)
                {
                    if (item.AadharCard == model.AadharCard)
                    {
                        isValid = false;
                    }
                    if (item.PanCard == model.PanCard)
                    {
                        isValid = false;
                    }
                    if (item.MobileNo == model.MobileNo)
                    {
                        isValid = false;
                    }
                }
            }

            if (!isValid)
            {
                var getBuyerDetails = db.BuyerDetails.Include("ManagerDetail").Where(x => x.MobileNo == model.MobileNo || x.AadharCard == model.AadharCard || x.PanCard == model.PanCard).FirstOrDefault();

                var addLeadToDealer = new DealerToLeadRelation
                {
                    BuyerId = getBuyerDetails.BuyerId,
                    PhoneNo = getBuyerDetails.MobileNo,
                    BuyerName = getBuyerDetails.BuyerName,
                    AadharCard = getBuyerDetails.AadharCard,
                    PanCard = getBuyerDetails.PanCard,
                    WillGetPayout = false,
                    LeadCreatedOn = DateTime.Now,
                    LeadStatus = getBuyerDetails.currenStatus,
                    LeadVerifiedBy = GetUserId()
                };
                if(getBuyerDetails.ManagerDetail != null)
                {
                    addLeadToDealer.AssignedManager = getBuyerDetails.ManagerDetail.Id;
                }

                var DealerToLeadDetails = db.DealerLeadRelations.Where(x => x.BuyerId == getBuyerDetails.BuyerId).FirstOrDefault();
                if(DealerToLeadDetails.LeadVerifiedBy != currentUser)
                {
                    db.DealerLeadRelations.Add(addLeadToDealer);
                }
                db.SaveChanges();
                
                TempData["ErrorMessage"] = "The Lead you are trying To add already exists in our database. You wont be able to view complete details of the user. " + 
                                        "You can check your Dashboard Page. The lead will be shown to your list but you wont be able to view complete details";
                
                return RedirectToAction("AddLeadDetail",model);
            }

            if (ModelState.IsValid)
            {
                var currentDealer = GetUserId();
                var getManager = db.DealerToManagerRelations.Where(x => x.DealerId == currentDealer).Select(x => x.ManagerId).FirstOrDefault();

                var buyer = new Buyer_Detail
                {
                    BuyerName = model.BuyerName,
                    AadharCard = model.AadharCard,
                    PanCard = model.PanCard,
                    MobileNo = model.MobileNo,
                    ManagerAssigned = getManager,
                    LeadCreatedBy = GetUserId()
                };


                db.BuyerDetails.Add(buyer);
                db.SaveChanges();

                var buyerRelation = new BuyerRelation
                {
                    BuyerId = buyer.BuyerId,
                    ManagerId = getManager,
                    UpdatedOn = DateTime.Now

                };
                
                var addLeadToBuyer = new DealerToLeadRelation
                {
                    BuyerId = buyer.BuyerId,
                    BuyerName = buyer.BuyerName,
                    AadharCard = buyer.AadharCard,
                    PanCard = buyer.PanCard,
                    WillGetPayout = true,
                    LeadCreatedOn = DateTime.Now,
                    PhoneNo = buyer.MobileNo,
                    LeadStatus = buyer.currenStatus,
                    AssignedManager = getManager,
                    LeadCreatedBy = GetUserId()
                };

                db.BuyerRelation.Add(buyerRelation);
                db.DealerLeadRelations.Add(addLeadToBuyer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewDetails(int BuyerId)
        {
            var leadDetail = db.DealerLeadRelations.Include("ManagerDetails").Include("TeamMemberDetails").Include("AssistantManagerDetails").Where(x => x.BuyerId == BuyerId).FirstOrDefault();
            
            return PartialView("ViewLeadDetailPartial" , leadDetail);
        }

    }
}