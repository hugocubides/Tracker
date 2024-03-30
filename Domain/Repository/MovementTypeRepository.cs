using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TrackerDomain.Models;

namespace TrackerDomain.Repository
{

    public class MovementTypeRepository : IMovementTypeRepository
    {

        private readonly TrackerAppBDContext _context;

        public MovementTypeRepository(TrackerAppBDContext context)
        {
            _context = context;
        }

        public async Task<List<MovementType>> GetAll()
        {
            return await _context.MovementType
                .Include(s => s.Status)
                .ToListAsync();
        }

        public async Task<MovementType> GetOne(int? id)
        {
            return await _context.MovementType
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public int Add(MovementType objeto)
        {
            _context.Add(objeto);
            return _context.SaveChanges();
        }

        public int Update(MovementType objeto)
        {
            _context.ChangeTracker.Clear();
            _context.Update(objeto);
            return _context.SaveChanges();
        }

        public int Remove(MovementType objeto)
        {
            _context.ChangeTracker.Clear();
            _context.Remove(objeto);
            return _context.SaveChanges();
        }

        public async Task<List<MovementType>> GetOneList(int? id)
        {
            return await _context.MovementType.Where(m => m.Id == id).ToListAsync();

        }
    }
}
