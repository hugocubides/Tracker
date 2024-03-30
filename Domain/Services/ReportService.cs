using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Repository;

namespace TrackerDomain.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;
        public ReportService(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<MovementDtoResponse>> TopLastFiveExpense(string user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovementDtoResponse>> TopLastFiveIncome(string user)
        {
            var lista = await _repository.TopLastFiveIncome(user);
            return _mapper.Map<List<MovementDtoResponse>>(lista);
        }

        public Task<List<MovementDtoResponse>> TopLastFiveTransfer(string user)
        {
            throw new NotImplementedException();
        }
    }
}
