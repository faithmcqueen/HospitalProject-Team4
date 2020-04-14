using HospitalProject_Team4.Data;
using HospitalProject_Team4.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject_Team4.Controllers
{
    public class ArticleController : Controller
    {
        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //Add: Search

            List<Article> Articles = db.Articles.ToList();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string title, string date, string content)
        {
            Article NewArticle = new Article();
            NewArticle.title = title;
            NewArticle.date = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            NewArticle.content = content;

            db.Articles.Add(NewArticle);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        //need delete

        //need update
    }
}