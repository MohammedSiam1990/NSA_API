using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class ItemComponentsService : BaseService, IItemComponentsService
    {
        public void AddItemComponents(ItemComponents itemComponents)
        {
            PosService.ItemComponentsRepository.AddItemComponents(itemComponents);
        }

        public void DeleteItemComponents(long ItemComponentID)
        {
            PosService.ItemComponentsRepository.DeleteItemComponents(ItemComponentID);
        }
    }
}
