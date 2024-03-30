using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Services
{
    public interface IBookServices
    {
        public Task<List<BookDtoResponse>> GetAll();
        public Task<BookDtoResponse> GetOneResponse(int? id);
        public Task<BookDtoRequest> GetOneRequest(int? id);
        public int Add(BookDtoRequest objeto);
        public int Remove(BookDtoRequest objeto);
        public int Update(BookDtoRequest objeto);
    

    }

}
