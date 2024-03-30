using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Repository
{
    public interface IMovementRepository
    {
        public Task<List<Movement>> GetAll();
        public Task<List<Movement>> GetAllByMovementType(int id);
        public Task<Movement> GetOne(int? id);
        public int AddIncome(Movement objeto);
        public int RemoveIncome(Movement objeto);
        public int UpdateIncome(Movement objeto);
        public int AddExpense(Movement objeto);
        public int RemoveExpense(Movement objeto);
        public int UpdateExpense(Movement objeto);
        public int AddTransfer(Movement objeto);
        public int RemoveTransfer(Movement objeto);
        public int UpdateTransfer(Movement objeto);
    }
}
