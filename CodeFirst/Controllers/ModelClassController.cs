using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Data;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class ModelClassController : Controller
    {
        private readonly CodeFirstContext _context;

        public ModelClassController(CodeFirstContext context)
        {
            _context = context;
        }

        // GET: ModelClass
     
        public async Task<IActionResult> Index1()
        {
            return _context.ModelClass != null ?
                        View(await _context.ModelClass.ToListAsync()) :
                        Problem("Entity set 'CodeFirstContext.ModelClass'  is null.");
        }

       
       
        // GET: ModelClass/Create
       
        public IActionResult Create1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("Id,Items")] ModelClass modelClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index1));
            }
            return View(modelClass);
        }
        public async Task<IActionResult> Delete1(int? id)
        {
            if (id == null || _context.ModelClass == null)
            {
                return NotFound();
            }

            var modelClass = await _context.ModelClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelClass == null)
            {
                return NotFound();
            }

            return View(modelClass);
        }

        public async Task<IActionResult> Edit1(int? id)
        {
            if (id == null || _context.ModelClass == null)
            {
                return NotFound();
            }

            var modelClass = await _context.ModelClass.FindAsync(id);
            if (modelClass == null)
            {
                return NotFound();
            }
            return View(modelClass);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit1(int id, [Bind("Id,Items")] ModelClass modelClass)
        {
            if (id != modelClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelClassExists(modelClass.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index1));
            }
            return View(modelClass);
        }


        // POST: ModelClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelClass == null)
            {
                return NotFound();
            }

            var modelClass = await _context.ModelClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelClass == null)
            {
                return NotFound();
            }

            return View(modelClass);
        }

        [HttpPost, ActionName("Delete1")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelClass == null)
            {
                return Problem("Entity set 'CodeFirstContext.ModelClass'  is null.");
            }
            var modelClass = await _context.ModelClass.FindAsync(id);
            if (modelClass != null)
            {
                _context.ModelClass.Remove(modelClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index1));
        }

        private bool ModelClassExists(int id)
        {
          return (_context.ModelClass?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
