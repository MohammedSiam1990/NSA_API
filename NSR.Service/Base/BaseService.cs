using Ninject;
using NSR.Service.Base;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Data.Repository;

namespace NSR.IService.Base
{
    public abstract class BaseService
    {
        #region Private Variable
        private static PosServices _PosService;
        #endregion

        #region Property
        [Inject]
        protected PosServices PosService
        {
            get
            {
                if (_PosService == null)
                {
                    var databaseFactory = new DatabaseFactory();

                    _PosService = new PosServices(new CompaniesRepository(databaseFactory),
                                                   new BrandRepository(databaseFactory),
                                                   new BranchRepository(databaseFactory),
                                                   new ItemRepository(databaseFactory),
                                                   new ItemGroupsRepository(databaseFactory),
                                                   new LookUpRepository(databaseFactory),
                                                   new MobileDataRepository(databaseFactory),
                                                   new DeleteRecordRepository(databaseFactory),
                                                   new TaxRepository(databaseFactory),
                                                   new ItemDataRepository(databaseFactory),
                                                   new ItemUomRepository(databaseFactory),
                                                   new RemarksTemplateRepository(databaseFactory),
                                                   new RemarksTemplateDetailsRepository(databaseFactory),
                                                   new AllDataJsonByBrandIDRepository(databaseFactory),
                                                   new SkuRepository(databaseFactory),
                                                   new BranchWorkStationsRepository(databaseFactory),
                                                   new MenuRepository(databaseFactory),
                                                   new ItemComponentsRepository(databaseFactory),
                                                    new UserRepository(databaseFactory),
                                                    new SalesGroupsItemsRepository(databaseFactory),
                                                    new PaymentMethodsRepositry(databaseFactory),
                                                    new BranchesConnectingRepository(databaseFactory),
                                                    new MajorServiceRepository(databaseFactory),
                                                    new MajorServiceTypesRepository(databaseFactory),
                                                    new MajorServicesIconsRepository(databaseFactory),
                                                    new CustomerRepository(databaseFactory),
                                                    new AddressRepository(databaseFactory),
                                                    new ConfigRepository(databaseFactory),
                                                     new CountryRepository(databaseFactory),
                                                      new CityRepository(databaseFactory),
                                                    new DistrictRepository(databaseFactory),
                                                    new UserDefinedRepository(databaseFactory),
                                                    new PriceTemplateRepository(databaseFactory),
                                                    new PriceTemplateDetailsRepository(databaseFactory),
                                                    new AuthRepository(databaseFactory),
                                                    new SupplierRepository(databaseFactory),
                                                    new RoleRepository(databaseFactory),
                                                    new UserRoleRepository(databaseFactory),
                                                    new PermissionsRepository(databaseFactory),
                                                    new loginAuditRepository(databaseFactory),
                                                      new SoldierRepository(databaseFactory),
                                                      new SchoolRepository(databaseFactory),
                                                      new UniversityRepository(databaseFactory) 

                                                    );
                }

                return _PosService;
            }
        }

        #endregion
    }
}
