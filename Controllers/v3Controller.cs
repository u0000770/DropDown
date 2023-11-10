using DropDown.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DropDown.Controllers
{
    public class v3Controller : Controller
    {
        // GET: v3Controller
        public ActionResult Index()
        {
            // create a model object of a SelectViewModel with a populated list
            var model = new SelectViewModel
            {
                List = SelectViewModel.BuildList()
            };
            // dig out and present Master3 View
            return View(model);
        }

        // GET: v3Controller/Details/5
        public ActionResult Details(string SelectId)
        {
            // create a model object of SelectViewModel with a populated SelectId
            var model = new SelectViewModel
            {
                SelectId = SelectId
            };
            // dig out and present Detail3 View
            return View("Details", model);
        }

        // GET: v3Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v3Controller/Create
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

        // GET: v3Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: v3Controller/Edit/5
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

        // GET: v3Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: v3Controller/Delete/5
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
