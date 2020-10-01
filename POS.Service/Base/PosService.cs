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
        public IUomRepository uomRepository { get; set; }
        public ITaxRepository taxRepository { get; set; }
        public IItemDataRepository ItemDataRepository { get; set; }
        public IItemUomRepository itemUomRepository { get; set; }
        public IRemarksTemplateRepository RemarksTemplateRepository { get; set; }
        public IAllDataJsonByBrandIDRepository AllDataJsonByBrandIDRepository { get; set; }
        public ISkuRepository SkuRepository { get; set; }
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
                                     IUomRepository _uomRepository,
                                     ITaxRepository _taxRepository,
                                     IItemDataRepository _ItemDataRepository,
                                     IItemUomRepository _itemUomRepository,
                                     IRemarksTemplateRepository _RemarksTemplateRepository,
                                     IAllDataJsonByBrandIDRepository _AllDataJsonByBrandIDRepository,
                                     ISkuRepository _SkuRepository
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
            uomRepository = _uomRepository;
            taxRepository = _taxRepository;
            ItemDataRepository = _ItemDataRepository;
            itemUomRepository = _itemUomRepository;
            RemarksTemplateRepository = _RemarksTemplateRepository;
            AllDataJsonByBrandIDRepository = _AllDataJsonByBrandIDRepository;
            SkuRepository = _SkuRepository;
        }

    }
}