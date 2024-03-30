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

    public class StatusRepository : IStatusRepository
    {

        private readonly TrackerAppBDContext _context;

        public StatusRepository(TrackerAppBDContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAll()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<Status> GetOne(int? id)
        {
            return await _context.Status.FirstOrDefaultAsync(x => x.Id == id);
        }

        public int Add(Status objeto)
        {
            _context.Add(objeto);
            return _context.SaveChanges();
        }

        public int Update(Status objeto)
        {
            _context.ChangeTracker.Clear();
            _context.Update(objeto);
            return _context.SaveChanges();
        }

        public int Remove(Status objeto)
        {
            _context.ChangeTracker.Clear();
            _context.Remove(objeto);
            return _context.SaveChanges();
        }

    }
}
