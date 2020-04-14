using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HospitalProject_Team4.Data;
using HospitalProject_Team4.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HospitalProject_Team4.Controllers
{
    public class JobsController : Controller
    {
        //Reference user application
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: List of all jobs (public)
        public ActionResult List()
        {
            //write SQL query
            string query = "SELECT * FROM JobPostings jp INNER JOIN Departments d ON jp.DepartmentID = d.DepartmentID";
            //Catch all of the results of that query in a list
            List<JobPosting> jobpostings = db.JobPostings.SqlQuery(query).ToList();
            //print out the results to the view
            return View(jobpostings);
        }

        //GET: List of all jobs (public)
        //Call the AdminList function which will do the same as above,
        //AdminList displays all of the job postings in a table with edit/delete options
        public ActionResult AdminList(string jobsearchkey)
        {
            //write SQL query
            string query = "SELECT * FROM JobPostings jp INNER JOIN Departments d ON jp.DepartmentID = d.DepartmentID";
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            //Next we pass through our search key and use it with an if statement
            if (jobsearchkey != "")
            {
                query = query + "WHERE location like @searchkey";
                //create new parameter for searchkey value
                sqlparams.Add(new SqlParameter("@searchkey", "%" + jobsearchkey + "%"));
                //Write a debug line to make sure our SQL query is written correctly
                Debug.WriteLine("The query is " + query);
            }
            //Catch all of the results of that query in a list
            List<JobPosting> jobpostings = db.JobPostings.SqlQuery(query).ToList();
            //print out the results to the view
            return View(jobpostings);
        }

        //GET: Individual job post information (PUBLIC)
        //There is a public and admin view for both of these things - the public can see more details, and the admin sees the option to delete/edit
        //The below Show method is for the public view, not the admin view
        public ActionResult Show(int id)
        {
            //Write the query
            string query = "SELECT * FROM JobPostings jp INNER JOIN Departments d ON jp.DepartmentID = d.DepartmentID WHERE PostingID = @postid";
            //Pass through the id as a parameter into the SQL for security
            var parameter = new SqlParameter("@postid", id);
            //Execute the query
            JobPosting jobpost = db.JobPostings.SqlQuery(query, parameter).FirstOrDefault();
            //Catch the results and return them to the view
            return View(jobpost);
        }

        //GET: Individual job post information (ADMIN)
        //The below AdminShow method is for the admin view, not accessible to the public
        public ActionResult AdminShow(int id)
        {
            //Write the query
            string query = "SELECT * FROM JobPostings jp INNER JOIN Departments d ON jp.DepartmentID = d.DepartmentID WHERE PostingID = @postid";
            //Pass through the id as a parameter into the SQL for security
            var parameter = new SqlParameter("@postid", id);
            //Execute the query
            JobPosting jobpost = db.JobPostings.SqlQuery(query, parameter).FirstOrDefault();
            //Catch the results and return them to the view
            return View(jobpost);
        }

        //SET: Adding a new job post (ADMIN)
        public ActionResult New()
        {
            return View();
        }
        // Method for after the new post form has been filled out and submitted
        [HttpPost]
        public ActionResult New(string JobTitle, int DepartmentID, DateTime AppDeadline, string AppAccept, string JobDesc)
        {
            //Write the query
            string query = "INSERT into JobPostings (JobTitle, JobDescription, Accepter, ApplicationDeadline, DepartmentID) values (@jobtitle, @jobdesc, @accepter, @appdeadline, @departmentid)";
            //Declare the parameters that we will pass through the query
            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@jobtitle", JobTitle);
            sqlparams[1] = new SqlParameter("@jobdesc", JobDesc);
            sqlparams[2] = new SqlParameter("@accepter", AppAccept);
            sqlparams[3] = new SqlParameter("@appdeadline", AppDeadline);
            sqlparams[4] = new SqlParameter("@departmentid", DepartmentID);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("AdminList");
        }

        //SET: Setting a new application (ADMIN)
        public ActionResult Apply()
        {
            return View();
        }
        // Method for after the application form has been filled out and submitted
        [HttpPost]
        public ActionResult Apply(string Name, string Email, string Phone, string FormerEmployer, string Ref1Name, string Ref1Email, string Ref2Name, string Ref2Email, string Ref3Name, string Ref3Email, Boolean Resume)
        {
            //Write the query
            string query = "INSERT into Applications (Name, Email, Phone, FormerEmployer, Reference1_Name, Reference1_Email, Reference2_Name, Reference2_Email, Reference3_Name, Reference3_Email, Resume)" +
                "values (@name, @email, @phone, @formeremploy, @ref1name, @ref1email, @ref2name, @ref2email, @ref3name, @ref3email, @resume)";
            //Declare the parameters that we will pass through the query
            SqlParameter[] sqlparams = new SqlParameter[11];
            sqlparams[0] = new SqlParameter("@name", Name);
            sqlparams[1] = new SqlParameter("@email", Email);
            sqlparams[2] = new SqlParameter("@phone", Phone);
            sqlparams[3] = new SqlParameter("@formeremploy", FormerEmployer);
            sqlparams[4] = new SqlParameter("@ref1name", Ref1Name);
            sqlparams[5] = new SqlParameter("@ref1email", Ref1Email);
            sqlparams[6] = new SqlParameter("@ref2name", Ref2Name);
            sqlparams[7] = new SqlParameter("@ref2email", Ref2Email);
            sqlparams[8] = new SqlParameter("@ref3name", Ref3Name);
            sqlparams[9] = new SqlParameter("@ref3email", Ref3Email);
            sqlparams[10] = new SqlParameter("@resume", Resume);
            //Execute SQL and redirect back to public list
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }

        //SET: Update a job posting (admin only)
        public ActionResult Update(int? id)
        {
            //Write the query & parameter for the query
            string query = "SELECT * from JobPostings WHERE PostingID = @postid";
            SqlParameter sqlparams = new SqlParameter("@postid", id);
            //Execute and return the form view
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return View();
        }
        // Method for after the update form has been filled out and submitted
        [HttpPost]
        public ActionResult update(int id, string JobTitle, int DepartmentID, DateTime AppDeadline, string AppAccept, string JobDesc)
        {
            //Write the query
            string query = "UPDATE JobPostings SET JobTitle = @jobtitle, JobDescription = @jobdesc, Accepter = @accepter, ApplicationDeadline = @appdeadline, DepartmentID = @departmentid WHERE PostingID = @postid";
            //Declare the parameters that we will pass through the query
            SqlParameter[] sqlparams = new SqlParameter[6];
            sqlparams[0] = new SqlParameter("@jobtitle", JobTitle);
            sqlparams[1] = new SqlParameter("@jobdesc", JobDesc);
            sqlparams[2] = new SqlParameter("@accepter", AppAccept);
            sqlparams[3] = new SqlParameter("@appdeadline", AppDeadline);
            sqlparams[4] = new SqlParameter("@departmentid", DepartmentID);
            sqlparams[5] = new SqlParameter("@postid", id);
            //Execute the query and return back to the admin list of all job postings
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("AdminList");
        }

        //SET delete a job posting (admin)
        public ActionResult Delete(int id)
        {
            //Write the query
            string query = "DELETE from JobPostings where PostingID = @postid";
            //Create the parameter
            SqlParameter sqlparams = new SqlParameter("@postid", id);
            //Execute and redirect back to the AdminList page
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("AdminList");
        }
    }
}