using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Services
{
    public interface IReportService
    {
        public Task<List<MovementDtoResponse>> TopLastFiveIncome(string user);
        public Task<List<MovementDtoResponse>> TopLastFiveExpense(string user);
        public Task<List<MovementDtoResponse>> TopLastFiveTransfer(string user);
    }
}
