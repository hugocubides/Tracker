using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Repository
{
    public interface IReportRepository
    {
        public Task<List<Movement>> TopLastFiveIncome(string user);
        public Task<List<Movement>> TopLastFiveExpense(string user);
        public Task<List<Movement>> TopLastFiveTransfer(string user);

    }
}
