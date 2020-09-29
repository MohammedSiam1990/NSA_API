using AutoMapper;
using POS.Account;
using POS.API.Models;
using POS.Data.Entities;
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
            CreateMap<Branches, BranchesModel>();
            CreateMap<BranchesModel, Branches>();
            CreateMap<ItemGroup, ItemGroupsModel>();
            CreateMap<ItemGroupsModel, ItemGroup>();
            CreateMap<Uom, UomModel>();
            CreateMap<UomModel, Uom>();
            CreateMap<Tax, TaxModel>();
            CreateMap<TaxModel, Tax>();
            CreateMap<ItemUom, ItemUomModel>();
            CreateMap<ItemUomModel, ItemUom>();
            CreateMap<Item, ItemModel>();
            CreateMap<ItemModel, Item>();
            CreateMap<Sku, SkuModel>();
            CreateMap<SkuModel, Sku>();
        }
    }
}