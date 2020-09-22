﻿using Ninject;
using POS.Data.IRepository;
using POS.Service.IService;

namespace Pos.Service.Base
{

    public  class PosServices
    {
        public ICompaniesRepository CompaniesRepository { get; set; }
        //public IUsersRepository UsersRepository { get; set; }
        //public IAccountRepository AccountRepository { get; set; }
        public IBrandRepository BrandRepository { get; set; }
        public IMajorServiceRepository MajorServiceRepository { get; set; }
      
        public IBranchRepository BranchRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        public ICountryRepository CountryRepository { get; set; }
        public IMajorServiceTypesRepository MajorServiceTypesRepository { get; set; }
        public IItemGroupsRepository ItemGroupsRepository { get; set; }
        public IlookUpRepository LookUpRepository { get; set; }
        public IAllDataRepository AllDataRepository { get; set; }
        //public IAspNetUserRolesRepository AspNetUserRolesRepository { get; set; }
        [Inject]
        public PosServices(          ICompaniesRepository _CompaniesRepository,
                                     //IUsersRepository _UsersRepository,
                                     //IAccountRepository _AccountRepository,
                                     IBrandRepository _BrandRepository,
                                     IMajorServiceRepository _MajorServiceRepository,
                                     IMajorServiceTypesRepository _IMajorServiceTypesRepository,
                                     IBranchRepository _BranchRepository,
                                     ICityRepository _CityRepository,
                                     ICountryRepository _CountryRepository,
                                     IItemGroupsRepository _ItemGroupsRepository,
                                     IlookUpRepository _lookUpRepository,
                                     IAllDataRepository _AllDataRepository
                            //IAspNetUserRolesRepository _AspNetUserRolesRepository
                            )
        {
            CompaniesRepository = _CompaniesRepository;
            //UsersRepository = _UsersRepository;
            //AccountRepository = _AccountRepository;
            BrandRepository = _BrandRepository;
            MajorServiceRepository = _MajorServiceRepository;
            MajorServiceTypesRepository = _IMajorServiceTypesRepository;
            BranchRepository = _BranchRepository;
            CityRepository = _CityRepository;
            CountryRepository = _CountryRepository;
            ItemGroupsRepository = _ItemGroupsRepository;
            LookUpRepository = _lookUpRepository;
            AllDataRepository = _AllDataRepository;
            //AspNetUserRolesRepository = _AspNetUserRolesRepository;
        }

    }
}