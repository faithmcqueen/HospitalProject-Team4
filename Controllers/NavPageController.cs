using HospitalProject_Team4.Data;
using HospitalProject_Team4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject_Team4.Controllers
{
    public class NavPageController : Controller
    {
        private HospitalProjectContext db = new HospitalProjectContext();
        
        // GET: Page and Nav
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //ADD: Search

            //show nav
            List<Navigation> Navigation = db.Navigation.ToList();
            return View(Navigation);
        }
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(string navTitle, string url, string pageTitle, string content) 
        {
            //add new navigation and page 
            Navigation NewNav = new Navigation();
            NewNav.title = navTitle;
            NewNav.url = url;

            Page NewPage = new Page();
            NewPage.title = pageTitle;
            NewPage.content = content;

            db.Navigation.Add(NewNav);
            db.Page.Add(NewPage);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Update(int nav_id, int page_id)
        {
            Navigation SelectedNav = db.Navigation.Find(nav_id);
            Page SelectedPage = db.Page.Find(page_id);

            return View();

        }
        //update page and nav at the same time
        [HttpPost]

        public ActionResult Update(int nav_id, string navTitle, string url, int page_id, string pageTitle, string content)
        {
            Navigation SelectedNav = db.Navigation.Find(nav_id);
            SelectedNav.title = navTitle;
            SelectedNav.url = url;

            Page SelectedPage = db.Page.Find(page_id);
            SelectedPage.title = pageTitle;
            SelectedPage.content = content;

            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult ConfirmDelete(int nav_id, int page_id)
        {
            Navigation SelectedNav = db.Navigation.Find(nav_id);
            Page SelectedPage = db.Page.Find(page_id);
            db.Navigation.Remove(SelectedNav);
            db.Page.Remove(SelectedPage);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        //delete nav and page at the same time
        public ActionResult Delete(int nav_id, int page_id)
        {
            Navigation SelectedNav = db.Navigation.Find(nav_id);
            Page SelectedPage = db.Page.Find(page_id);
            db.Navigation.Remove(SelectedNav);
            db.Page.Remove(SelectedPage);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}