using System;
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
    public class LDSMembersController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public LDSMembersController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: LDSMembers
        public async Task<IActionResult> Index()
        {
              return _context.LDSMember != null ? 
                          View(await _context.LDSMember.ToListAsync()) :
                          Problem("Entity set 'SacramentMeetingPlannerContext.LDSMember'  is null.");
        }

        // GET: LDSMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LDSMember == null)
            {
                return NotFound();
            }

            var lDSMember = await _context.LDSMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lDSMember == null)
            {
                return NotFound();
            }

            return View(lDSMember);
        }

        // GET: LDSMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LDSMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecordNumber,FullName,BirthDay,MusicalSkills")] LDSMember lDSMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lDSMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lDSMember);
        }

        // GET: LDSMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LDSMember == null)
            {
                return NotFound();
            }

            var lDSMember = await _context.LDSMember.FindAsync(id);
            if (lDSMember == null)
            {
                return NotFound();
            }
            return View(lDSMember);
        }

        // POST: LDSMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecordNumber,FullName,BirthDay,MusicalSkills")] LDSMember lDSMember)
        {
            if (id != lDSMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lDSMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LDSMemberExists(lDSMember.Id))
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
            return View(lDSMember);
        }

        // GET: LDSMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LDSMember == null)
            {
                return NotFound();
            }

            var lDSMember = await _context.LDSMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lDSMember == null)
            {
                return NotFound();
            }

            return View(lDSMember);
        }

        // POST: LDSMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LDSMember == null)
            {
                return Problem("Entity set 'SacramentMeetingPlannerContext.LDSMember'  is null.");
            }
            var lDSMember = await _context.LDSMember.FindAsync(id);
            if (lDSMember != null)
            {
                _context.LDSMember.Remove(lDSMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LDSMemberExists(int id)
        {
          return (_context.LDSMember?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
