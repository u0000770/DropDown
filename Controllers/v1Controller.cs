using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DropDown.Controllers
{
    public class v1Controller : Controller
    {
        // GET: v1Controller
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// This action has three tasks to perform; Read the value of the selected Grade currently embedded within the query string.  
        /// The ASP.NET Request object makes available the Query string collection index-able using a magic string with the same 
        /// name as the parameter we require, Request.QueryString[“Grade”].  
        /// The second task is to make our data available to the view designated to display our selection. 
        /// ViewBag is a dynamic property that makes data created within a controller available to the associated view. 
        /// The final act is to call the associated view Detail.chtml
        /// </summary>
      
        public ActionResult Details()
        {
            // Read the query string with the name "Grade"
            string choice = HttpContext.Request.Query["Grade"];
            // Put the choice into the ViewBag and display in its own view
            ViewBag.choice = choice;
            return View("Details");
        }

        // GET: v1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v1Controller/Create
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

        // GET: v1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: v1Controller/Edit/5
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

        // GET: v1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: v1Controller/Delete/5
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
