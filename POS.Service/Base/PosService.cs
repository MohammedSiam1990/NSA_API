using Ninject;
using POS.Data.IRepository;

namespace Pos.Service.Base
{

    public class PosServices
    {
        public ICompaniesRepository CompaniesRepository { get; set; }
        public IBrandRepository BrandRepository { get; set; }
        public IBranchRepository BranchRepository { get; set; }
        public IItemRepository ItemRepository { get; set; }
        public IItemGroupsRepository ItemGroupsRepository { get; set; }
        public IlookUpRepository LookUpRepository { get; set; }
        public IMobileDataRepository MobileDataRepository { get; set; }
        public IDeleteRecordRepository DeleteRecordRepository { get; set; }
        public ITaxRepository taxRepository { get; set; }
        public IItemDataRepository ItemDataRepository { get; set; }
        public IItemUomRepository itemUomRepository { get; set; }
        public IRemarksTemplateRepository RemarksTemplateRepository { get; set; }
        public IRemarksTemplateDetailsRepository RemarksTemplateDetailsRepository { get; set; }
        public IAllDataJsonByBrandIDRepository AllDataJsonByBrandIDRepository { get; set; }
        public ISkuRepository SkuRepository { get; set; }
        public IBranchWorkStationsRepository branchWorkStationsRepository { get; set; }
        public IMenuRepository MenuRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IItemComponentsRepository ItemComponentsRepository { get; set; }
        public ISalesGroupsItemsRepository SalesGroupsItemsRepository { get; set; }
        public IPaymentMethodsRepositry PaymentMethodsRepositry { get; set; }
        public IBranchesConnectingRepository BranchesConnectingRepository { get; set; }
        public IMajorServiceRepository MajorServiceRepository { get; set; }
        public IMajorServiceTypesRepository MajorServiceTypesRepository { get; set; }
        public IMajorServicesIconsRepository MajorServicesIconsRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public IConfigRepository ConfigRepository { get; set; }
        public ICountryRepository CountryRepository { get; set; }
         public IDistrictRepository DistrictRepository { get; set; }
        [Inject]
        public PosServices(
                                     ICompaniesRepository _CompaniesRepository,
                                     IBrandRepository _BrandRepository,
                                     IBranchRepository _BranchRepository,
                                     IItemRepository _ItemRepository,
                                     IItemGroupsRepository _ItemGroupsRepository,
                                     IlookUpRepository _lookUpRepository,
                                     IMobileDataRepository _MobileDataRepository,
                                     IDeleteRecordRepository _DeleteRecordRepository,
                                     ITaxRepository _taxRepository,
                                     IItemDataRepository _ItemDataRepository,
                                     IItemUomRepository _itemUomRepository,
                                     IRemarksTemplateRepository _RemarksTemplateRepository,
                                     IRemarksTemplateDetailsRepository _RemarksTemplateDetailsRepository,
                                     IAllDataJsonByBrandIDRepository _AllDataJsonByBrandIDRepository,
                                     ISkuRepository _SkuRepository,
                                     IBranchWorkStationsRepository _branchWorkStationsRepository,
                                     IMenuRepository _MenuRepository,
                                     IItemComponentsRepository _ItemComponentsRepository,
                                     IUserRepository _UserRepository,
                                     ISalesGroupsItemsRepository _SalesGroupsItemsRepository,
                                     IPaymentMethodsRepositry _PaymentMethodsRepositry,
                                     IBranchesConnectingRepository _BranchesConnectingRepository,
                                      IMajorServiceRepository _MajorServiceRepository,
                                      IMajorServiceTypesRepository _MajorServiceTypesRepository,
                                     IMajorServicesIconsRepository _MajorServicesIconsRepository,
                                     ICustomerRepository _CustomerRepository,
                                     IAddressRepository _AddressRepository,
                                     IConfigRepository _ConfigRepository,
                                     ICountryRepository _CountryRepository,
                                     IDistrictRepository _districtRepository
                            )
        {
            CompaniesRepository = _CompaniesRepository;
            BrandRepository = _BrandRepository;
            BranchRepository = _BranchRepository;
            ItemRepository = _ItemRepository;
            ItemGroupsRepository = _ItemGroupsRepository;
            LookUpRepository = _lookUpRepository;
            MobileDataRepository = _MobileDataRepository;
            DeleteRecordRepository = _DeleteRecordRepository;
            taxRepository = _taxRepository;
            ItemDataRepository = _ItemDataRepository;
            itemUomRepository = _itemUomRepository;
            RemarksTemplateRepository = _RemarksTemplateRepository;
            RemarksTemplateDetailsRepository = _RemarksTemplateDetailsRepository;
            AllDataJsonByBrandIDRepository = _AllDataJsonByBrandIDRepository;
            SkuRepository = _SkuRepository;
            branchWorkStationsRepository = _branchWorkStationsRepository;
            MenuRepository = _MenuRepository;
            ItemComponentsRepository = _ItemComponentsRepository;
            UserRepository = _UserRepository;
            SalesGroupsItemsRepository = _SalesGroupsItemsRepository;
            PaymentMethodsRepositry = _PaymentMethodsRepositry;
            BranchesConnectingRepository = _BranchesConnectingRepository;
            MajorServiceRepository = _MajorServiceRepository;
            MajorServiceTypesRepository = _MajorServiceTypesRepository;
            MajorServicesIconsRepository = _MajorServicesIconsRepository;
            AddressRepository = _AddressRepository;
            CustomerRepository = _CustomerRepository;
            ConfigRepository = _ConfigRepository;
            DistrictRepository = _districtRepository;
        }

    }
}
