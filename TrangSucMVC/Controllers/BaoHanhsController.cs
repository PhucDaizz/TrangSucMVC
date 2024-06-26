using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrangSucMVC.Data;

namespace TrangSucMVC.Controllers
{
    public class BaoHanhsController : Controller
    {
        private readonly BanTrangSucContext _context;

        public BaoHanhsController(BanTrangSucContext context)
        {
            _context = context;
        }

        // GET: BaoHanhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaoHanhs.ToListAsync());
        }

        // GET: BaoHanhs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoHanh = await _context.BaoHanhs
                .FirstOrDefaultAsync(m => m.MaBaoHanh == id);
            if (baoHanh == null)
            {
                return NotFound();
            }

            return View(baoHanh);
        }

        // GET: BaoHanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaoHanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBaoHanh,MaSanPham,ThoiGianBaoHanh,NgayCap")] BaoHanh baoHanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baoHanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baoHanh);
        }

        // GET: BaoHanhs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoHanh = await _context.BaoHanhs.FindAsync(id);
            if (baoHanh == null)
            {
                return NotFound();
            }
            return View(baoHanh);
        }

        // POST: BaoHanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaBaoHanh,MaSanPham,ThoiGianBaoHanh,NgayCap")] BaoHanh baoHanh)
        {
            if (id != baoHanh.MaBaoHanh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baoHanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaoHanhExists(baoHanh.MaBaoHanh))
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
            return View(baoHanh);
        }

        // GET: BaoHanhs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoHanh = await _context.BaoHanhs
                .FirstOrDefaultAsync(m => m.MaBaoHanh == id);
            if (baoHanh == null)
            {
                return NotFound();
            }

            return View(baoHanh);
        }

        // POST: BaoHanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var baoHanh = await _context.BaoHanhs.FindAsync(id);
            if (baoHanh != null)
            {
                _context.BaoHanhs.Remove(baoHanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaoHanhExists(string id)
        {
            return _context.BaoHanhs.Any(e => e.MaBaoHanh == id);
        }
    }
}
