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

        //I am not using Application user her for now 
        //I am just performing CRUD opertions fot this feature

        //create object of database
        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: MessageCategory
        public ActionResult Index()
        {
            return View();
        }

        // GET List: Message Categories
        /* -------------This method is created for logged in admin. Admin can see the list of categories under which user can send the questions using contactus feature in table format -----------*/
        public ActionResult ListMessageCategory(string categorysearchkey)
        {
            Debug.WriteLine("The search key is " + categorysearchkey);

            if (categorysearchkey != null && categorysearchkey != "")
            {

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

        //ADD: Message Category (this method is used to push data from database in the fields)
        /* ----------------This method is created for logged in admin. ----------------*/
        /* ---------------Using this method admin can add more categories that user can select to ask questions about --------------*/
        public ActionResult AddMessageCategory()
        {
            return View();
        }

        //ADD: Message Category (Pull data from form and store in the database)
        //This block of code execute when we click on submit button to add a new Message Category 
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

            //again execute the ListMessageCategory mehod to display new list of Message Categories
            return RedirectToAction("ListMessageCategory");
        }

        // GET: Details of individual MessageCategory
        /* ------------This method is created for logged in admin-----------------*/
        /* ------------Admin can view the details of a selected message category using this method -------------*/
        public ActionResult ShowMessageCategory(int? id)
        {
            //if id is equal to NULL then, return BadRequest
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MessageCategory messageCategory = db.MessageCategories.SqlQuery("select * from MessageCategories where category_id=@category_id", new SqlParameter("@category_id", id)).FirstOrDefault();

            //if there is no category then, return HttpNotFound
            if (messageCategory == null)
            {
                return HttpNotFound();
            }

            return View(messageCategory);
        }

        //Update: get information of a selected category
        /* ----------This method is creted for logged in admin --------------*/
        /* -----------Admin can update the message category using this method ----------*/
        public ActionResult UpdateMessageCategory(int id)
        {
            //query to get information of selected category from database
            string query = "Select * from MessageCategories where category_id = @id";
            var parameter = new SqlParameter("@id", id);
            MessageCategory SelectedCategory = db.MessageCategories.SqlQuery(query, parameter).FirstOrDefault();

            return View(SelectedCategory);
        }

        //Update category in database
        [HttpPost]
        public ActionResult UpdateMessageCategory(int id, string category_name)
        {
            //query to update category in database
            string query = "Update MessageCategories set category_name = @category_name where category_id = @id";

            //check the update query
            Debug.WriteLine(query);

            SqlParameter[] sqlparams = new SqlParameter[2];//0,1 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@id", id);
            sqlparams[1] = new SqlParameter("@category_name", category_name);

            //db.Database.ExecuteSqlCommand will execute "Update" statement
            db.Database.ExecuteSqlCommand(query, sqlparams);

            //this statement will execute the "ListMessageCategory" method and provide updated List of message categories
            return RedirectToAction("ListMessageCategory");
        }


        //Delete message category
        //GET Data of selected category
        /* ---------This method is created for logged in admin---------*/
        /*-----------Admin can delete the selected category using this method -------------*/
        public ActionResult DeleteMessageCategory(int id)
        {
            //query to get the selected category
            string query = "Select * from MessageCategories where category_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            MessageCategory SelectedCategory = db.MessageCategories.SqlQuery(query, param).FirstOrDefault();

            //display the selected category
            return View(SelectedCategory);
        }

        //Delete: category 
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //query to delete category from database
            string query = "delete from MessageCategories where category_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            //redirect to List method to view updated list of Categories
            return RedirectToAction("ListMessageCategory");
        }
    }
}
//Refernce taken from Christine's code    