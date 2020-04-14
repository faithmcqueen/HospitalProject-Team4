using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalProject_Team4.Data;
using HospitalProject_Team4.Models;
using HospitalProject_Team4.Models.ViewModels;
using System.Diagnostics;
using System.IO;
//needed for other sign in feature classes
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace HospitalProject_Team4.Controllers
{
    public class ParkingController : Controller
    {
        //reference login functions:

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private HospitalProjectContext db = new HospitalProjectContext();

        //GET: List of all parking spaces (Public)
        public ActionResult List(string parksearchkey)
        {
            //test access to search key:
            Debug.WriteLine("The search key is " + parksearchkey);

            //Start building the query
            string query = "SELECT * FROM ParkingSpots";
            //Create a list so that we can offset when needed for pagination
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            //Next we pass through our search key and use it with an if statement

            if (parksearchkey != "")
            {
                query = query + "WHERE branch like @searchkey";
                //create new parameter for searchkey value
                sqlparams.Add(new SqlParameter("@searchkey", "%" + parksearchkey + "%"));
                //Write a debug line to make sure our SQL query is written correctly
                Debug.WriteLine("The query is " + query);
            }

            List<ParkingSpot> parkingspots = db.ParkingSpots.SqlQuery(query, sqlparams.ToArray()).ToList();

            //Get results
            return View(parkingspots);
        }  //END ActionResult List

        //GET: List of all parking spot bookings (Public)
        public ActionResult AdminList()
        {
            //Start building the query
            string query = "SELECT * FROM SpotBookings JOIN ParkingSpots ON SpotBookings.SpotID = ParkingSpots.SpotID";
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            //Next we pass through our search key and use it with an if statement

            if (parksearchkey != "")
            {
                query = query + "WHERE branch like @searchkey";
                //create new parameter for searchkey value
                sqlparams.Add(new SqlParameter("@searchkey", "%" + parksearchkey + "%"));
                //Write a debug line to make sure our SQL query is written correctly
                Debug.WriteLine("The query is " + query);
            }
            List<ParkingSpot> parkingspots = db.ParkingSpots.SqlQuery(query, sqlparams.ToArray()).ToList();
            //Get results
            return View(parkingspots);
        }  //END ActionResult AdminList

        //GET: Individual spot booking information (Admin)
        public ActionResult Show(int id)
        {
            //Handle invalid requests
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Start building the query and parameter to pass through
            string query = "SELECT * FROM SpotBookings JOIN ParkingSpots ON SpotBookings.SpotID = ParkingSpots.SpotID WHERE SpotBookingID = @bookingid";
            var parameter = new SqlParameter("@bookingid", id);
            //execute SQL
            SpotBooking spotbooking = db.SpotBookings.SqlQuery(query, parameter).FirstOrDefault();
            //Get results
            return View(spotbooking);
        }  //END ActionResult Show

        //SET : New parking space booking (PUBLIC)
        public ActionResult Book()
        {
            return View();
        }
        // Method for after the booking form has been filled out and submitted
        [HttpPost]
        public ActionResult Book(DateTime BookingDate, DateTime StartDate, DateTime EndDate, int SpotID)
        {
            //Write the query
            string query = "INSERT into SpotBookings (BookingDate, StartDate, EndDate, SpotID) values (@bookingdate, @startdate, @enddate, @spotid)";
            //Declare the parameters that we will pass through the query
            SqlParameter[] sqlparams = new SqlParameter[4];
            sqlparams[0] = new SqlParameter("@bookingdate", BookingDate);
            sqlparams[1] = new SqlParameter("@startdate", StartDate);
            sqlparams[2] = new SqlParameter("@enddate", EndDate);
            sqlparams[3] = new SqlParameter("@spotid", SpotID);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        } //END ActionResult Book

        //SET: Updating a booking (ADMIN)
        public ActionResult Update(int id)
        {
            string query = "SELECT * FROM SpotBookings INNER JOIN ParkingSpots ON SpotBookings.SpotID = ParkingSpots.SpotID WHERE SpotBookingID = @bookingid";
            SqlParameter sqlparams = new SqlParameter("@bookingid", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return View();
        }
        // Method for after the booking form has been filled out and submitted
        [HttpPost]
        public ActionResult Update(int id, DateTime BookingDate, DateTime StartDate, DateTime EndDate, int SpotID)
        {
            //Write the query
            string query = "UPDATE SpotBookings SET BookingDate = @bookingdate, StartDate = @startdate, EndDate = @enddate, SpotID = @spotid WHERE SpotBookingID = @bookingid";
            //Declare the parameters that we will pass through the query
            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@bookingdate", BookingDate);
            sqlparams[1] = new SqlParameter("@startdate", StartDate);
            sqlparams[2] = new SqlParameter("@enddate", EndDate);
            sqlparams[3] = new SqlParameter("@spotid", SpotID);
            sqlparams[4] = new SqlParameter("@bookingid", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("AdminList");
        } //END ActionResult Update


        //SET delete a booking (admin)
        public ActionResult Delete(int id)
        {
            //Write the query
            string query = "DELETE from SpotBookings where SpotBookingID = @bookingid";
            //Create the parameter
            SqlParameter sqlparams = new SqlParameter("@bookingid", id);
            //Execute and redirect back to the AdminList page
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("AdminList");
        }
    }


}