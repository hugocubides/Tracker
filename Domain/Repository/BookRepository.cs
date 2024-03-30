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

    public class BookRepository : IBookRepository
    {

        private readonly TrackerAppBDContext _context;

        public BookRepository(TrackerAppBDContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.Book
                .Include(s => s.Status)
                .ToListAsync();
        }

        public async Task<Book> GetOne(int? id)
        {
            return await _context.Book
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public int Add(Book objeto)
        {
            _context.Add(objeto);
            return _context.SaveChanges();
        }

        public int Update(Book objeto)
        {
            _context.ChangeTracker.Clear();
            _context.Update(objeto);
            return _context.SaveChanges();
        }

        public int Remove(Book objeto)
        {
            _context.ChangeTracker.Clear();
            _context.Remove(objeto);
            return _context.SaveChanges();
        }

    }
}
