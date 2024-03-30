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
    public class StatusProfile : AutoMapper.Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusDtoRequest>().ReverseMap();
            CreateMap<Status, StatusDtoResponse>().ReverseMap();
        }
    }
}
