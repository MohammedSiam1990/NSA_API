using AutoMapper;
using POS.Account;
using POS.API.Models;
using POS.DTO;
using POS.Entities;
using POS.Models;
using System.Linq;

namespace POS.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Companies, CompaniesModel>();
            CreateMap<CompaniesModel, Companies>();
            CreateMap<Brands, BrandsModel>();
            CreateMap<BrandsModel, Brands>();
            CreateMap<Brands, BrandsDto>();
            CreateMap<BrandsDto, Brands>();
            CreateMap<ItemGroup, ItemGroupsModel>();
            CreateMap<ItemGroupsModel, ItemGroup>();

        }
    }
}