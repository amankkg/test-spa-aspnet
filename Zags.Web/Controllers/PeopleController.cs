using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zags.Web.Models;
using Zags.Web.Services;

namespace Zags.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ZagsDbContext _context;
        private readonly PinService pinService;

        public PeopleController(ZagsDbContext context, PinService pinService)
        {
            _context = context;
            this.pinService = pinService;
        }

        // GET: People?search=foobar&order=firstName
        public async Task<IActionResult> Index([FromQuery] SearchQuery search)
        {
            var request = _context.People as IQueryable<Person>;

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                request = request.Where(x =>
                    x.FirstName.Contains(search.Keyword, StringComparison.OrdinalIgnoreCase)
                    || x.LastName.Contains(search.Keyword, StringComparison.OrdinalIgnoreCase)
                    || x.PIN.Contains(search.Keyword, StringComparison.OrdinalIgnoreCase));
            }

            switch (search.OrderBy)
            {
                case PersonOrderBy.FirstName:
                    request = request.OrderBy(x => x.FirstName);
                    break;
                case PersonOrderBy.LastName:
                    request = request.OrderBy(x => x.LastName);
                    break;
                case PersonOrderBy.BirthDate:
                    request = request.OrderBy(x => x.BirthDate);
                    break;
                case PersonOrderBy.PIN:
                default:
                    request = request.OrderBy(x => x.PIN);
                    break;
            }

            var list = await request.ToListAsync();

            var data = new SearchViewModel { People = list, Search = search };

            return View(data);
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonSubmitModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var lastId = (await _context.People.LastOrDefaultAsync())?.Id ?? 0;

            var person = new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                BirthDate = model.BirthDate,
                Gender = model.Gender,
                PIN = pinService.Generate(model.Gender, model.BirthDate, lastId + 1)
            };

            _context.Add(person);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.People.FindAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
