using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Services
{
    public interface IMovementServices
    {
        public Task<List<MovementDtoResponse>> GetAll();
        public Task<List<MovementDtoResponse>> GetAllByMovementType(int id);
        public Task<MovementDtoResponse> GetOneResponse(int? id);
        public Task<MovementDtoRequest> GetOneRequest(int? id);
        public int AddIncome(MovementDtoRequest objeto);
        public int RemoveIncome(MovementDtoRequest objeto);
        public int UpdateIncome(MovementDtoRequest objeto);
        public int AddExpense(MovementDtoRequest objeto);
        public int RemoveExpense(MovementDtoRequest objeto);
        public int UpdateExpense(MovementDtoRequest objeto);
        public int AddTransfer(MovementDtoRequest objeto);
        public int RemoveTransfer(MovementDtoRequest objeto);
        public int UpdateTransfer(MovementDtoRequest objeto);



    }

}
