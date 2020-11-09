using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMasterProject.Models;

namespace TheMasterProject.Controllers
{
    [Authorize]
    public class AssistantManagerController : Controller
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
            var leadList = db.BuyerRelation.Include("BuyerDetail").Include("MemberDetail").Where(m => m.AssistantManagerId == userId).ToList();

            return View(leadList);
        }

        public ActionResult AssignMemberToBuyer(int BuyerId)
        {
            var buyerDetail = db.BuyerRelation.Where(x => x.BuyerId == BuyerId).FirstOrDefault();
            var userId = GetUserId();
            var memberList = db.AssistantManagerToMemberRelations.Include("teamMemberDetails").Where(x => x.AssistantManagerId == userId).ToList();

            List<SelectListItem> MembersList = new List<SelectListItem>();
            foreach (var member in memberList)
            {
                MembersList.Add(new SelectListItem
                {
                    Text = member.teamMemberDetails.FirstName,
                    Value = member.TeamMemberId
                });
            }
            ViewBag.MemerList = MembersList;

            return PartialView("AssignMemberToBuyerPartial", buyerDetail);
        }

        [HttpPost]
        public ActionResult AssignMemberToBuyer(BuyerRelation relation)
        {
            var userId = GetUserId();
            var currentLeadDetails = db.BuyerRelation.Where(b => b.BuyerId == relation.BuyerId).FirstOrDefault();
            var validLead = db.BuyerRelation.Where(b => b.AssistantManagerId == userId && b.BuyerId == relation.BuyerId).FirstOrDefault();
            if (validLead == null)
            {
                currentLeadDetails.MemberId = null;
                db.SaveChanges();

                return View("Error");
            }
            else
            {
                var CurrentMemberAssigned = db.AssistantManagerToMemberRelations.Where(m => m.TeamMemberId == relation.MemberId && m.AssistantManagerId == userId).FirstOrDefault();
                if (CurrentMemberAssigned != null)
                {
                    currentLeadDetails.MemberId = relation.MemberId;
                }
                else
                {
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