using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class ItemService : BaseService,IItemService
    {
        public string GetItems(int BrandID, string ImageURL)
        {
            return PosService.ItemDataRepository.GetProcItemData(BrandID, ImageURL);
        }
    }
}
