using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoDbFirstTest01.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoDbFirstTest01.Controllers
{
    public class CategoryController : Controller
    {
        private ToDoDbContext db = new ToDoDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public IActionResult Details(int id)
        {
            Category category = db.Categories.FirstOrDefault(d => d.CategoryId == id);
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            Category category = db.Categories.FirstOrDefault(d => d.CategoryId == id);
            if (category == null)
            {
                return View("Not found");
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Category category = db.Categories.FirstOrDefault(d => d.CategoryId == id);
            if (category == null)
            {
                return View("Not found");
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.FirstOrDefault(d => d.CategoryId == id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
