using HospitalProject_Team4.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HospitalProject_Team4.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //A logged in user could be a donor
        public virtual Donation donor { get; set; }

        //A logged in user could be an volunteer
        public virtual VolunteerRecruitment volunteer { get; set; }


        //A logged in user will be an admin for FAQ Frequently Asked Question
        public bool IsAdmin { get; set; }

    }
    public class HospitalProjectContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalProjectContext() : base("name=HospitalProjectContext")
        {
        }
        public static HospitalProjectContext Create()
        {
            return new HospitalProjectContext();
        }

        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.Donation> Donation { get; set; }
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.FAQ> FAQs { get; set; }

        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.VolunteerRecruitment> volunteerRecruitment { get; set; }
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.Feedback> Feedbacks { get; set; }
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.MessageCategory> MessageCategories { get; set; }
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.ContactUs> ContactUs { get; set; }

        //Tables for job posting feature
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.Application> Applications { get; set; }
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.JobPosting> JobPostings { get; set; }
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.Department> Departments { get; set; }
        //Tables for parking spot booking system
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.ParkingSpot> ParkingSpots { get; set; }
        public System.Data.Entity.DbSet<HospitalProject_Team4.Models.SpotBooking> SpotBookings { get; set; }
    }
}