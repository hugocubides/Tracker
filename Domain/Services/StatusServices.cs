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
    public class StatusServices : IStatusServices
    {
        private readonly IStatusRepository _repositorio;
        private readonly IMapper _mapper;

        public StatusServices(IStatusRepository repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<StatusDtoResponse>> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return _mapper.Map<List<StatusDtoResponse>>(lista);
        }


        public async Task<StatusDtoResponse> GetOneResponse(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<StatusDtoResponse>(status);
        }

        public async Task<StatusDtoRequest> GetOneRequest(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<StatusDtoRequest>(status);
        }

        public int Add(StatusDtoRequest objeto)
        {
            var Objeto2 = _mapper.Map<Status>(objeto);
            Objeto2.CreatedAt = DateTime.Now;
            Objeto2.UpdatedAt = DateTime.Now;
            Objeto2.CreatedBy = "ugo";
            Objeto2.UpdatedBy = "ugo";
            return _repositorio.Add(Objeto2);
        }

        public int Remove(StatusDtoRequest objeto)
        {
            var objeto2 = _mapper.Map<Status>(objeto);
            return _repositorio.Remove(objeto2);
        }

        public int Update(StatusDtoRequest objeto)
        {
            var ObjInicial = GetOneResponse(objeto.Id);

            if (ObjInicial.Result != null)
            {
                var Objeto2 = _mapper.Map<Status>(objeto);
                Objeto2.CreatedAt = ObjInicial.Result.CreatedAt;
                Objeto2.UpdatedAt = DateTime.Now;
                Objeto2.CreatedBy = ObjInicial.Result.CreatedBy;
                Objeto2.UpdatedBy = "ugo";
                return _repositorio.Update(Objeto2);
            }
            return 0;
        }


    }
}
