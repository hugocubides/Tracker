using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrackerDomain.Dto;
using TrackerDomain.Models;

namespace TrackerDomain.Profile
{
    public class MovementProfile : AutoMapper.Profile
    {
        public MovementProfile()
        {
            CreateMap<Movement, MovementDtoRequest>().ReverseMap();
            CreateMap<Movement, MovementDtoResponse>().ReverseMap();
        }
    }
}
