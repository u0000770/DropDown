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
using DropDown.Models;

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

        private SelectList BuildGradeSelectListVM(int? Id = null)
        {
            if (Id == null)
            {
                return new SelectList(_context.Grades, "GradeId", "Description");
            }
            return new SelectList(_context.Grades, "GradeId", "Description", Id);
        }

        // GET: v5
        public async Task<IActionResult> Index()
        {
            var shops = _context.Shops.Include(s => s.Grade);
            var vm = shops.Select(s =>  new ShopListItemVM
            {
                 StoreId = s.StoreId,
                  StoreName = s.StoreName,
                     grade = s.Grade.Description
            }).ToList();
            return View(vm);
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

            var vm = new ShopListDetailVM
            { 
              StoreId = shop.StoreId,
               StoreName = shop.StoreName,
                 StoreNumber = shop.StoreNumber,
                  Description = shop.Description,
                   grade = shop.Grade.Description        
            };


            return View(vm);
        }

        // GET: v5/Create
        public IActionResult Create()
        {
            var grades = _context.Grades;
            var vm = new ShopItemViewModel
            {
                listOfGrades = ShopItemViewModel.BuildGradeSelectList(grades.ToList())
            };

            return View(vm);
        }

 

        // POST: v5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreNumber,StoreName,Description,GradeId")] ShopItemViewModel shop)
        {
            if (ModelState.IsValid)
            {
                Shop newShop = new Shop();
                newShop.StoreName = shop.StoreName;
                newShop.StoreNumber = shop.StoreNumber; 
                newShop.Description = shop.Description;
                newShop.GradeId = shop.GradeId;
                _context.Add(newShop);
                try { 
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }

            var grades = _context.Grades;
            var vm = new ShopItemViewModel
            {
                listOfGrades = ShopItemViewModel.BuildGradeSelectList(grades.ToList(),shop.GradeId)
            };

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

            var grades = _context.Grades;
            var vm = new ShopItemViewModel
            {
                 StoreId = shop.StoreId,
                 StoreNumber = shop.StoreNumber,
                 StoreName = shop.StoreName,
                 Description = shop.Description,
                 GradeId = shop.GradeId,
                listOfGrades = ShopItemViewModel.BuildGradeSelectList(grades.ToList(), shop.GradeId)
            };


            return View(vm);
        }

        // POST: v5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreNumber,StoreName,Description,GradeId")] ShopItemViewModel shop)
        {
            if (id != shop.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Shop updateShop = await _context.Shops.SingleOrDefaultAsync(s => s.StoreId == shop.StoreId);
                    if (updateShop != null)
                    {
                        updateShop.StoreNumber = shop.StoreNumber;
                        updateShop.StoreName = shop.StoreName;
                        updateShop.Description = shop.Description;
                        updateShop.GradeId = shop.GradeId;
                        _context.Update(updateShop);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound();
                    }
                   
                }
                catch (Exception ex)
                {
                   return BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }

            var grades = _context.Grades;
            var vm = new ShopItemViewModel
            {
                StoreId = shop.StoreId,
                StoreName = shop.StoreName,
                Description = shop.Description,
                GradeId = shop.GradeId,
                listOfGrades = ShopItemViewModel.BuildGradeSelectList(grades.ToList(), shop.GradeId)
            };
            return View(vm);
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

            var vm = new ShopListDetailVM
            {
                StoreId = shop.StoreId,
                StoreName = shop.StoreName,
                StoreNumber = shop.StoreNumber,
                Description = shop.Description,
                grade = shop.Grade.Description
            };


            return View(vm);

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
