using Ninject;
using POS.Data.IRepository;
using POS.Service.IService;

namespace Pos.Service.Base
{

    public class PosServices
    {
        public ICompaniesRepository CompaniesRepository { get; set; }
        //public IUsersRepository UsersRepository { get; set; }
        //public IAccountRepository AccountRepository { get; set; }
        public IBrandRepository BrandRepository { get; set; }
        //public IMajorServiceRepository MajorServiceRepository { get; set; }

        public IBranchRepository BranchRepository { get; set; }
        //public ICityRepository CityRepository { get; set; }
        //public ICountryRepository CountryRepository { get; set; }
        //public IMajorServiceTypesRepository MajorServiceTypesRepository { get; set; }
        public IItemGroupsRepository ItemGroupsRepository { get; set; }
        public IlookUpRepository LookUpRepository { get; set; }
        public IMobileDataRepository MobileDataRepository { get; set; }
        public IDeleteRecordRepository DeleteRecordRepository { get; set; }
        public IUomRepository uomRepository { get; set; }
        public ITaxRepository taxRepository { get; set; }
        public IItemUomRepository itemUomRepository { get; set; }
        //public IAspNetUserRolesRepository AspNetUserRolesRepository { get; set; }
        [Inject]
        public PosServices(ICompaniesRepository _CompaniesRepository,
                                     //IUsersRepository _UsersRepository,
                                     //IAccountRepository _AccountRepository,
                                     IBrandRepository _BrandRepository,
                                     //IMajorServiceRepository _MajorServiceRepository,
                                     //IMajorServiceTypesRepository _IMajorServiceTypesRepository,
                                     IBranchRepository _BranchRepository,
                                     //ICityRepository _CityRepository,
                                     //ICountryRepository _CountryRepository,
                                     IItemGroupsRepository _ItemGroupsRepository,
                                     IlookUpRepository _lookUpRepository,
                                     IMobileDataRepository _MobileDataRepository,
                                     IDeleteRecordRepository _DeleteRecordRepository,
                                     IUomRepository _uomRepository,
                                     ITaxRepository _taxRepository,
                                     IItemUomRepository _itemUomRepository
                            //IAspNetUserRolesRepository _AspNetUserRolesRepository
                            )
        {
            CompaniesRepository = _CompaniesRepository;
            //UsersRepository = _UsersRepository;
            //AccountRepository = _AccountRepository;
            BrandRepository = _BrandRepository;
            //MajorServiceRepository = _MajorServiceRepository;
            //MajorServiceTypesRepository = _IMajorServiceTypesRepository;
            BranchRepository = _BranchRepository;
            //CityRepository = _CityRepository;
            //CountryRepository = _CountryRepository;
            ItemGroupsRepository = _ItemGroupsRepository;
            LookUpRepository = _lookUpRepository;
            MobileDataRepository = _MobileDataRepository;
            DeleteRecordRepository = _DeleteRecordRepository;
            uomRepository = _uomRepository;
            taxRepository = _taxRepository;
            itemUomRepository = _itemUomRepository;
            //AspNetUserRolesRepository = _AspNetUserRolesRepository;
        }

    }
}