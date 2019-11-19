using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMeetingPlanner.Data;
using MVCMeetingPlanner.Models;

namespace MVCMeetingPlanner.Controllers
{
    public class TimeplannerModelsController : Controller
    {
        private readonly MVCMeetingPlannerContext _context;

        public TimeplannerModelsController(MVCMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: TimeplannerModels
        public async Task<IActionResult> Index(string sortPeoples, string sortTitels, string searchString)
        {

            IQueryable<string> titleeQuery = from m in _context.TimeplannerModel
                                            orderby m.Title
                                            select m.Title;


            IQueryable<string> peopleQuery = from c in _context.TimeplannerModel
                                             orderby c.People
                                             select c.People;

            var title = from m in _context.TimeplannerModel
                           select m;


            var people = from c in _context.TimeplannerModel
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                title = title.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(sortTitels))
            {
                title = title.Where(x => x.Title == sortTitels);
            }

            if (!String.IsNullOrEmpty(sortPeoples))
            {
                people = people.Where(x => x.Title == sortPeoples);
            }

            var meetingTitleVW = new MeetingTitleViewModel
            {
                SortTitels = new SelectList(await titleeQuery.Distinct().ToListAsync()),
                TimeplannerModels = await title.ToListAsync()
            };

            var meeingTitleVW = new MeetingTitleViewModel
            {
                SortPeoples = new SelectList(await peopleQuery.Distinct().ToListAsync()),
                TimeplannerModels = await people.ToListAsync()
            };
            return View(meeingTitleVW);
        }

        // GET: TimeplannerModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeplannerModel = await _context.TimeplannerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeplannerModel == null)
            {
                return NotFound();
            }

            return View(timeplannerModel);
        }

        // GET: TimeplannerModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeplannerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,People,TimeStart,TimeEnd")] TimeplannerModel timeplannerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeplannerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeplannerModel);
        }

        // GET: TimeplannerModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeplannerModel = await _context.TimeplannerModel.FindAsync(id);
            if (timeplannerModel == null)
            {
                return NotFound();
            }
            return View(timeplannerModel);
        }

        // POST: TimeplannerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,People,TimeStart,TimeEnd")] TimeplannerModel timeplannerModel)
        {
            if (id != timeplannerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeplannerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeplannerModelExists(timeplannerModel.Id))
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
            return View(timeplannerModel);
        }

        // GET: TimeplannerModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeplannerModel = await _context.TimeplannerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeplannerModel == null)
            {
                return NotFound();
            }

            return View(timeplannerModel);
        }

        // POST: TimeplannerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeplannerModel = await _context.TimeplannerModel.FindAsync(id);
            _context.TimeplannerModel.Remove(timeplannerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeplannerModelExists(int id)
        {
            return _context.TimeplannerModel.Any(e => e.Id == id);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
