using POS.Data;
using POS.Data.Infrastructure;
using Ninject;
using POS.Data.Repository;
using Pos.Service.Base;
using POS.Service.Services;

namespace POS.IService.Base
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

                    _PosService = new PosServices( new CompaniesRepository(databaseFactory),
                                                   //new UsersRepository(databaseFactory),
                                                   //new AccountRepository(databaseFactory),
                                                   new BrandRepository(databaseFactory),
                                                   new MajorServiceRepository(databaseFactory),
                                                   new MajorServiceTypesRepository(databaseFactory),
                                                   new BranchRepository(databaseFactory),
                                                   new CityRepository(databaseFactory),
                                                   new CountryRepository(databaseFactory),
                                                   new ItemGroupsRepository(databaseFactory),
                                                   new LookUpRepository(databaseFactory),
                                                   new MobileDataRepository(databaseFactory)
                                                //new AspNetUserRolesRepository(databaseFactory)
                                                );
                }
                return _PosService;
            }
        }

        #endregion
    }
}
