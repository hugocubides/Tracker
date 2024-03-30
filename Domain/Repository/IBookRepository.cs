using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Repository
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAll();
        public Task<Book> GetOne(int? id);
        public int Add(Book objeto);
        public int Remove(Book objeto);
        public int Update(Book objeto);

    }
}
