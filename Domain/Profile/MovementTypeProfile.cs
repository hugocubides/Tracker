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
    public class MovementTypeProfile : AutoMapper.Profile
    {
        public MovementTypeProfile()
        {
            CreateMap<MovementType, MovementTypeDtoRequest>().ReverseMap();
            CreateMap<MovementType, MovementTypeDtoResponse>().ReverseMap();
        }
    }
}
