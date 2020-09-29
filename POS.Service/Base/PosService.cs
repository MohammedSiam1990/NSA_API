using Ninject;
using POS.Data.IRepository;

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
        public IItemRepository ItemRepository { get; set; }
        //public ICountryRepository CountryRepository { get; set; }
        //public IMajorServiceTypesRepository MajorServiceTypesRepository { get; set; }
        public IItemGroupsRepository ItemGroupsRepository { get; set; }
        public IlookUpRepository LookUpRepository { get; set; }
        public IMobileDataRepository MobileDataRepository { get; set; }
        public IDeleteRecordRepository DeleteRecordRepository { get; set; }
        public IUomRepository uomRepository { get; set; }
        public ITaxRepository taxRepository { get; set; }
        //public IAspNetUserRolesRepository AspNetUserRolesRepository { get; set; }
        [Inject]
        public PosServices(ICompaniesRepository _CompaniesRepository,
                                     //IUsersRepository _UsersRepository,
                                     //IAccountRepository _AccountRepository,
                                     IBrandRepository _BrandRepository,
                                     //IMajorServiceRepository _MajorServiceRepository,
                                     //IMajorServiceTypesRepository _IMajorServiceTypesRepository,
                                     IBranchRepository _BranchRepository,
                                     IItemRepository _ItemRepository,
                                     //ICountryRepository _CountryRepository,
                                     IItemGroupsRepository _ItemGroupsRepository,
                                     IlookUpRepository _lookUpRepository,
                                     IMobileDataRepository _MobileDataRepository,
                                     IDeleteRecordRepository _DeleteRecordRepository,
                                     IUomRepository _uomRepository,
                                     ITaxRepository _taxRepository
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
            ItemRepository = _ItemRepository;
            //CountryRepository = _CountryRepository;
            ItemGroupsRepository = _ItemGroupsRepository;
            LookUpRepository = _lookUpRepository;
            MobileDataRepository = _MobileDataRepository;
            DeleteRecordRepository = _DeleteRecordRepository;
            uomRepository = _uomRepository;
            taxRepository = _taxRepository;
            //AspNetUserRolesRepository = _AspNetUserRolesRepository;
        }

    }
}