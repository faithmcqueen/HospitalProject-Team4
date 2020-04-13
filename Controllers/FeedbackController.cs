using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using System.Diagnostics;
using HospitalProject_Team4.Models;
using HospitalProject_Team4.Data;

namespace HospitalProject_Team4.Controllers
{
    //I am not using Application user her for now 
    //I am just performing CRUD opertions fot this feature

    public class FeedbackController : Controller
    {
        //create object of database
        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        // GET LIST: Feedbacks
        /* -------------This method is created for logged in admin. Admin can see the list of feedbacks posted by the users in table format -----------*/
        public ActionResult ListOfFeedbacks(string feedbackSearchKey)
        {
            //debug line to test whether we get the input from search key
            Debug.WriteLine("Search keyword is " + feedbackSearchKey);

            //empty variable declaration
            List<Feedback> feedbacks;

            if (feedbackSearchKey != "" && feedbackSearchKey != null)
            {
                //LINQ is used to display the list of contact us

                feedbacks =
                    db.Feedbacks
                    .Where(feedback =>
                        feedback.feedback_date.ToString().Contains(feedbackSearchKey) ||
                        feedback.feedback_subject.Contains(feedbackSearchKey) ||
                        feedback.feedback_message.Contains(feedbackSearchKey)
                     ).ToList();
            }
            else
            {
                feedbacks = db.Feedbacks.ToList();
            }

            return View(feedbacks);
        }

        //ADD: Feedback (this method is used to push data from database in the fields)
        //But here we do not need any data from database to add a new Feedback
        //That's why there is nothing in the Add() method
        /* ----------------This method is created for user whether loggin or not. ----------------*/
        /* ---------------Using this method they can post their feedback --------------*/
        public ActionResult AddFeedback()
        {
            return View();
        }

        //ADD: Feedback (Pull data from form and store in the database)
        //This block of code execute when we click on submit button to add a new Feedback on the URL: /Feedback/Add
        [HttpPost]
        public ActionResult AddFeedback(string first_name, string last_name, string feedback_subject, string feedback_message)
        {
            //STEP-1: Pull data from the arguments of Add Method
            //Debug line to check we are getting correct data from Add method
            Debug.WriteLine("Subject of new feedback is" + feedback_subject);

            //STEP-2: Write SQL Query to insert data in database
            string query = "Insert into Feedbacks (first_name, last_name, feedback_subject, feedback_message, feedback_date)" +
                " values (@first_name, @last_name, @feedback_subject, @feedback_message, @feedback_date)";
            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@first_name", first_name);
            sqlparams[1] = new SqlParameter("@last_name", last_name);
            sqlparams[2] = new SqlParameter("@feedback_subject", feedback_subject);
            sqlparams[3] = new SqlParameter("@feedback_message", feedback_message);
            sqlparams[4] = new SqlParameter("@feedback_date", DateTime.Now.ToString("yyyy-MM-dd"));

            //db.Database.ExecuteSqlCommand will execute "Insert" statement
            db.Database.ExecuteSqlCommand(query, sqlparams);

            //again execute the List mehod to display new list of Feedback
            return RedirectToAction("ListOfFeedbacks");
        }

        // GET: Details of individual Feedback
        /* ------------This method is created for logged in admin-----------------*/
        /* ------------Admin can view the details of a selescted feedback using this method -------------*/
        public ActionResult ShowFeedback(int? id)
        {
            //if id is equal to NULL then, return BadRequest
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Feedback feedback = db.Feedbacks.SqlQuery("select * from Feedbacks where feedback_id=@feedback_id", new SqlParameter("@feedback_id", id)).FirstOrDefault();

            //if there is no feedback then, return HttpNotFound
            if (feedback == null)
            {
                return HttpNotFound();
            }

            return View(feedback);
        }

        public ActionResult UpdateFeedback(int id)
        {
            //select * from feedbacks where feedback_id = @id
            Feedback SelectedFeedback = db.Feedbacks.Find(id);

            return View(SelectedFeedback);

        }

        //Update Feedback in database
        //This block of code execute when we click on submit button to update a feedback on the URL: /Feedback/UpdateFeedback
        /* ----------This method is creted for logged in admin --------------*/
        /* -----------Admin can update the feedback by using this method ----------*/
        [HttpPost]
        public ActionResult UpdateFeedback(int id, string first_name, string last_name, string feedback_subject, string feedback_message, string feedback_date)
        {
            //query to update feedback in database
            string query = "Update Feedbacks set first_name = @first_name, last_name = @last_name, feedback_subject = @feedback_subject, feedback_message = @feedback_message, feedback_date = @feedback_date where feedback_id = @id";

            //check the update query
            Debug.WriteLine(query);

            SqlParameter[] sqlparams = new SqlParameter[6];//0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@id", id);
            sqlparams[1] = new SqlParameter("@first_name", first_name);
            sqlparams[2] = new SqlParameter("@last_name", last_name);
            sqlparams[3] = new SqlParameter("@feedback_subject", feedback_subject);
            sqlparams[4] = new SqlParameter("@feedback_message", feedback_message);
            sqlparams[5] = new SqlParameter("@feedback_date", DateTime.Now.ToString("yyyy-MM-dd"));


            //db.Database.ExecuteSqlCommand will execute "Update" statement
            db.Database.ExecuteSqlCommand(query, sqlparams);

            //this statement will execute the "List" method and provide updated List of Feedbacks
            return RedirectToAction("ListOfFeedbacks");
        }

        //Delete Feedback
        //GET Data of selected Feedback
        /* ---------This method is created for logged in admin---------*/
        /*-----------Admin can delete the selected feedback using this method -------------*/
        public ActionResult DeleteFeedback(int id)
        {
            //query to get the selected Feedback
            string query = "Select * from Feedbacks where feedback_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Feedback selectedFeedback = db.Feedbacks.SqlQuery(query, param).FirstOrDefault();

            //display the selected Feedback
            return View(selectedFeedback);
        }

        //Delete: Feedback (Delete data from the database)
        //This block of code execute when we click on submit button to delete a Feedback on the URL: /Feedback/DeleteFeedback
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //query to delete feedback from database
            string query = "delete from Feedbacks where feedback_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            //redirect to List method to view updated list of Feedbacks
            return RedirectToAction("ListOfFeedbacks");
        }

    }
}
//Refernce taken from Christine's code