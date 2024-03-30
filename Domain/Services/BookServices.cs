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
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _repositorio;
        private readonly IMapper _mapper;

        public BookServices(IBookRepository repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<BookDtoResponse>> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return _mapper.Map<List<BookDtoResponse>>(lista);
        }

        public async Task<BookDtoResponse> GetOneResponse(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<BookDtoResponse>(status);
        }

        public async Task<BookDtoRequest> GetOneRequest(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<BookDtoRequest>(status);
        }

        public int Add(BookDtoRequest objeto)
        {
            var Objeto2 = _mapper.Map<Book>(objeto);
            Objeto2.CreatedAt = DateTime.Now;
            Objeto2.UpdatedAt = DateTime.Now;
            Objeto2.CreatedBy = "ugo";
            Objeto2.UpdatedBy = "ugo";
            return _repositorio.Add(Objeto2);
        }

        public int Remove(BookDtoRequest objeto)
        {
            var objeto2 = _mapper.Map<Book>(objeto);
            return _repositorio.Remove(objeto2);
        }

        public int Update(BookDtoRequest objeto)
        {
            var statusInicial = GetOneResponse(objeto.Id);
            var objeto2 = _mapper.Map<Book>(objeto);
            objeto2.CreatedAt = statusInicial.Result.CreatedAt;
            objeto2.UpdatedAt = DateTime.Now;
            objeto2.CreatedBy = statusInicial.Result.CreatedBy;
            objeto2.UpdatedBy = "ugo";
            return _repositorio.Update(objeto2);
        }

    }
}
