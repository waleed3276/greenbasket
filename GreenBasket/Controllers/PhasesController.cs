﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenBasket.DBContexts;
using GreenBasket.Models;

namespace GreenBasket.Controllers
{
    public class PhasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Phases.ToListAsync());
        }

        // GET: Phases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // GET: Phases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Status,Date")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phase);
        }

        // GET: Phases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }
            return View(phase);
        }

        // POST: Phases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Status,Date")] Phase phase)
        {
            if (id != phase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhaseExists(phase.Id))
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
            return View(phase);
        }

        // GET: Phases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // POST: Phases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phase = await _context.Phases.FindAsync(id);
            if (phase != null)
            {
                _context.Phases.Remove(phase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhaseExists(int id)
        {
            return _context.Phases.Any(e => e.Id == id);
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Phases.ToListAsync();
            return Ok(data);
        }
    }
}
