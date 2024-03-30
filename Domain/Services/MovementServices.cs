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
    public class MovementServices : IMovementServices
    {
        private readonly IMovementRepository _repositorio;
        private readonly IMapper _mapper;

        public MovementServices(IMovementRepository repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<MovementDtoResponse>> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return _mapper.Map<List<MovementDtoResponse>>(lista);
        }

        public async Task<MovementDtoRequest> GetOneRequest(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<MovementDtoRequest>(status);
        }


        public async Task<MovementDtoResponse> GetOneResponse(int? id)
        {
            var status = await _repositorio.GetOne(id);
            return _mapper.Map<MovementDtoResponse>(status);
        }

        public int Add(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = DateTime.Now;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = "ugo";
            movement.UpdatedBy = "ugo";
            return _repositorio.AddIncome(movement);
        }

        public int Remove(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            return _repositorio.RemoveIncome(movement);
        }

        public int Update(MovementDtoRequest objeto)
        {
            var statusInicial = GetOneResponse(objeto.Id);
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = statusInicial.Result.CreatedAt;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = statusInicial.Result.CreatedBy;
            movement.UpdatedBy = "ugo";
            return _repositorio.UpdateIncome(movement);
        }

        public async Task<List<MovementDtoResponse>> GetAllByMovementType(int id)
        {
            var lista= await _repositorio.GetAllByMovementType(id);
            return _mapper.Map<List<MovementDtoResponse>>(lista);
        }

        public int AddIncome(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = DateTime.Now;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = "ugo";
            movement.UpdatedBy = "ugo";
            return _repositorio.AddIncome(movement);

        }

        public int RemoveIncome(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            movement.UpdatedAt = DateTime.Now;
            movement.UpdatedBy = "ugo";
            return _repositorio.RemoveIncome(movement);
        }

        public int UpdateIncome(MovementDtoRequest objeto)
        {
            var statusInicial = GetOneResponse(objeto.Id);
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = statusInicial.Result.CreatedAt;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = statusInicial.Result.CreatedBy;
            movement.UpdatedBy = "ugo";
            return _repositorio.UpdateIncome(movement);

        }

        public int AddExpense(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = DateTime.Now;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = "ugo";
            movement.UpdatedBy = "ugo";
            return _repositorio.AddExpense(movement);

        }

        public int RemoveExpense(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            movement.UpdatedAt = DateTime.Now;
            movement.UpdatedBy = "ugo";
            return _repositorio.RemoveExpense(movement);
        }

        public int UpdateExpense(MovementDtoRequest objeto)
        {
            var statusInicial = GetOneResponse(objeto.Id);
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = statusInicial.Result.CreatedAt;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = statusInicial.Result.CreatedBy;
            movement.UpdatedBy = "ugo";
            return _repositorio.UpdateExpense(movement);

        }

        public int AddTransfer(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = DateTime.Now;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = "ugo";
            movement.UpdatedBy = "ugo";
            return _repositorio.AddTransfer(movement);

        }

        public int RemoveTransfer(MovementDtoRequest objeto)
        {
            var movement = _mapper.Map<Movement>(objeto);
            movement.UpdatedAt = DateTime.Now;
            movement.UpdatedBy = "ugo";
            return _repositorio.RemoveTransfer(movement);
        }

        public int UpdateTransfer(MovementDtoRequest objeto)
        {
            var statusInicial = GetOneResponse(objeto.Id);
            var movement = _mapper.Map<Movement>(objeto);
            movement.StatusId = 1;
            movement.CreatedAt = statusInicial.Result.CreatedAt;
            movement.UpdatedAt = DateTime.Now;
            movement.CreatedBy = statusInicial.Result.CreatedBy;
            movement.UpdatedBy = "ugo";
            return _repositorio.UpdateTransfer(movement);

        }

    }
}
