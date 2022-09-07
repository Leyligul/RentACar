using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Model içindeki BrandName parametresi, Model içindeki Brand'in Name'inden gelecektir.
            //Maplenebilmesi için ForMember kısmı yazıldı.
            //opt -> option'nın kısaltılmış hali
            CreateMap<Model, ModelListDto>().ForMember( c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();

            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}
