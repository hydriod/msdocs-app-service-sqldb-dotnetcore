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
    public class BBThreadController : Controller
    {
        private readonly MyDatabaseContext _context;

        public BBThreadController(MyDatabaseContext context)
        {
            _context = context;
        }

        // GET: BBThread
        public async Task<IActionResult> Index()
        {
            return View(await _context.BBThread.ToListAsync());
        }

        // GET: BBThread/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bBThread = await _context.BBThread
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bBThread == null)
            {
                return NotFound();
            }

            return View(bBThread);
        }

        // GET: BBThread/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BBThread/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,PostDate")] BBThread bBThread)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bBThread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bBThread);
        }

        // GET: BBThread/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bBThread = await _context.BBThread.FindAsync(id);
            if (bBThread == null)
            {
                return NotFound();
            }
            return View(bBThread);
        }

        // POST: BBThread/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,PostDate")] BBThread bBThread)
        {
            if (id != bBThread.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bBThread);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BBThreadExists(bBThread.ID))
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
            return View(bBThread);
        }

        // GET: BBThread/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bBThread = await _context.BBThread
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bBThread == null)
            {
                return NotFound();
            }

            return View(bBThread);
        }

        // POST: BBThread/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bBThread = await _context.BBThread.FindAsync(id);
            if (bBThread != null)
            {
                _context.BBThread.Remove(bBThread);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BBThreadExists(int id)
        {
            return _context.BBThread.Any(e => e.ID == id);
        }
    }
}
