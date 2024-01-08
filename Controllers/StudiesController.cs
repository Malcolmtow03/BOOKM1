using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOOKM1.Data;
using BOOKM1.Models;

namespace BOOKM1.Controllers
{
    public class StudiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Studies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Study.Include(s => s.Author);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Studies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Study == null)
            {
                return NotFound();
            }

            var study = await _context.Study
                .Include(s => s.Author)
                .FirstOrDefaultAsync(m => m.StudyId == id);
            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        // GET: Studies/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorId");
            return View();
        }

        // POST: Studies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudyId,Name,Univer,Course,CCost,AuthorId")] Study study)
        {
            if (ModelState.IsValid)
            {
                _context.Add(study);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorId", study.AuthorId);
            return View(study);
        }

        // GET: Studies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Study == null)
            {
                return NotFound();
            }

            var study = await _context.Study.FindAsync(id);
            if (study == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorId", study.AuthorId);
            return View(study);
        }

        // POST: Studies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudyId,Name,Univer,Course,CCost,AuthorId")] Study study)
        {
            if (id != study.StudyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(study);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyExists(study.StudyId))
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorId", study.AuthorId);
            return View(study);
        }

        // GET: Studies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Study == null)
            {
                return NotFound();
            }

            var study = await _context.Study
                .Include(s => s.Author)
                .FirstOrDefaultAsync(m => m.StudyId == id);
            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        // POST: Studies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Study == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Study'  is null.");
            }
            var study = await _context.Study.FindAsync(id);
            if (study != null)
            {
                _context.Study.Remove(study);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyExists(int id)
        {
          return (_context.Study?.Any(e => e.StudyId == id)).GetValueOrDefault();
        }
    }
}
