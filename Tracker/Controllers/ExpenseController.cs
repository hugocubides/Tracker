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

    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly TrackerAppBDContext _context;
        private readonly IMovementServices _servicio;
        private readonly IBookServices _Book;
        private readonly IMovementTypeServices _movementType;
        private readonly IMapper _mapper;

        public ExpenseController(TrackerAppBDContext context, 
            IMovementServices servicio,
            IBookServices Book,
            IMapper mapper,
            IMovementTypeServices movementType)
        {
            _context = context;
            _servicio = servicio;
            _Book = Book;
            _mapper = mapper;
            _movementType = movementType;
        }

        // GET: Movements
        public async Task<IActionResult> Index()
        {
            /*
            var trackerAppContext = _context.Movement
                .Include(m => m.DestinationBook)
                .Include(m => m.DestinationOtherBook)
                .Include(m => m.MovementType)
                .Include(m => m.ParentMovement)
                .Include(m => m.PayMovement)
                .Include(m => m.SourceBook)
                .Include(m => m.Status);
            */
            return View(await _servicio.GetAllByMovementType(2));
        }


        // GET: Movements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movement = await _servicio.GetOneResponse(id); 
            if (movement == null)
            {
                return NotFound();
            }

            return View(movement);
        }

        // GET: Movements/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SourceBookId"] = new SelectList(await _Book.GetAll(), "Id", "BookName");
            //ViewData["DestinationBookId"] = new SelectList(await _Book.GetAll(), "Id", "BookName");
            //ViewData["DestinationOtherBookId"] = new SelectList(await _Book.GetAll(), "Id", "BookName");
            //ViewData["MovementTypeId"] = new SelectList(_context.MovementType, "Id", "MovementTypeName");
            //ViewData["ParentMovementId"] = new SelectList(_context.Movement, "Id", "Detail");
            //ViewData["PayMovementId"] = new SelectList(_context.Movement, "Id", "Detail");
            //ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusName");
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovementDate,Entity,MovementTypeId,Detail,SourceBookId,DestinationBookId," +
            "DestinationOtherBookId,Value,Balance,ParentMovementId,IsShared,PayMovementId,StatusId")] MovementDtoRequest movement)
        {
            movement.MovementTypeId = 2;

            if (ModelState.IsValid)
            {
                _servicio.AddExpense(movement);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovementTypeId"] = new SelectList(await _movementType.GetOneRequestList(1), "Id", "MovementName", movement.MovementTypeId);
            ViewData["SourceBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.SourceBookId);
            //ViewData["DestinationBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.DestinationBookId);
            //ViewData["DestinationOtherBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.DestinationOtherBookId);
            //ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusName", movement.StatusId);
            //ViewData["ParentMovementId"] = new SelectList(_context.Movement, "Id", "Details", movement.ParentMovementId);
            //ViewData["PayMovementId"] = new SelectList(_context.Movement, "Id", "Details", movement.PayMovementId);
            return View(movement);
        }

        // GET: Movements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movement = await _servicio.GetOneRequest(id);
            if (movement == null)
            {
                return NotFound();
            }
            //ViewData["DestinationBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.DestinationBookId);
            //ViewData["DestinationOtherBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.DestinationOtherBookId);
            ViewData["MovementTypeId"] = new SelectList(await _movementType.GetOneRequestList(1), "Id", "MovementName", movement.MovementTypeId);
            //ViewData["ParentMovementId"] = new SelectList(_context.Movement, "Id", "CreatedBy", movement.ParentMovementId);
            //ViewData["PayMovementId"] = new SelectList(_context.Movement, "Id", "CreatedBy", movement.PayMovementId);
            ViewData["SourceBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.SourceBookId);
            //ViewData["StatusId"] = new SelectList(_context.Status, "Id", "StatusName", movement.StatusId);
            return View(movement);
        }

        // POST: Movements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovementDate,Entity,MovementTypeId,Detail," +
                    "SourceBookId,DestinationBookId,DestinationOtherBookId,Value,Balance," +
                    "ParentMovementId,IsShared,PayMovementId,StatusId")] MovementDtoRequest movement)
        {
            if (id != movement.Id)
            {
                return NotFound();
            }
            movement.MovementTypeId = 2;

            if (ModelState.IsValid)
            {
                try
                {
                    _servicio.UpdateExpense(movement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovementExists(movement.Id))
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
            //ViewData["DestinationBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.DestinationBookId);
            //ViewData["DestinationOtherBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.DestinationOtherBookId);
            ViewData["MovementTypeId"] = new SelectList(await _movementType.GetOneRequestList(1), "Id", "MovementName", movement.MovementTypeId);
            //ViewData["ParentMovementId"] = new SelectList(_context.Movement, "Id", "CreatedBy", movement.ParentMovementId);
            //ViewData["PayMovementId"] = new SelectList(_context.Movement, "Id", "CreatedBy", movement.PayMovementId);
            ViewData["SourceBookId"] = new SelectList(_context.Book, "Id", "BookName", movement.SourceBookId);
            //ViewData["StatusId"] = new SelectList(_context.Status, "Id", "CreatedBy", movement.StatusId);
            return View(movement);
        }

        // GET: Movements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movement = await _servicio.GetOneResponse(id);
            if (movement == null)
            {
                return NotFound();
            }

            return View(movement);
        }

        // POST: Movements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movement = await _servicio.GetOneRequest(id);
            if (movement != null)
            {
                _servicio.RemoveExpense(movement);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MovementExists(int id)
        {
            return _context.Movement.Any(e => e.Id == id);
        }
    }
}
