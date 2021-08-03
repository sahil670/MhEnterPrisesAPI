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
    public class AuthenticationsController : Controller
    {
        private readonly MhEnterPrisesContext _context;

        public AuthenticationsController(MhEnterPrisesContext context)
        {
            _context = context;
        }

        // GET: Authentications
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authentication.ToListAsync());
        }

        // GET: Authentications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authentication = await _context.Authentication
                .FirstOrDefaultAsync(m => m.id == id);
            if (authentication == null)
            {
                return NotFound();
            }

            return View(authentication);
        }

        // GET: Authentications/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Accept()
        {
            return View();
        }

        public IActionResult Reject()
        {
            return View();
        }


        // POST: Authentications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Password")] Authentication authentication)
        {
            if (authentication.Name.Equals("Electro@gmail.com") && authentication.Password.Equals("Electro"))
            {
                return RedirectToAction(nameof(Accept));
            }
            else {
                return RedirectToAction(nameof(Reject));
            }

            
            
        }

        // GET: Authentications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authentication = await _context.Authentication.FindAsync(id);
            if (authentication == null)
            {
                return NotFound();
            }
            return View(authentication);
        }

        // POST: Authentications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Password")] Authentication authentication)
        {
            if (id != authentication.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authentication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthenticationExists(authentication.id))
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
            return View(authentication);
        }

        // GET: Authentications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authentication = await _context.Authentication
                .FirstOrDefaultAsync(m => m.id == id);
            if (authentication == null)
            {
                return NotFound();
            }

            return View(authentication);
        }

        // POST: Authentications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authentication = await _context.Authentication.FindAsync(id);
            _context.Authentication.Remove(authentication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthenticationExists(int id)
        {
            return _context.Authentication.Any(e => e.id == id);
        }
    }
}
