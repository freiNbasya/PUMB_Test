using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUMB_Test.Data;
using PUMB_Test.Models;

namespace PUMB_Test.Controllers
{
    public class ContactsModelsController : Controller
    {
        private readonly PUMB_TestContext _context;

        public ContactsModelsController(PUMB_TestContext context)
        {
            _context = context;
        }

        // GET: ContactsModels
        public async Task<IActionResult> Index()
        {
              return _context.ContactsModel != null ? 
                          View(await _context.ContactsModel.ToListAsync()) :
                          Problem("Entity set 'PUMB_TestContext.ContactsModel'  is null.");
        }

        // GET: ContactsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactsModel == null)
            {
                return NotFound();
            }

            var contactsModel = await _context.ContactsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactsModel == null)
            {
                return NotFound();
            }

            return View(contactsModel);
        }

        // GET: ContactsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,PhoneNumber")] ContactsModel contactsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactsModel);
        }

        // GET: ContactsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactsModel == null)
            {
                return NotFound();
            }

            var contactsModel = await _context.ContactsModel.FindAsync(id);
            if (contactsModel == null)
            {
                return NotFound();
            }
            return View(contactsModel);
        }

        // POST: ContactsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email,PhoneNumber")] ContactsModel contactsModel)
        {
            if (id != contactsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactsModelExists(contactsModel.Id))
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
            return View(contactsModel);
        }

        // GET: ContactsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactsModel == null)
            {
                return NotFound();
            }

            var contactsModel = await _context.ContactsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactsModel == null)
            {
                return NotFound();
            }

            return View(contactsModel);
        }

        // POST: ContactsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactsModel == null)
            {
                return Problem("Entity set 'PUMB_TestContext.ContactsModel'  is null.");
            }
            var contactsModel = await _context.ContactsModel.FindAsync(id);
            if (contactsModel != null)
            {
                _context.ContactsModel.Remove(contactsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactsModelExists(int id)
        {
          return (_context.ContactsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
