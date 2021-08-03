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
    public class PlaceOrdersController : Controller
    {
        private readonly MhEnterPrisesContext _context;

        public PlaceOrdersController(MhEnterPrisesContext context)
        {
            _context = context;
        }

        // GET: PlaceOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlaceOrder.ToListAsync());
        }

        // GET: PlaceOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeOrder = await _context.PlaceOrder
                .FirstOrDefaultAsync(m => m.id == id);
            if (placeOrder == null)
            {
                return NotFound();
            }

            return View(placeOrder);
        }

        // GET: PlaceOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaceOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Email,Contact,Product,Qty")] PlaceOrder placeOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placeOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placeOrder);
        }

        // GET: PlaceOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeOrder = await _context.PlaceOrder.FindAsync(id);
            if (placeOrder == null)
            {
                return NotFound();
            }
            return View(placeOrder);
        }

        // POST: PlaceOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Email,Contact,Product,Qty")] PlaceOrder placeOrder)
        {
            if (id != placeOrder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placeOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceOrderExists(placeOrder.id))
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
            return View(placeOrder);
        }

        // GET: PlaceOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeOrder = await _context.PlaceOrder
                .FirstOrDefaultAsync(m => m.id == id);
            if (placeOrder == null)
            {
                return NotFound();
            }

            return View(placeOrder);
        }

        // POST: PlaceOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placeOrder = await _context.PlaceOrder.FindAsync(id);
            _context.PlaceOrder.Remove(placeOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceOrderExists(int id)
        {
            return _context.PlaceOrder.Any(e => e.id == id);
        }
    }
}
