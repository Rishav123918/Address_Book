using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class AddressBookController : Controller
    {
        private readonly DataContext _context;

        public AddressBookController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string name, string lastName, string address, string phone)
        {
            var person = from p in _context.Person select p;

            if (!String.IsNullOrEmpty(name))
                person = person.Where(p => p.Name.Contains(name));

            if (!String.IsNullOrEmpty(lastName))
                person = person.Where(p => p.LastName.Contains(lastName));

            if (!String.IsNullOrEmpty(address))
                person = person.Where(p => p.Address.Contains(address));

            if (!String.IsNullOrEmpty(phone))
                person = person.Where(p => p.PhoneNumber.Contains(phone));

            return View(await person.ToListAsync());
        }

        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Address,PhoneNumber")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.Person.FindAsync(id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Address,PhoneNumber")] Person person)
        {
            if (id != person.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Person.Any(p => p.Id == person.Id))
                        return NotFound();

                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return NotFound();

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> JSON()
        {
            // Different OS have different paths to home directory
            string homePath = (
                Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX)
    ? Environment.GetEnvironmentVariable("HOME")
    : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var json = JsonConvert.SerializeObject(_context.Person, Formatting.Indented);
            System.IO.File.WriteAllText(homePath + "/data.json", json);

            return RedirectToAction(nameof(Index));
        }
    }
}
