using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheMasterProject.ViewModels;

namespace TheMasterProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        
        [Display(Name = "Living In")]
        public string CurrentlyLivingIn { get; set; }

        
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        
        [Display(Name = "Aadhar Card")]
        public int AadharCard { get; set; }

        
        [Display(Name = "Pincode")]
        public int pincode { get; set; }

        
        [Display(Name = "Phone No")]
        public int MobileNo { get; set; }

        public string LeadAssigned { get; set; }
        
        [Display(Name = "User Type")]
        public int UserType { get; set; }

        
        public int UserRole { get; set; } = 1;
        
        public int LeadCreated { get; set; }
        [NotMapped]
        public string FullName {
            get
            {
                return FirstName +" "+ LastName;
            }
            set
            {

            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string rolename) : base(rolename) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DealerToLeadRelation> DealerLeadRelations { get; set; }
        public DbSet<DealerToManagerRelation> DealerToManagerRelations { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<AppointmentDetails> AppointmentDetails { get; set; }
        public DbSet<DocumentUploaded> DocumentUploadeds { get; set; }
        public DbSet<FileUploadDetails> BuyerDocuments { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ManagerToAmRelation> ManagerToAmRelations { get; set; }
        public DbSet<BuyerRelationMember> BuyerMemberRelation { get; set; }
        public DbSet<BuyerRelation> BuyerRelation { get; set; }
        public DbSet<Buyer_Detail> BuyerDetails { get; set; }     
        public DbSet<ProjectLeadDetails> ProjectLeadDetails { get; set; }
        public DbSet<UserDetails> UserMaster { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }
        public DbSet<Lead_Member_Relation> LeadMemberRelation { get; set; }
        public DbSet<AssistantManagerToMemberRelation> AssistantManagerToMemberRelations { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}