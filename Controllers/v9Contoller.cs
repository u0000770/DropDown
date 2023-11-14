using DropDown.Models;
using DropDown.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DropDown.Controllers
{
    public class v9Controller : Controller
    {

        private readonly IVenueService _venueService;

        public v9Controller(IVenueService venueService)
        {
            _venueService = venueService;
        }

        // GET: v9Contoller
        public async Task<ActionResult> IndexAsync()
        {
            var eventTypeList = await _venueService.getEventTypes();
            EventListVM vm = new EventListVM
            {
                Name = "List of Event Types",
                List = EventListVM.BuildList(eventTypeList)
            };
            return View(vm);
        }

        // GET: v9Contoller/Details/5
        public async Task<ActionResult> DetailsAsync(string EventTypeId)
        {
            var selectedEventType = await _venueService.getEventType(EventTypeId);
            var vm = new EventTypeVM
            {
                 EventType = selectedEventType.Title
            };
            return View(vm);
        }

        // GET: v9Contoller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v9Contoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: v9Contoller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: v9Contoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: v9Contoller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: v9Contoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
