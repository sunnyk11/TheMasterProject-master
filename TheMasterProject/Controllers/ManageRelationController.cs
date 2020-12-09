using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMasterProject.Models;

namespace TheMasterProject.Controllers
{
    [Authorize]
    public class ManageRelationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var managerDetails = db.Users.Where(u => u.UserType == 1).ToList();
            List<ManagerRelationViewModel> relation = new List<ManagerRelationViewModel>();
            
            var asslist = (from am in db.ManagerToAmRelations
                           group am by am.ManagerId into g
                           select new
                           {
                               ManagerId = g.Select(x => x.ManagerId).FirstOrDefault(),
                               ManagerEmail = g.Select(x => x.managerDetails.Email).FirstOrDefault(),
                               ManagerName = g.Select(x => x.managerDetails.FirstName).FirstOrDefault(),
                               AssistantManagerName = g.Select(y => y.assistantManagerDetails.FirstName)
                           }).ToList();

            foreach(var list in asslist)
            {
                relation.Add(new ManagerRelationViewModel
                {
                    ManagerId = list.ManagerId,
                    ManagerEmail = list.ManagerEmail,
                    ManagerName = list.ManagerName,
                    AssistantManagerName = string.Join(" | ", list.AssistantManagerName)
                });
            }

            ViewBag.assistantManager = relation;
            return View(managerDetails);
        }

        public ActionResult AssignManagerToDealer(string DealerEmail)
        {
            var ManagerList = db.Users.Where(u => u.UserType == 1).ToList();
            var dealerDetail = db.Users.Where(x => x.Email == DealerEmail).FirstOrDefault();

            List<SelectListItem> managerList = new List<SelectListItem>();


            foreach (var item in ManagerList)
            {
                managerList.Add(new SelectListItem
                {
                    Text = item.FirstName,
                    Value = item.Id
                });
            }

            ViewBag.Manager = managerList;

            return PartialView("AssignManagerToDealerPartial", dealerDetail);
        }

        [HttpPost]
        public ActionResult AssignManagerToDealer(ApplicationUser model)
        {
            try
            {
                var dealer = db.DealerToManagerRelations.Where(x => x.DealerId == model.Id).FirstOrDefault();

                if (dealer.ManagerId == null)
                {

                    /* This part is used to assign manager to leads created by dealer */
                    var LeadByDealer = db.DealerLeadRelations.Where(x => x.LeadCreatedBy == model.Id).ToList();

                    var buyerRelation = db.BuyerRelation.ToList();
                    var buyerDetails = db.BuyerDetails.Where(x => x.LeadCreatedBy == dealer.DealerId).ToList();

                    foreach(var buyerDetail in buyerDetails)
                    {
                        buyerDetail.ManagerAssigned = model.LeadAssigned;
                        buyerDetail.LeadIncomingFrom = TheMasterProject.Enum.LeadComingFrom.Dealer.ToString();
                        db.Entry(buyerDetail).Property(x => x.ManagerAssigned).IsModified = true;
                    }

                    foreach(var item in LeadByDealer)
                    {
                        foreach (var buyer in buyerRelation)
                        {
                            if(item.BuyerId == buyer.BuyerId)
                            {
                                buyer.ManagerId = model.LeadAssigned;
                                buyer.UpdatedOn = DateTime.Now;
                                db.Entry(buyer).Property(x => x.ManagerId).IsModified = true;
                            }
                        }
                        item.AssignedManager = model.LeadAssigned;
                        db.Entry(item).Property(x => x.AssignedManager).IsModified = true;
                    }

                    //Below is used to assign manager to dealer to manager relations
                    dealer.ManagerId = model.LeadAssigned;
                }
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }

        }

        public ActionResult AssignAssistantManager(string managerId)
        {
            var assistantManagerList = db.Users.Where(u => u.UserType == 2).ToList();
            List<SelectListItem> AssitantManagerList = new List<SelectListItem>();
            ManagerRelationViewModel mr = new ManagerRelationViewModel();

            foreach(var item in assistantManagerList)
            {
                AssitantManagerList.Add(new SelectListItem
                {
                    Text = item.FirstName,
                    Value = item.Id
                });
            }

            mr.ManagerName = db.Users.Where(u => u.Email == managerId).Select(n => n.FirstName).FirstOrDefault();
            ViewBag.assistantManager = AssitantManagerList;
            mr.ManagerId = db.Users.Where(u => u.Email == managerId).Select(i => i.Id).FirstOrDefault();

            return PartialView("AssignAmToManagerPartial", mr);
        }

        [HttpPost]
        public ActionResult AssignAssistantManager(ManagerRelationViewModel relation)
        {
            try
            {
                var managerassigned = db.ManagerToAmRelations.Where(x => x.managerDetails.Email == relation.ManagerId && x.AssitantManagerId == null).FirstOrDefault();

                var managerId = db.Users.Where(u => u.Email == relation.ManagerId).Select(i => i.Id).FirstOrDefault();
                bool value = db.ManagerToAmRelations.Any(x => x.ManagerId == managerId && x.AssitantManagerId == relation.AssistantManagerId);

                ManagerToAmRelation mr = new ManagerToAmRelation();

                if (managerassigned != null)
                {
                    managerassigned.AssitantManagerId = relation.AssistantManagerId;
                }
                else if (value != true)
                {
                    mr.ManagerId = managerId;
                    mr.AssitantManagerId = relation.AssistantManagerId;
                    db.ManagerToAmRelations.Add(mr);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View("Error");
            }
            
        }

        public ActionResult DeleteAssistantManager(string managerId)
        {
            var assistantManagerList = db.ManagerToAmRelations.Include("assistantManagerDetails").Where(m => m.managerDetails.Email == managerId).ToList();
            List<SelectListItem> AssitantManagerList = new List<SelectListItem>();
            ManagerRelationViewModel mr = new ManagerRelationViewModel();

            foreach (var item in assistantManagerList)
            {
                AssitantManagerList.Add(new SelectListItem
                {
                    Text = item.assistantManagerDetails.FirstName,
                    Value = item.AssitantManagerId
                });
            }

            ViewBag.assistantManager = AssitantManagerList;
            mr.ManagerName = db.Users.Where(u => u.Email == managerId).Select(n => n.FirstName).FirstOrDefault();
            mr.ManagerId = db.Users.Where(i => i.Email == managerId).Select(id => id.Id).FirstOrDefault();

            return PartialView("DeleteAssistantManagerPartial", mr);
        }

        [HttpPost]
        public ActionResult DeleteAssistantManager(ManagerRelationViewModel relation)
        {
            ManagerToAmRelation am = db.ManagerToAmRelations.Where(u => u.managerDetails.Email == relation.ManagerId && u.AssitantManagerId == relation.AssistantManagerId).FirstOrDefault();

            if(am != null)
            {
                db.ManagerToAmRelations.Remove(am);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AssistantManagerIndex()
        {
            var assistantManagerDetails = db.Users.Where(u => u.UserType == 2).ToList();
            List<AssistantManagerToMemberViewModel> relation = new List<AssistantManagerToMemberViewModel>();

            var asslist = (from am in db.AssistantManagerToMemberRelations
                           group am by am.AssistantManagerId into g
                           select new
                           {
                               AssistantManagerId = g.Select(x => x.AssistantManagerId).FirstOrDefault(),
                               AssistantManagerEmail = g.Select(x => x.assistantManagerDetails.Email).FirstOrDefault(),
                               AssistantManagerName = g.Select(x => x.assistantManagerDetails.FirstName).FirstOrDefault(),
                               TeamMemberName = g.Select(y => y.teamMemberDetails.FirstName)
                           }).ToList();

            foreach (var list in asslist)
            {
                relation.Add(new AssistantManagerToMemberViewModel
                {
                    AssistantManagerId = list.AssistantManagerId,
                    AssistantManagerEmail = list.AssistantManagerEmail,
                    AssistantManagerName = list.AssistantManagerName,
                    TeamMemberName = string.Join(" | ", list.TeamMemberName)
                });
            }

            ViewBag.teamMembers = relation;
            return View(assistantManagerDetails);
        }

        public ActionResult AssignTeamMember(string assistantManagerEmail)
        {
            var teamMemberList = db.Users.Where(u => u.UserType == 3).ToList();
            List<SelectListItem> TeamMemberList = new List<SelectListItem>();
            AssistantManagerToMemberViewModel mr = new AssistantManagerToMemberViewModel();

            foreach (var item in teamMemberList)
            {
                TeamMemberList.Add(new SelectListItem
                {
                    Text = item.FirstName,
                    Value = item.Id
                });
            }

            mr.AssistantManagerName = db.Users.Where(u => u.Email == assistantManagerEmail).Select(n => n.FirstName).FirstOrDefault();
            ViewBag.teammember = TeamMemberList;
            mr.AssistantManagerId = db.Users.Where(u => u.Email == assistantManagerEmail).Select(i => i.Id).FirstOrDefault();

            return PartialView("AssignMemberToAM", mr);
        }

        [HttpPost]
        public ActionResult AssignTeamMember(AssistantManagerToMemberViewModel relation)
        {
            try
            {
                var assistangManagerAsssigned = db.AssistantManagerToMemberRelations.Where(x => x.AssistantManagerId == relation.AssistantManagerId && x.TeamMemberId == null).FirstOrDefault();

                bool value = db.AssistantManagerToMemberRelations.Any(x => x.AssistantManagerId == relation.AssistantManagerId && x.TeamMemberId == relation.TeamMemberId);
                AssistantManagerToMemberRelation amr = new AssistantManagerToMemberRelation();

                if (assistangManagerAsssigned != null)
                {
                    assistangManagerAsssigned.TeamMemberId = relation.TeamMemberId;
                }
                else if(value != true)
                {
                    amr.AssistantManagerId = relation.AssistantManagerId;
                    amr.TeamMemberId = relation.TeamMemberId;
                    db.AssistantManagerToMemberRelations.Add(amr);
                }

                db.SaveChanges();
                return RedirectToAction("AssistantManagerIndex");
            }
            catch(Exception e)
            {
                return View("Error");
            }
            
        }

        public ActionResult DeleteTeamMember(string assistantManagerEmail)
        {
            var teamMemberList = db.AssistantManagerToMemberRelations.Include("teamMemberDetails").Where(m => m.assistantManagerDetails.Email == assistantManagerEmail).ToList();
            List<SelectListItem> teamMembers = new List<SelectListItem>();
            AssistantManagerToMemberViewModel mr = new AssistantManagerToMemberViewModel();

            foreach (var item in teamMemberList)
            {
                teamMembers.Add(new SelectListItem
                {
                    Text = item.teamMemberDetails.FirstName,
                    Value = item.TeamMemberId
                });
            }

            ViewBag.teamMembersList = teamMembers;
            mr.AssistantManagerName = db.Users.Where(u => u.Email == assistantManagerEmail).Select(n => n.FirstName).FirstOrDefault();
            mr.AssistantManagerId = db.Users.Where(u => u.Email == assistantManagerEmail).Select(i => i.Id).FirstOrDefault();

            return PartialView("DeleteTeamMemberPartial", mr);
        }

        [HttpPost]
        public ActionResult DeleteTeamMember(AssistantManagerToMemberViewModel relation)
        {
            AssistantManagerToMemberRelation am = db.AssistantManagerToMemberRelations.Where(u => u.AssistantManagerId == relation.AssistantManagerId && u.TeamMemberId == relation.TeamMemberId).FirstOrDefault();
            if (am != null)
            {
                db.AssistantManagerToMemberRelations.Remove(am);
            }
            db.SaveChanges();

            return RedirectToAction("AssistantManagerIndex");
        }

    }
}