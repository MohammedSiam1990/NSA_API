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
            CreateMap<RemarksTemplateDetails, RemarksTemplateDetailsModel>();
            CreateMap<RemarksTemplateDetailsModel, RemarksTemplateDetails>();
            CreateMap<RemarksTemplate, RemarksTemplateModel>();
            CreateMap<RemarksTemplateModel, RemarksTemplate>();
            CreateMap<BranchWorkStations, BranchWorkStationsModel>();
            CreateMap<BranchWorkStationsModel, BranchWorkStations>();
            CreateMap<Menu, MenuModel>();
            CreateMap<MenuModel, Menu>();
            CreateMap<ItemComponentsModel, ItemComponents>();
            CreateMap<ItemComponents, ItemComponentsModel>();
            CreateMap<SalesGroupsItemsModel, SalesGroupsItems>();
            CreateMap<SalesGroupsItems, SalesGroupsItemsModel>();
            CreateMap<MajorServicesIconsModel, MajorServicesIcons>();
            CreateMap<MajorServicesIcons, MajorServicesIconsModel>();
            CreateMap<MajorServicesModel, MajorServices>();
            CreateMap<MajorServices, MajorServicesModel>();
            CreateMap<MajorServiceTypesModel, MajorServiceTypes>();
            CreateMap<MajorServiceTypes, MajorServiceTypesModel>()
            .ForMember(x => x.ServiceName, opt => opt.MapFrom(model => model.MajorService.ServiceName))
            .ForMember(x => x.ServiceNameAr, opt => opt.MapFrom(model => model.MajorService.ServiceNameAr));
            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<AddressModel, Address>();
            CreateMap<Address, AddressModel>();
            CreateMap<CountryModel, Country>();
            CreateMap<Country, CountryModel>();
            CreateMap<CityModel, City>();
            CreateMap<City, CityModel>()
            .ForMember(x => x.CountryName, opt => opt.MapFrom(model => model.Country.CountryName))
            .ForMember(x => x.CountryNameAr, opt => opt.MapFrom(model => model.Country.CountryNameAr));
            CreateMap<DistrictModel, District>();
            CreateMap<District, DistrictModel>()
            .ForMember(x => x.CityName, opt => opt.MapFrom(model => model.City.CityName))
            .ForMember(x => x.CityNameAr, opt => opt.MapFrom(model => model.City.CityNameAr))
             .ForMember(x => x.CountryId, opt => opt.MapFrom(model => model.City.Country.CountryId))
             .ForMember(x => x.CountryName, opt => opt.MapFrom(model => model.City.Country.CountryName))
             .ForMember(x => x.CountryNameAr, opt => opt.MapFrom(model => model.City.Country.CountryNameAr));
            CreateMap<UserDefinedObjects, UserDefinedObjectsModel>();
            CreateMap<UserDefinedObjectsModel, UserDefinedObjects>();
            CreateMap<AddressModel, Address>();
            CreateMap<Address, AddressModel>();

            CreateMap<PriceTemplate, PriceTemplateModel>();
            CreateMap<PriceTemplateModel, PriceTemplate>();
            CreateMap<PriceTemplateDetails, PriceTemplateDetailsModel>();
            CreateMap<PriceTemplateDetailsModel, PriceTemplateDetails>();

            CreateMap<Supplier, SupplierModel>();
            CreateMap<SupplierModel, Supplier>();

            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            CreateMap<UserRole, UserRoleModel>();
            CreateMap<UserRoleModel, UserRole>();

            CreateMap<Permissions, PermissionsModel>();
            CreateMap<PermissionsModel, Permissions>();



        }
    }
}
