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
    [Authorize(Roles = "Manager")]
    public class MovementTypesController : Controller
    {
        private readonly TrackerAppBDContext _context;
        private readonly IMovementTypeServices _service;
        private readonly IStatusServices _statusService;
        private readonly IMapper _mapper;

        public MovementTypesController(TrackerAppBDContext context, 
            IMovementTypeServices service, 
            IMapper mapper, IStatusServices statusService)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
            _statusService = statusService;

        }

        // GET: MovementTypes
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: MovementTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movementType = await _service.GetOneResponse(id);
            if (movementType == null)
            {
                return NotFound();
            }

            return View(movementType);
        }

        // GET: MovementTypes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["StatusId"] = new SelectList(await _statusService.GetAll(), "Id", "StatusName");
            return View();
        }

        // POST: MovementTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovementTypeName,StatusId")] MovementTypeDtoRequest movementType)
        {
            if (ModelState.IsValid)
            {
                _service.Add(movementType);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(await _statusService.GetAll(), "Id", "StatusName", movementType.StatusId);
            return View(movementType);
        }

        // GET: MovementTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movementType = await _service.GetOneRequest(id);
            if (movementType == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(await _statusService.GetAll(), "Id", "StatusName", movementType.StatusId);
            return View(movementType);
        }

        // POST: MovementTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovementTypeName,StatusId")] MovementTypeDtoRequest movementType)
        {
            if (id != movementType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(movementType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovementTypeExists(movementType.Id))
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
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusName", movementType.StatusId);
            return View(movementType);
        }

        // GET: MovementTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movementType = await _service.GetOneResponse(id);
            if (movementType == null)
            {
                return NotFound();
            }

            return View(movementType);
        }

        // POST: MovementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movementType = await _service.GetOneRequest(id);
            if (movementType != null)
            {
                _service.Remove(movementType);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MovementTypeExists(int id)
        {
            return _context.MovementType.Any(e => e.Id == id);
        }
    }
}
