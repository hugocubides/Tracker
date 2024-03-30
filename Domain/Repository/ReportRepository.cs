using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Data;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly TrackerAppBDContext _context;

        public ReportRepository(TrackerAppBDContext context)
        {
            _context = context;
        }

        public Task<List<Movement>> TopLastFiveExpense(string user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movement>> TopLastFiveIncome(string user)
        {
            return await _context.Movement
            .Include(t => t.MovementType)
            .Include(s => s.SourceBook)
            .Include(d => d.DestinationBook)
            .Include(d => d.DestinationOtherBook)
            .Include(p => p.ParentMovement)
            .Include(p => p.PayMovement)
            .Include(s => s.Status)
            .ToListAsync();
            /*
            return await _context.Movement
             .Include(t => t.MovementType)
             .Include(s => s.SourceBook)
             .Include(s => s.Status)
             .Where(t => t.MovementTypeId == 1)
             .Where(m => m.SourceBook.Owner == user)
             .OrderByDescending(t => t.CreatedAt)
             .Take(5)
             .ToListAsync();
            */
        }

        public Task<List<Movement>> TopLastFiveTransfer(string user)
        {
            throw new NotImplementedException();
        }
    }
}
