using HospitalProject_Team4.Data;
using HospitalProject_Team4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject_Team4.Controllers
{
    public class AspNetUserController : Controller
    {
        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: AspNetUser

        //<------LIST OF USERS------->
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string AspNetUsersearchkey)
        {
            Debug.WriteLine("The parameter is " + AspNetUsersearchkey);

            string query = "Select * from AspNetUsers1";
            if (AspNetUsersearchkey != "")
            {
                query = query + " where first_name like '%" + AspNetUsersearchkey + "%'";
            }

            //what data do we need?
            List<AspNetUser> AspNetUser = db.AspNet_User.SqlQuery(query).ToList();

            return View(AspNetUser);
        }

        //<-----ADD A USER------>
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add(string first_name, string last_name, string address, string home_phone,
            string dob, string cell_phone, string gender, string username, string password)
        {


            string query = "insert into AspNetUsers1 (first_name,last_name,address,home_phone,dob,cell_phone,gender,username,password) values (@first_name,@last_name,@address,@home_phone,@dob,@cell_phone,@gender,@username,@password)";
            SqlParameter[] sqlparams = new SqlParameter[9];

            //sqlparams[0] = new SqlParameter("@user_id", user_id);
            sqlparams[0] = new SqlParameter("@first_name", first_name);
            sqlparams[1] = new SqlParameter("@last_name", last_name);
            sqlparams[2] = new SqlParameter("@address", address);
            sqlparams[3] = new SqlParameter("@home_phone", home_phone);
            sqlparams[4] = new SqlParameter("@dob", dob);
            sqlparams[5] = new SqlParameter("@cell_phone", cell_phone);
            sqlparams[6] = new SqlParameter("@gender", gender);
            sqlparams[7] = new SqlParameter("@username", username);
            sqlparams[8] = new SqlParameter("@password", password);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }

        //<-----------SHOW----------->
        public ActionResult Show(int id)
        {
            string query = "select * from AspNetUsers1 where user_id = @id";
            var parameter = new SqlParameter("@id", id);
            AspNetUser User = db.AspNet_User.SqlQuery(query, parameter).FirstOrDefault();

            return View(User);
        }

        public ActionResult Update(int id)
        {
            string query = "select * from AspNetUsers1 where user_id = @id";
            var parameter = new SqlParameter("@id", id);
            AspNetUser User = db.AspNet_User.SqlQuery(query, parameter).FirstOrDefault();

            return View(User);
        }
        [HttpPost]
        public ActionResult Update(string first_name, string last_name, string address, string home_phone,
            string dob, string cell_phone, string gender, string username, string password)
        {
            string query = "update AspNetUsers1 set first_name = @first_name, last_name = @last_name, address = @address, home_phone = @home_phone, dob = @dob, cell_phone = @cell_phone, gender = @gender, username = @username, password = @password where user_id = @id";
            SqlParameter[] sqlparams = new SqlParameter[9];

            sqlparams[0] = new SqlParameter("@first_name", first_name);
            sqlparams[1] = new SqlParameter("@last_name", last_name);
            sqlparams[2] = new SqlParameter("@address", address);
            sqlparams[3] = new SqlParameter("@home_phone", home_phone);
            sqlparams[4] = new SqlParameter("@dob", dob);
            sqlparams[5] = new SqlParameter("@cell_phone", cell_phone);
            sqlparams[6] = new SqlParameter("@gender", gender);
            sqlparams[7] = new SqlParameter("@username", username);
            sqlparams[8] = new SqlParameter("@password", password);

            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

        public ActionResult DeleteConfirm(string id)
        {
            string query = "select * from AspNetUsers1 where user_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            AspNetUser User = db.AspNet_User.SqlQuery(query, param).FirstOrDefault();
            return View(User);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            string query = "delete from AspNetUsers1 where user_id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);


            //for the sake of referential integrity, unset the species for all pets

            return RedirectToAction("List");
        }
    }
}