using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;

namespace DropDown.Controllers
{
    public class v2Controller : Controller
    {

        /// <summary>
        /// Action MasterV2 constructs a List of SelectListItem’s. 
        /// Each SelectListItem is hard coded with the appropriate Value and Text values required for the Store Grades 
        /// to be displayed.  Each item in the list is a representation of an option tag element within the parent 
        /// Select tag. The List ( items ) is then assigned to the ViewBag dynamic property 
        /// Grade to be consumed by the associated view, 
        /// </summary>
        // GET: v2Controller
        public ActionResult Index()
        {
            // Build a list of SelectListItems
            List<SelectListItem> items = BuildItems();
            // Put our list of items in the ViewBag
            ViewBag.Grade = items;
            // dig out and present Master2 View
            return View();
        }

        private static List<SelectListItem> BuildItems()
        {
            // Create a SelectListItem list
            List<SelectListItem> items = new List<SelectListItem>();
            // Add 4 options to our list of items 
            items.Add(new SelectListItem { Text = "Very Large", Value = "0" });
            items.Add(new SelectListItem { Text = "Large", Value = "1" });
            items.Add(new SelectListItem { Text = "Medium", Value = "2" });
            items.Add(new SelectListItem { Text = "Small", Value = "3" });
            return items;
        }

        // GET: v2Controller/Details/5
        public ActionResult Details(string Grade)
        {
            // read the input parameter passed back from the view
            string choice = Grade;
            // updage the viewbag
            ViewBag.choice = choice;
            // open up the view to display the selection
            return View("Details");
        }

        // GET: v2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v2Controller/Create
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

        // GET: v2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: v2Controller/Edit/5
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

        // GET: v2Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: v2Controller/Delete/5
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
