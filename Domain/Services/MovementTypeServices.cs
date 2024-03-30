using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Models;
using TrackerDomain.Repository;

namespace TrackerDomain.Services
{
    public class MovementTypeServices : IMovementTypeServices
    {
        private readonly IMovementTypeRepository _repositorio;
        private readonly IMapper _mapper;

        public MovementTypeServices(IMovementTypeRepository repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<MovementTypeDtoResponse>> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return _mapper.Map<List<MovementTypeDtoResponse>>(lista);
        }

        public async Task<MovementTypeDtoResponse> GetOneResponse(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<MovementTypeDtoResponse>(status);
        }

        public async Task<MovementTypeDtoRequest> GetOneRequest(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<MovementTypeDtoRequest>(status);
        }

        public int Add(MovementTypeDtoRequest objeto)
        {
            var Objeto2 = _mapper.Map<MovementType>(objeto);
            Objeto2.CreatedAt = DateTime.Now;
            Objeto2.UpdatedAt = DateTime.Now;
            Objeto2.CreatedBy = "ugo";
            Objeto2.UpdatedBy = "ugo";
            return _repositorio.Add(Objeto2);
        }

        public int Remove(MovementTypeDtoRequest objeto)
        {
            var objeto2 = _mapper.Map<MovementType>(objeto);
            return _repositorio.Remove(objeto2);
        }

        public int Update(MovementTypeDtoRequest objeto)
        {
            var statusInicial = GetOneResponse(objeto.Id);
            var objeto2 = _mapper.Map<MovementType>(objeto);
            objeto2.CreatedAt = statusInicial.Result.CreatedAt;
            objeto2.UpdatedAt = DateTime.Now;
            objeto2.CreatedBy = statusInicial.Result.CreatedBy;
            objeto2.UpdatedBy = "ugo";
            return _repositorio.Update(objeto2);
        }

        public async Task<List<MovementTypeDtoRequest>> GetOneRequestList(int? id)
        {
            var status = await _repositorio.GetOneList(id);
            return _mapper.Map<List<MovementTypeDtoRequest>>(status);

        }
    }
}
