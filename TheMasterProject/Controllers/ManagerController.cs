using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMasterProject.Models;

namespace TheMasterProject.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public string GetUserId()
        {
            var userId = Session["UserId"].ToString();
            return userId;
        }

        public ActionResult Index()
        {
            var userId = GetUserId();
            var leadList = db.BuyerRelation.Include("BuyerDetail").Include("AMDetail").Where(m => m.ManagerId == userId).ToList();
            ViewBag.TotalLeads = leadList.Count();
            ViewBag.CompletedLeads = leadList.Where(x => x.BuyerDetail.currenStatus == Convert.ToString(TheMasterProject.Enum.LeadStatus.Completed)).Count();
            return View(leadList);
        }

        public ActionResult AssignAMToBuyer(int BuyerId)
        {
            var buyerDetail = db.BuyerRelation.Where(x => x.BuyerId == BuyerId).FirstOrDefault();
            var userId = GetUserId();
            var AmList = db.ManagerToAmRelations.Include("assistantManagerDetails").Where(x => x.ManagerId == userId).ToList();

            List <SelectListItem> AssistantManagerList = new List<SelectListItem>();
            foreach(var ams in AmList)
            {
                AssistantManagerList.Add(new SelectListItem
                {
                    Text = ams.assistantManagerDetails.FirstName,
                    Value = ams.AssitantManagerId
                });
            }
            ViewBag.AssistantManagers = AssistantManagerList;

            return PartialView("AssignAMToBuyerPartial", buyerDetail);
        }

        [HttpPost]
        public ActionResult AssignAMToBuyer(BuyerRelation relation)
        {
            var userId = GetUserId();
            var currentLeadDetails = db.BuyerRelation.Where(b => b.BuyerId == relation.BuyerId).FirstOrDefault();
            var validLead = db.BuyerRelation.Where(b => b.ManagerId == userId && b.BuyerId == relation.BuyerId).FirstOrDefault();
            if (validLead == null)
            {
                currentLeadDetails.AssistantManagerId = null;
                currentLeadDetails.MemberId = null;
                db.SaveChanges();
                
                return View("Error");
            }
            else
            {
                var CurrentAmAssigned = db.ManagerToAmRelations.Where(m => m.AssitantManagerId == relation.AssistantManagerId && m.ManagerId == userId).FirstOrDefault();
                if (CurrentAmAssigned != null)
                {
                    currentLeadDetails.AssistantManagerId = relation.AssistantManagerId;
                }
                else
                {
                    currentLeadDetails.AssistantManagerId = null;
                    currentLeadDetails.MemberId = null;
                    db.SaveChanges();

                    return View("Error");
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}