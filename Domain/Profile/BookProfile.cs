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
    public class BookProfile : AutoMapper.Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDtoRequest>().ReverseMap();
            CreateMap<Book, BookDtoResponse>().ReverseMap();
        }
    }
}
