using AutoMapper;
using DataModel.Entities;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Profilies
{
    public class DefaultAutoMapperProfile : Profile
    {
        public DefaultAutoMapperProfile()
        {
            CreateMap<Hero, HeroesModel>()
                .ForMember(x => x.HeroId, opt => opt.MapFrom(m => m.Id))
                //.ForMember(x => x.HeroName, opt => opt.MapFrom(m => m.HeroName))
                .ReverseMap();
        }
    }
}
