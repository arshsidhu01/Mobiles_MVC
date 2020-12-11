using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mobiles_MVC.Data;
using Mobiles_MVC.Models;

namespace Mobiles_MVC.Controllers
{
    public class SellsController : Controller
    {
        private readonly Mobiles_MVCContext _context;

        public SellsController(Mobiles_MVCContext context)
        {
            _context = context;
        }

        // GET: Sells
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var mobiles_MVCContext = _context.Sell.Include(s => s.Customers).Include(s => s.Products).Include(s => s.Staffs);
            return View(await mobiles_MVCContext.ToListAsync());
        }

        // GET: Sells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sell
                .Include(s => s.Customers)
                .Include(s => s.Products)
                .Include(s => s.Staffs)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sell == null)
            {
                return NotFound();
            }

            return View(sell);
        }

        // GET: Sells/Create
       
        public IActionResult Create()
        {
            ViewData["CustomersId"] = new SelectList(_context.Customers, "id", "id");
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["StaffsId"] = new SelectList(_context.Set<Staffs>(), "Id", "Id");
            return View();
        }

        // POST: Sells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ProductsId,CustomersId,StaffsId")] Sell sell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "id", "id", sell.CustomersId);
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", sell.ProductsId);
            ViewData["StaffsId"] = new SelectList(_context.Set<Staffs>(), "Id", "Id", sell.StaffsId);
            return View(sell);
        }

        // GET: Sells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sell.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }
            ViewData["CustomersId"] = new SelectList(_context.Customers, "id", "id", sell.CustomersId);
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", sell.ProductsId);
            ViewData["StaffsId"] = new SelectList(_context.Set<Staffs>(), "Id", "Id", sell.StaffsId);
            return View(sell);
        }

        // POST: Sells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ProductsId,CustomersId,StaffsId")] Sell sell)
        {
            if (id != sell.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellExists(sell.id))
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
            ViewData["CustomersId"] = new SelectList(_context.Customers, "id", "id", sell.CustomersId);
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", sell.ProductsId);
            ViewData["StaffsId"] = new SelectList(_context.Set<Staffs>(), "Id", "Id", sell.StaffsId);
            return View(sell);
        }

        // GET: Sells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sell
                .Include(s => s.Customers)
                .Include(s => s.Products)
                .Include(s => s.Staffs)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sell == null)
            {
                return NotFound();
            }

            return View(sell);
        }

        // POST: Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sell = await _context.Sell.FindAsync(id);
            _context.Sell.Remove(sell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellExists(int id)
        {
            return _context.Sell.Any(e => e.id == id);
        }
    }
}
