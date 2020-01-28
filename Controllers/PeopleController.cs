﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Data;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PersonManagementContext _context;

        public PeopleController(PersonManagementContext context)
        {
            _context = context;
        }

        // GET: People
/*public async Task<IActionResult> Index()
{
    var personManagementContext = _context.Person.Include(p => p.Department).Include(p => p.Position);
    return View(await personManagementContext.ToListAsync());
}*/

// GET: People/Arne
public async Task<IActionResult> Index(string searchString)
{
            var people = from p in _context.Person select p;
                          /*select new Person
                         {
                             Name = p.Name,
                             Mobil = p.Mobil,
                             Street = p.Street,
                             Streetnumber = p.Streetnumber,
                             Postnumber = p.Postnumber,
                             City = p.City,
                             Province = p.Province,
                             Email = p.Email,
                             Department = p.Department,
                             Position = p.Position
                         };
            /*var people = from p in _context.Person
             join d in _context.Department on p.DepartmentId equals d.DepartmentId
             join o in _context.Position on p.PositionId equals o.PositionId
             select new FullPersonInfor
             {
                 Name = p.Name,
                 Mobil = p.Mobil,
                 Street = p.Street,
                 Streetnumber = p.Streetnumber,
                 Postnumber = p.Postnumber,
                 City = p.City,
                 Province = p.Province,
                 Email = p.Email,
                 DepartmentName = d.DepartmentName,
                 PositionName = o.PositionName
             };/*/


if (!String.IsNullOrEmpty(searchString))
{
people = people.Where(p => p.Name.Contains(searchString));
}

return View(await people.ToListAsync());
}

// GET: People/Leaders
public async Task<IActionResult> Leaders()
{
var personManagementContext = from e in _context.Person
                          join d in _context.Department
                          on e.DepartmentId equals d.DepartmentId where e.PositionId == 1
                          select new Leader
                          {
                              Name = e.Name,
                              Mobil = e.Mobil,
                              Email = e.Email,
                              DepartmentName = d.DepartmentName,
                              PersonId = e.PersonId
                          };

                    return View(await personManagementContext.ToListAsync());
                    }
// GET: People/Salers
public async Task<IActionResult> Salers()
{
var personManagementContext = from e in _context.Person
                              join d in _context.Department
                              on e.DepartmentId equals d.DepartmentId
                              where e.PositionId == 2
                              select new Saler
                              {
                                  Name = e.Name,
                                  Mobil = e.Mobil,
                                  Email = e.Email,
                                  DepartmentName = d.DepartmentName,
                                  PersonId = e.PersonId
                              };

return View(await personManagementContext.ToListAsync());
}

// GET: People/Details/5
public async Task<IActionResult> Details(int? id)
{
if (id == null)
{
return NotFound();
}

var person = await _context.Person
.Include(p => p.Department)
.Include(p => p.Position)
.FirstOrDefaultAsync(m => m.PersonId == id);
if (person == null)
{
return NotFound();
}

return View(person);
}

// GET: People/Create
public IActionResult Create()
{
ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionName");
return View();
}

// POST: People/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("PersonId,Mobil,Name,Street,Streetnumber,Postnumber,City,Province,Email,DepartmentId,PositionId")] Person person)
{
if (ModelState.IsValid)
{
_context.Add(person);
await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));
}
ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", person.DepartmentId);
ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionName", person.PositionId);
return View(person);
}

// GET: People/Edit/5
public async Task<IActionResult> Edit(int? id)
{
if (id == null)
{
return NotFound();
}

var person = await _context.Person.FindAsync(id);
if (person == null)
{
return NotFound();
}
ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", person.DepartmentId);
ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionName", person.PositionId);
return View(person);
}

// POST: People/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("PersonId,Mobil,Name,Street,Streetnumber,Postnumber,City,Province,Email,DepartmentId,PositionId")] Person person)
{
if (id != person.PersonId)
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
if (!PersonExists(person.PersonId))
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
ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", person.DepartmentId);
ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionName", person.PositionId);
return View(person);
}

// GET: People/Delete/5
public async Task<IActionResult> Delete(int? id)
{
if (id == null)
{
return NotFound();
}

var person = await _context.Person
.Include(p => p.Department)
.Include(p => p.Position)
.FirstOrDefaultAsync(m => m.PersonId == id);
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
var person = await _context.Person.FindAsync(id);
_context.Person.Remove(person);
await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));
}

private bool PersonExists(int id)
{
return _context.Person.Any(e => e.PersonId == id);
}
}
}
