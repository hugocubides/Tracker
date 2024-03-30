using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Repository
{
    public interface IMovementTypeRepository
    {
        public Task<List<MovementType>> GetAll();
        public Task<MovementType> GetOne(int? id);
        public Task<List<MovementType>> GetOneList(int? id);
        public int Add(MovementType objeto);
        public int Remove(MovementType objeto);
        public int Update(MovementType objeto);


    }
}
