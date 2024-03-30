using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    [Authorize(Roles ="Manager")]
    public class StatusController : Controller
    {
        private readonly IStatusServices _service;
        private readonly TrackerAppBDContext _context;

        public StatusController(IStatusServices service, TrackerAppBDContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _service.GetOneResponse(id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName")] StatusDtoRequest statusDtoRequest)
        {
            if (ModelState.IsValid)
            {
                var rta = _service.Add(statusDtoRequest);
                if (rta == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View(statusDtoRequest);
            }
            return View(statusDtoRequest);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _service.GetOneRequest(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusName,Id")] StatusDtoRequest status)
        {
            if (id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var rta = _service.Update(status);
                    if (rta == 0)
                        return View(status);
                    // falta adicionar el mensaje
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.Id))
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
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _service.GetOneResponse(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _service.GetOneRequest(id);
            if (status != null)
            {
                _service.Remove(status);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.Id == id);
        }
    }
}
