using DropDown.Data;
using DropDown.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DropDown.Controllers
{
    public class v7Controller : Controller
    {
        private readonly OurDbContext _context;

        public v7Controller(OurDbContext context)
        {
            _context = context;
        }
        // GET: v6Controller
        public ActionResult Index()
        {
            var grades = _context.Grades;
            // create a GradeStoreVM object
            var model = new GradeStoreVM
            {
                List = GradeStoreVM.BuildList(grades.ToList())
            };
            // pass a populated model to the view
            return View(model);
        }

        // GET: v6Controller/Details/5
        public ActionResult Details(int GradeId)
        {
            var grades = _context.Grades;
            // cast the selection into a int
            int gid = Convert.ToInt32(GradeId);
            // get the stores associated with a grade
            var stores = _context.Shops.Where(x => x.GradeId == gid).ToList();
            // construct a viewmodel
            var model = new GradeStoreVM
            {
                List = GradeStoreVM.BuildList(grades.ToList()),
                GradeStores = stores,
                GradeId = GradeId.ToString(),
            };
            // return the viewmodel
            return View("Index", model);
        }

        // GET: v7Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v7Controller/Create
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

        // GET: v7Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: v7Controller/Edit/5
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

        // GET: v7Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: v7Controller/Delete/5
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
