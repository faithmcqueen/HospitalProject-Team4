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
using System.Globalization;
using HospitalProject_Team4.Models;
using HospitalProject_Team4.Data;

namespace HospitalProject_Team4.Controllers
{
    public class ContactUsController : Controller
    {

        //I am not using Application user her for now 
        //I am just performing CRUD opertions fot this feature

        //create object of database
        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        // GET List: Contact Us
        /* -------------This method is created for logged in admin. Admin can see the list of questions asked by the users in table format -----------*/
        public ActionResult ListContactUs(string contactSearchKey)
        {
            //debug line to test whether we get the input from search key
            Debug.WriteLine("Search keyword is " + contactSearchKey);

            //empty variable declaration
            List<ContactUs> contactUs;

            if (contactSearchKey != "" && contactSearchKey != null)
            {
                //LINQ is used to display the list of contact us

                contactUs =
                    db.ContactUs
                    .Where(contact =>
                        contact.MessageCategories.category_name.Contains(contactSearchKey) ||
                        contact.question.Contains(contactSearchKey) ||
                        contact.date.ToString().Contains(contactSearchKey) 
                        ).ToList();
            }
            else
            {
                contactUs = db.ContactUs.ToList();
            }

            return View(contactUs);
        }


        //ADD: Contact Us (this method is used to push data from database in the fields)
        /* ----------------This method is created for user whether loggin or not. ----------------*/
        /* ---------------Using this method they can send their question to the hospiatl staff --------------*/
        public ActionResult AddContactUs()
        {
            //STEP 1: Push Data
            //get a list of MessageCategories for Contact Us

            List<MessageCategory> messageCategories = db.MessageCategories.SqlQuery("Select * from MessageCategories").ToList();

            return View(messageCategories);
        }

        //ADD: Contact US (Pull data from form and store in the database)
        //This block of code execute when we click on submit button to add a new contact us on the URL: /ContactUs/AddContactUs
        [HttpPost]
        public ActionResult AddContactUs(string first_name, string last_name, string email, string cell_phone, string question, int category_id)
        {
            //STEP 1: Pull data from the arguments of Add Method 
           
            //Debug line to know whether we are accessing correct data from Add Method 
            Debug.WriteLine("New query is" + question);
            DateTime current_date = DateTime.Now;
            string date = current_date.ToShortDateString();

            //STEP 2: Write SQL Query to insert data in the database
            string query = "insert into ContactUs (first_name, last_name, email, cell_phone, question, category_id, date) values (@first_name,@last_name,@email,@cell_phone, @question, @category_id, @date)";
            SqlParameter[] sqlparams = new SqlParameter[7]; //0,1,2,3 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@first_name", first_name);
            sqlparams[1] = new SqlParameter("@last_name", last_name);
            sqlparams[2] = new SqlParameter("@email", email);
            sqlparams[3] = new SqlParameter("@cell_phone", cell_phone);
            sqlparams[4] = new SqlParameter("@question", question);
            sqlparams[5] = new SqlParameter("@category_id", category_id);
            sqlparams[6] = new SqlParameter("@date", date);

            //db.Database.ExecuteSqlCommand will execute "Insert" statement
            db.Database.ExecuteSqlCommand(query, sqlparams);

            //this statement will execute the "ListContactUs" method and provide us a List of Contact Us
            //The new product will also be displayed in the list
            return RedirectToAction("ListContactUs");
        }

        // GET: Details of individual ContactUs
        /* ------------This method is created for logged in admin-----------------*/ 
        /* ------------Admin can view the details of a selescted contact us using this method -------------*/
        public ActionResult ShowContactUs(int? id)
        {
            //if id is equal to NULL then, return BadRequest
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ContactUs contactUs = db.ContactUs.SqlQuery("select * from ContactUs where message_id=@message_id", new SqlParameter("@message_id", id)).FirstOrDefault();

            //if there is no ContactUs then, return HttpNotFound
            if (contactUs == null)
            {
                return HttpNotFound();
            }

            return View(contactUs);
        }

        //Update: get information of a selected contact us
        /* ----------This method is creted for logged in admin --------------*/
        /* -----------Admin can send the answer of the asked question by using this method ----------*/
        public ActionResult UpdateContactUs(int id)
        {
            //query to get information of selected question from database
            string query = "Select * from ContactUs where message_id = @id";
            var parameter = new SqlParameter("@id", id);
            ContactUs SelectedQuestion = db.ContactUs.SqlQuery(query, parameter).FirstOrDefault();

            //give information of contact us to us
            return View(SelectedQuestion);
        }

        //Update Contact Us in database
        //This block of code execute when we click on send button to update a Contact Us on the URL: /ContactUs/UpdateContactUs
        [HttpPost]
        public ActionResult UpdateContactUs(int id, string reply)
        {
            //query to add reply to the question asked by user in database
            string query = "Update ContactUs set reply = @reply where message_id = @id";

            //check the update query
            Debug.WriteLine(query);

            SqlParameter[] sqlparams = new SqlParameter[2];//0,1 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@id", id);
            sqlparams[1] = new SqlParameter("@reply", reply);

            //db.Database.ExecuteSqlCommand will execute "Update" statement
            db.Database.ExecuteSqlCommand(query, sqlparams);

            //this statement will execute the "ListContactUs" method and provide updated List of Contact Us
            return RedirectToAction("ListContactUs");
        }


        //Delete ContactUs
        //GET Data of selected ContactUs
        /* ---------This method is created for logged in admin---------*/
        /*-----------Admin can delete the selected question/contact-us using this method -------------*/ 
        public ActionResult DeleteContactUs(int id)
        {
            //query to get the selected ContactUs
            string query = "Select * from ContactUs where message_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            ContactUs selectedContactUs = db.ContactUs.SqlQuery(query, param).FirstOrDefault();

            //display the selected ContactUs
            return View(selectedContactUs);
        }

        //Delete: ContactUs (Delete data from the database)
        //This block of code execute when we click on submit button to delete a ContactUs on the URL: /ContactUs/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //query to delete ContactUs from database
            string query = "delete from ContactUs where message_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            //redirect to List method to view updated list of ContactUs
            return RedirectToAction("ListContactUs");
        }
    }
}
//Refernce taken from Christine's code    