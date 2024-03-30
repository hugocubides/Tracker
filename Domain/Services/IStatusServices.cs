using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Services
{
    public interface IStatusServices
    {
        public Task<List<StatusDtoResponse>> GetAll();
        public Task<StatusDtoResponse> GetOneResponse(int? id);
        public Task<StatusDtoRequest> GetOneRequest(int? id);
        public int Add(StatusDtoRequest objeto);
        public int Remove(StatusDtoRequest objeto);
        public int Update(StatusDtoRequest objeto);

    }

}
