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
   
    public class NhansuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess strPro = new StringProcess();

        public NhansuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nhansu
        public async Task<IActionResult> Index()
        {
             var applicationDbContext = _context.Nhansu.Include(n => n.TenCV).Include(n => n.TenPhong);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nhansu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhansu == null)
            {
                return NotFound();
            }

            var nhansu = await _context.Nhansu
                .Include(n => n.TenPhong)
                .Include(n => n.TenCV)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhansu == null)
            {
                return NotFound();
            }

            return View(nhansu);
        }

        // GET: Nhansu/Create
        public IActionResult Create()
        {
            ViewData["Chucvu"] = new SelectList(_context.Set<ChucVu>(), "MaCV", "TenCV");
            ViewData["MaPhong"] = new SelectList(_context.Set<Phongban>(), "MaPhong", "TenPhong");
            
            var newnhansu = "NS01";
            var countnhansu = _context.Nhansu.Count();
            if (countnhansu > 0)
            {
                var MaNV = _context.Nhansu.OrderByDescending(m => m.MaNV).First().MaNV;
                newnhansu = strPro.AutoGenerateCode(MaNV);
            }
            ViewBag.newID = newnhansu;

            return View();
        }

        // POST: Nhansu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,Hoten,NgaySinh,Gioitinh,Chucvu,MaPhong,SDT,Email")] Nhansu nhansu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhansu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Chucvu"] = new SelectList(_context.Set<ChucVu>(), "MaCV", "TenCV", nhansu.Chucvu);
            ViewData["MaPhong"] = new SelectList(_context.Set<Phongban>(), "MaPhong", "TenPhong", nhansu.MaPhong);
            return View(nhansu);
        }

        // GET: Nhansu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhansu == null)
            {
                return NotFound();
            }

            var nhansu = await _context.Nhansu.FindAsync(id);
            if (nhansu == null)
            {
                return NotFound();
            }
            ViewData["Chucvu"] = new SelectList(_context.Set<ChucVu>(), "MaCV", "TenCV", nhansu.Chucvu);
            ViewData["MaPhong"] = new SelectList(_context.Set<Phongban>(), "MaPhong", "TenPhong", nhansu.MaPhong);
            return View(nhansu);
        }

        // POST: Nhansu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,Hoten,NgaySinh,Gioitinh,Chucvu,MaPhong,SDT,Email")] Nhansu nhansu)
        {
            if (id != nhansu.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhansu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhansuExists(nhansu.MaNV))
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
            ViewData["Chucvu"] = new SelectList(_context.Set<ChucVu>(), "MaCV", "TenCV", nhansu.Chucvu);
            ViewData["MaPhong"] = new SelectList(_context.Set<Phongban>(), "MaPhong", "TenPhong", nhansu.MaPhong);
            return View(nhansu);
        }

        // GET: Nhansu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhansu == null)
            {
                return NotFound();
            }

            var nhansu = await _context.Nhansu
                .Include(n => n.TenPhong)
                .Include(n => n.TenCV)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhansu == null)
            {
                return NotFound();
            }

            return View(nhansu);
        }

        // POST: Nhansu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhansu == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nhansu'  is null.");
            }
            var nhansu = await _context.Nhansu.FindAsync(id);
            if (nhansu != null)
            {
                _context.Nhansu.Remove(nhansu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhansuExists(string id)
        {
          return (_context.Nhansu?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }
    }
    }