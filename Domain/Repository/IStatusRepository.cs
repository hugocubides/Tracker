using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Repository
{
    public interface IStatusRepository
    {
        public Task<List<Status>> GetAll();
        public Task<Status> GetOne(int? id);
        public int Add(Status objeto);
        public int Remove(Status objeto);
        public int Update(Status objeto);


    }
}
