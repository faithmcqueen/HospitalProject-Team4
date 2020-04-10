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
    public class MessageCategoryController : Controller
    {
        //create object of database
        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: MessageCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMessageCategory(string categorysearchkey)
        {
            Debug.WriteLine("The search key is " + categorysearchkey);

            if (categorysearchkey != null && categorysearchkey != "")
            {
                //SQL : 
                // select * from groomers 
                // where groomerfname like '%@key%' OR
                // groomerlname like '%key%'
                List<MessageCategory> messageCategories = db.MessageCategories
                    .Where(category =>
                        category.category_name.Contains(categorysearchkey))
                    .ToList();
                return View(messageCategories);
            }
            else
            {
                List<MessageCategory> messageCategories = db.MessageCategories.ToList();
                return View(messageCategories);
            }
        }

        //ADD: Feedback (this method is used to push data from database in the fields)
        //But here we do not need any data from database to add a new Feedback
        //That's why there is nothing in the Add() method
        public ActionResult AddMessageCategory()
        {
            return View();
        }

        //ADD: Feedback (Pull data from form and store in the database)
        //This block of code execute when we click on submit button to add a new Feedback on the URL: /Feedback/Add
        [HttpPost]
        public ActionResult AddMessageCategory(string category_name)
        {
            //STEP-1: Pull data from the arguments of Add Method
            //Debug line to check we are getting correct data from Add method
            Debug.WriteLine("name of new category is" + category_name);

            //STEP-2: Write SQL Query to insert data in database
            string query = "Insert into MessageCategories (category_name) values (@category_name)";
            var parameter = new SqlParameter("@category_name", category_name);

            //db.Database.ExecuteSqlCommand will execute "Insert" statement
            db.Database.ExecuteSqlCommand(query, parameter);

            //again execute the List mehod to display new list of Feedback
            return RedirectToAction("ListMessageCategory");
        }

        // GET: Details of individual Feedback
        public ActionResult ShowMessageCategory(int? id)
        {
            //if id is equal to NULL then, return BadRequest
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MessageCategory messageCategory = db.MessageCategories.SqlQuery("select * from MessageCategories where category_id=@category_id", new SqlParameter("@category_id", id)).FirstOrDefault();

            //if there is no feedback then, return HttpNotFound
            if (messageCategory == null)
            {
                return HttpNotFound();
            }

            return View(messageCategory);
        }

        //Update: get information of a selected Brand
        public ActionResult UpdateMessageCategory(int id)
        {
            //query to get information of selected Brand from database
            string query = "Select * from MessageCategories where category_id = @id";
            var parameter = new SqlParameter("@id", id);
            MessageCategory SelectedCategory = db.MessageCategories.SqlQuery(query, parameter).FirstOrDefault();

            //give information of brand to us
            return View(SelectedCategory);
        }

        //Update Brand in database
        //This block of code execute when we click on submit button to update a Brand on the URL: /Brand/Update
        [HttpPost]
        public ActionResult UpdateMessageCategory(int id, string category_name)
        {
            //query to update brand in database
            string query = "Update MessageCategories set category_name = @category_name where category_id = @id";

            //check the update query
            Debug.WriteLine(query);

            SqlParameter[] sqlparams = new SqlParameter[2];//0,1 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@id", id);
            sqlparams[1] = new SqlParameter("@category_name", category_name);

            //db.Database.ExecuteSqlCommand will execute "Update" statement
            db.Database.ExecuteSqlCommand(query, sqlparams);

            //this statement will execute the "List" method and provide updated List of Brands
            return RedirectToAction("ListMessageCategory");
        }


        //Delete Feedback
        //GET Data of selected Feedback
        public ActionResult DeleteMessageCategory(int id)
        {
            //query to get the selected Feedback
            string query = "Select * from MessageCategories where category_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            MessageCategory SelectedCategory = db.MessageCategories.SqlQuery(query, param).FirstOrDefault();

            //display the selected Feedback
            return View(SelectedCategory);
        }

        //Delete: Feedback (Delete data from the database)
        //This block of code execute when we click on submit button to delete a Feedback on the URL: /Feedback/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //query to delete feedback from database
            string query = "delete from MessageCategories where category_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            //redirect to List method to view updated list of Category
            return RedirectToAction("ListMessageCategory");
        }
    }
}
    