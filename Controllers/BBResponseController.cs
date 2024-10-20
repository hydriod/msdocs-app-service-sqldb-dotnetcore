using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Data;
using DotNetCoreSqlDb.Models;

namespace DotNetCoreSqlDb.Controllers
{
    public class BBResponseController : Controller
    {
        private readonly MyDatabaseContext _context;

        public BBResponseController(MyDatabaseContext context)
        {
            _context = context;
        }

        // GET: BBResponse
        public async Task<IActionResult> Index()
        {
            return View(await _context.BBResponse.ToListAsync());
        }

        // GET: BBResponse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bBResponse = await _context.BBResponse
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bBResponse == null)
            {
                return NotFound();
            }

            return View(bBResponse);
        }

        // GET: BBResponse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BBResponse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Content,PostDate")] BBResponse bBResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bBResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bBResponse);
        }

        // GET: BBResponse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bBResponse = await _context.BBResponse.FindAsync(id);
            if (bBResponse == null)
            {
                return NotFound();
            }
            return View(bBResponse);
        }

        // POST: BBResponse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Content,PostDate")] BBResponse bBResponse)
        {
            if (id != bBResponse.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bBResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BBResponseExists(bBResponse.ID))
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
            return View(bBResponse);
        }

        // GET: BBResponse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bBResponse = await _context.BBResponse
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bBResponse == null)
            {
                return NotFound();
            }

            return View(bBResponse);
        }

        // POST: BBResponse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bBResponse = await _context.BBResponse.FindAsync(id);
            if (bBResponse != null)
            {
                _context.BBResponse.Remove(bBResponse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BBResponseExists(int id)
        {
            return _context.BBResponse.Any(e => e.ID == id);
        }
    }
}
