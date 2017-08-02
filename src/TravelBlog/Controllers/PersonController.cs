using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;
using System;


namespace TravelBlog.Controllers
{
    public class PersonController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index()
        {
            return View(db.People.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisPerson = db.People.FirstOrDefault(per => per.PersonId == id);

            return View(thisPerson);
        }
        public IActionResult Create(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPer = db.People.FirstOrDefault(per => per.PersonId == id);
            return View(thisPer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPer = db.People.FirstOrDefault(per => per.PersonId == id);
            db.People.Remove(thisPer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisPer = db.People.FirstOrDefault(per => per.PersonId == id);
            return View(thisPer);
        }
        [HttpPost]
        public IActionResult Edit(Experience pererience)
        {
            db.Entry(pererience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
