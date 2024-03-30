using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Services
{
    public interface IMovementTypeServices
    {
        public Task<List<MovementTypeDtoResponse>> GetAll();
        public Task<MovementTypeDtoResponse> GetOneResponse(int? id);
        public Task<MovementTypeDtoRequest> GetOneRequest(int? id);
        public Task<List<MovementTypeDtoRequest>> GetOneRequestList(int? id);
        public int Add(MovementTypeDtoRequest objeto);
        public int Remove(MovementTypeDtoRequest objeto);
        public int Update(MovementTypeDtoRequest objeto);

    }

}
