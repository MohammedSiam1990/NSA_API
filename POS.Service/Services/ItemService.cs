using Pos.IService;
using POS.Entities;
using POS.IService.Base;
using System.Collections.Generic;

namespace Pos.Service
{
    public class ItemService : BaseService, IItemService
    {

        public void AddItem(Item Item)
        {
            PosService.ItemRepository.AddItem(Item);
        }

   

        public Item GetItem(long ItemId)
        {
            return PosService.ItemRepository.GetItem(e => e.ItemId == ItemId);
        }

        public List<Item> GetItemAll()
        {
            return PosService.ItemRepository.GetItemAll(e => true);
        }

        public void UpdateItem(Item Item)
        {
            PosService.ItemRepository.UpdateItem(Item);
        }

        public bool ValidateItem(Item Item)
        {
            return PosService.ItemRepository.ValidateItem(Item);
        }

        public int ValidateNameAlreadyExist(Item model)
        {
            return PosService.ItemRepository.ValidateNameAlreadyExist(e => e.ItemId != model.ItemId && (e.ItemName == model.ItemName || e.ItemNameAr == model.ItemName || e.MobileName== model.MobileName|| e.MobileNameAr == model.MobileNameAr),model);
        }
    }
}
