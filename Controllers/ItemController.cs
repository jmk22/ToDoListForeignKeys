using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoDbFirstTest01.Models;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoDbFirstTest01.Controllers
{
    public class ItemController : Controller
    {
        private ToDoDbContext db = new ToDoDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Items.Include(d => d.Category).ToList());
        }
        public ActionResult Details(int id)
        {
            Item item = db.Items.FirstOrDefault(d => d.ItemId == id);
            Category category = db.Categories.FirstOrDefault(d => d.CategoryId == id);

            return View(item);
        }
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Item item)
        {
            try
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Item item = db.Items.FirstOrDefault(d => d.ItemId == id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Item item = db.Items.FirstOrDefault(d => d.ItemId == id);
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Item item = db.Items.FirstOrDefault(d => d.ItemId == id);
                db.Items.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Index");
            }
        }

    }
}
