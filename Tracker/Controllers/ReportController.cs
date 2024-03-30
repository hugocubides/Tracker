using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrackerDomain.Dto;
using TrackerDomain.Models;
using TrackerDomain.Services;

namespace TrackerApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReportService _context;
        private readonly IMovementServices _servicio;
        private readonly IBookServices _BookServices;

        public ReportController(ILogger<HomeController> logger, IReportService context,
            IMovementServices servicio, IBookServices BookServices)
        {
            _logger = logger;
            _context = context;
            _servicio = servicio;
            _BookServices = BookServices;
        }

        public async Task<IActionResult> Index()
        {
            var listIncome = await _servicio.GetAllByMovementType(1);
            var listExpense = await _servicio.GetAllByMovementType(2);
            var listTransfer = await _servicio.GetAllByMovementType(3);
            var listBook = await _BookServices.GetAll();

            //var lista = await _context.TopLastFiveIncome("ugo");
            MovementDtoList listDto = new MovementDtoList();
            listDto.listIncomeMovements = listIncome;
            listDto.listExpenseMovements = listExpense;
            listDto.listTransferMovements = listTransfer;
            listDto.listBook = listBook;
            return View(listDto);
        }

    }
}
