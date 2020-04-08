using HospitalProject_Team4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject_Team4.Controllers
{
    public class VolunteerRecruitmentController : Controller
    {
        private HospitalProjectContext db = new HospitalProjectContext();
        // GET: VolunteerRecruitment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {

            return View();
        }
        //add volunteer 
        [HttpPost]
        public async Task<ActionResult> Add(string Username, string Useremail, string Userpass, string GroomerFName, string GroomerLName, string GroomerDOB, decimal GroomerRate)
        {
            return View();
        }
    }
}