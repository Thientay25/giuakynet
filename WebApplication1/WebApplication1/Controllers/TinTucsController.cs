using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TinTucsController : Controller
    {
        private readonly MyDBContext _context;

        public TinTucsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: TinTucs
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.TinTucs.Include(t => t.Loai);
            return View(await myDBContext.ToListAsync());
        }

        // GET: TinTucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs
                .Include(t => t.Loai)
                .FirstOrDefaultAsync(m => m.MaTin == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // GET: TinTucs/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            return View();
        }

        // POST: TinTucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTin,TieuDe,Hinh,NoiDung,NgayDang,MaLoai")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", tinTuc.MaLoai);
            return View(tinTuc);
        }

        // GET: TinTucs/Edit/5
        /*   public async Task<IActionResult> Edit(int? id)
           {
               if (id == null)
               {
                   return NotFound();
               }

               var tinTuc = await _context.TinTucs.FindAsync(id);
               if (tinTuc == null)
               {
                   return NotFound();
               }
               ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", tinTuc.MaLoai);
               return View(tinTuc);
           }

           // POST: TinTucs/Edit/5
           // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
           // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
           [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<IActionResult> Edit(int id, [Bind("MaTin,TieuDe,Hinh,NoiDung,NgayDang,MaLoai")] TinTuc tinTuc)
           {
               if (id != tinTuc.MaTin)
               {
                   return NotFound();
               }

               if (ModelState.IsValid)
               {
                   try
                   {
                       _context.Update(tinTuc);
                       await _context.SaveChangesAsync();
                   }
                   catch (DbUpdateConcurrencyException)
                   {
                       if (!TinTucExists(tinTuc.MaTin))
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
               ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", tinTuc.MaLoai);
               return View(tinTuc);
           } */

        public IActionResult Edit(int? id)
        {
            TinTuc lo = new TinTuc();
            if (id.HasValue && id.Value != 0)
            {
                lo = _context.TinTucs.SingleOrDefault(p => p.MaTin == id);
            }
            return PartialView("Edit", lo);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, TinTuc model, IFormFile fHinh)
        {
            if (fHinh != null)
            {
                //upload file
                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Hinh\TinTuc", fHinh.FileName);
                using (var file = new FileStream(path, FileMode.Create))
                {
                    await fHinh.CopyToAsync(file);
                }
                model.Hinh = fHinh.FileName;
            }
            if (id.HasValue && id.Value > 0)
            {
                _context.Update(model);
            }
            else
            {
                _context.Add(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Loais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }
    
      

        // POST: TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinTuc = await _context.TinTucs.FindAsync(id);
            _context.TinTucs.Remove(tinTuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinTucExists(int id)
        {
            return _context.TinTucs.Any(e => e.MaTin == id);
        }
    }
}
