using DropDown.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DropDown.Controllers
{
    public class v4Controller : Controller
    {
        // GET: v4Controller
        public ActionResult Index()
        {

            // create a model object of SelectViewModel with a populated list
            var model = new SelectViewModel
            {
                List = SelectViewModel.BuildList()
            };
            
            return View("Index", model);
        }

        // GET: v4Controller/Details/5
        public ActionResult Details(string SelectId)
        {
            // create a model object of SelectViewModel with a populated SelectId and List
            var model = new SelectViewModel
            {
                List = SelectViewModel.BuildList(),
                SelectId = SelectId
            };
            // dig out and present Version4 View
            return View("Index", model);
        }

        // GET: v4Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v4Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: v4Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: v4Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: v4Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: v4Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
