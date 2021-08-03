using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MhEnterPrises.Data;
using MhEnterPrises.Models;

namespace MhEnterPrises.Controllers
{
    public class HomeAppliancesController : Controller
    {
        private readonly MhEnterPrisesContext _context;

        public HomeAppliancesController(MhEnterPrisesContext context)
        {
            _context = context;
        }

        // GET: HomeAppliances
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeAppliances.ToListAsync());
        }

        public async Task<IActionResult> ListAppliances()
        {
            return View(await _context.HomeAppliances.ToListAsync());
        }
        // GET: HomeAppliances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeAppliances = await _context.HomeAppliances
                .FirstOrDefaultAsync(m => m.id == id);
            if (homeAppliances == null)
            {
                return NotFound();
            }

            return View(homeAppliances);
        }

        // GET: HomeAppliances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeAppliances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Qty,Price")] HomeAppliances homeAppliances)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeAppliances);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeAppliances);
        }

        // GET: HomeAppliances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeAppliances = await _context.HomeAppliances.FindAsync(id);
            if (homeAppliances == null)
            {
                return NotFound();
            }
            return View(homeAppliances);
        }

        // POST: HomeAppliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Qty,Price")] HomeAppliances homeAppliances)
        {
            if (id != homeAppliances.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeAppliances);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeAppliancesExists(homeAppliances.id))
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
            return View(homeAppliances);
        }

        // GET: HomeAppliances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeAppliances = await _context.HomeAppliances
                .FirstOrDefaultAsync(m => m.id == id);
            if (homeAppliances == null)
            {
                return NotFound();
            }

            return View(homeAppliances);
        }

        // POST: HomeAppliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeAppliances = await _context.HomeAppliances.FindAsync(id);
            _context.HomeAppliances.Remove(homeAppliances);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeAppliancesExists(int id)
        {
            return _context.HomeAppliances.Any(e => e.id == id);
        }
    }
}
