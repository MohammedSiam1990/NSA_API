﻿using Ninject;
using Pos.Service.Base;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Data.Repository;

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
                                                   new SkuRepository(databaseFactory)
                                                );
                }

                return _PosService;
            }
        }

        #endregion
    }
}
