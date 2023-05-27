using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;
using QLNS.Models.Process;
namespace QLNS.Controllers
{
    public class HopdongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopdongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hopdong
        public async Task<IActionResult> Index()
        {
              return _context.Hopdong != null ? 
                          View(await _context.Hopdong.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Hopdong'  is null.");
        }

        // GET: Hopdong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Hopdong == null)
            {
                return NotFound();
            }

            var hopdong = await _context.Hopdong
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (hopdong == null)
            {
                return NotFound();
            }

            return View(hopdong);
        }

        // GET: Hopdong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hopdong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,Ngaybatdau,Ngayketthuc")] Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopdong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopdong);
        }

        // GET: Hopdong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Hopdong == null)
            {
                return NotFound();
            }

            var hopdong = await _context.Hopdong.FindAsync(id);
            if (hopdong == null)
            {
                return NotFound();
            }
            return View(hopdong);
        }

        // POST: Hopdong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,Ngaybatdau,Ngayketthuc")] Hopdong hopdong)
        {
            if (id != hopdong.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopdong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopdongExists(hopdong.MaNV))
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
            return View(hopdong);
        }

        // GET: Hopdong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Hopdong == null)
            {
                return NotFound();
            }

            var hopdong = await _context.Hopdong
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (hopdong == null)
            {
                return NotFound();
            }

            return View(hopdong);
        }

        // POST: Hopdong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Hopdong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hopdong'  is null.");
            }
            var hopdong = await _context.Hopdong.FindAsync(id);
            if (hopdong != null)
            {
                _context.Hopdong.Remove(hopdong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopdongExists(string id)
        {
          return (_context.Hopdong?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }
    }
 }  