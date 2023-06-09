﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SacramentMeetingsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SacramentMeetingsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: SacramentMeetings
        public async Task<IActionResult> Index()
        {
              return _context.SacramentMeeting != null ? 
                          View(await _context.SacramentMeeting.ToListAsync()) :
                          Problem("Entity set 'SacramentMeetingPlannerContext.SacramentMeeting'  is null.");
        }

        // GET: SacramentMeetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SacramentMeeting == null)
            {
                return NotFound();
            }

            var sacramentMeeting = await _context.SacramentMeeting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sacramentMeeting == null)
            {
                return NotFound();
            }

            return View(sacramentMeeting);
        }

        // GET: SacramentMeetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SacramentMeetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ConductingLeaderName,OpeningHymn,SacramentHymn,IntermediateHymnOrMusicalNumber,ClosingHymn,OpeningPrayerPerson,ClosingPrayerPerson, NumberOfSpeakers, SpeakerSubjects")] SacramentMeeting sacramentMeeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sacramentMeeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sacramentMeeting);
        }

        // GET: SacramentMeetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SacramentMeeting == null)
            {
                return NotFound();
            }

            var sacramentMeeting = await _context.SacramentMeeting.FindAsync(id);
            if (sacramentMeeting == null)
            {
                return NotFound();
            }
            return View(sacramentMeeting);
        }

        // POST: SacramentMeetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ConductingLeaderName,OpeningHymn,SacramentHymn,IntermediateHymnOrMusicalNumber,ClosingHymn,OpeningPrayerPerson,ClosingPrayerPerson, NumberOfSpeakers, SpeakerSubjects")] SacramentMeeting sacramentMeeting)
        {
            if (id != sacramentMeeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacramentMeeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentMeetingExists(sacramentMeeting.Id))
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
            return View(sacramentMeeting);
        }

        // GET: SacramentMeetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SacramentMeeting == null)
            {
                return NotFound();
            }

            var sacramentMeeting = await _context.SacramentMeeting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sacramentMeeting == null)
            {
                return NotFound();
            }

            return View(sacramentMeeting);
        }

        // POST: SacramentMeetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SacramentMeeting == null)
            {
                return Problem("Entity set 'SacramentMeetingPlannerContext.SacramentMeeting'  is null.");
            }
            var sacramentMeeting = await _context.SacramentMeeting.FindAsync(id);
            if (sacramentMeeting != null)
            {
                _context.SacramentMeeting.Remove(sacramentMeeting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentMeetingExists(int id)
        {
          return (_context.SacramentMeeting?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
