using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DropDown.Data;
using DropDown.Domain;
using DropDown.Migrations;

namespace DropDown.Controllers
{
    public class v5Controller : Controller
    {
        private readonly OurDbContext _context;

        public v5Controller(OurDbContext context)
        {
            _context = context;
        }

        private void BuildGradeSelectList(int? Id = null)
        {
            if (Id == null)
            {
                ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "Description");
            }
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "Description", Id);
        }

        // GET: v5
        public async Task<IActionResult> Index()
        {
            var ourDbContext = _context.Shops.Include(s => s.Grade);
            return View(await ourDbContext.ToListAsync());
        }

        // GET: v5/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops
                .Include(s => s.Grade)
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: v5/Create
        public IActionResult Create()
        {
            BuildGradeSelectList();
            return View();
        }

 

        // POST: v5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,StoreNumber,StoreName,Description,GradeId")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            BuildGradeSelectList(shop.GradeId);
            return View(shop);
        }

        // GET: v5/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            BuildGradeSelectList(shop.GradeId);
            return View(shop);
        }

        // POST: v5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreNumber,StoreName,Description,GradeId")] Shop shop)
        {
            if (id != shop.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.StoreId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            BuildGradeSelectList(shop.GradeId);
            return View(shop);
        }

        // GET: v5/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shops == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops
                .Include(s => s.Grade)
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: v5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shops == null)
            {
                return Problem("Entity set 'OurDbContext.Shops'  is null.");
            }
            var shop = await _context.Shops.FindAsync(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(int id)
        {
          return (_context.Shops?.Any(e => e.StoreId == id)).GetValueOrDefault();
        }
    }
}
