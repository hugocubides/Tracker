using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackerDomain.Data;
using TrackerDomain.Dto;
using TrackerDomain.Models;
using TrackerDomain.Services;

namespace TrackerApp.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly TrackerAppBDContext _context;
        private readonly IBookServices _service;
        private readonly IStatusServices _statusServices;

        public BooksController(TrackerAppBDContext context, IBookServices service, IStatusServices statusServices)
        {
            _context = context;
            _service = service;
            _statusServices = statusServices;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Book = await _service.GetOneResponse(id);
            if (Book == null)
            {
                return NotFound();
            }

            return View(Book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            ViewData["StatusId"] = new SelectList(await _statusServices.GetAll(), "Id", "StatusName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,Owner,Balance,StatusId")] BookDtoRequest Book)
        {
            if (ModelState.IsValid)
            {
                _service.Add(Book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(await _statusServices.GetAll(), "Id", "StatusName", Book.StatusId);
            return View(Book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Book = await _service.GetOneRequest(id);
            if (Book == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(await _statusServices.GetAll(), "Id", "StatusName", Book.StatusId);
            return View(Book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,Owner,Balance,StatusId")] BookDtoRequest Book)
        {
            if (id != Book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(Book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(Book.Id))
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
            ViewData["StatusId"] = new SelectList(await _service.GetAll(), "Id", "StatusName", Book.StatusId);
            return View(Book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Book = await _service.GetOneResponse(id);
            if (Book == null)
            {
                return NotFound();
            }

            return View(Book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Book = await _service.GetOneRequest(id);
            if (Book != null)
            {
                _service.Remove(Book);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
