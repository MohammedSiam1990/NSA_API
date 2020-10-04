using Pos.IService;
using POS.Core;
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



        public string GetItems(int BrandID, string ImageURL)
        {
            return PosService.ItemDataRepository.GetProcItemData(BrandID, ImageURL);
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

        public int ValidateItemAlreadyExist(Item model)
        {
            return PosService.ItemRepository.ValidateNameAlreadyExist(model);
        }

        public int ValidateSkuAlreadyExist(string Lang, Item model, out string SkuAlert)
        {
            int Id = 1; 
            SkuAlert = "";
            foreach (var ItemUom in model.ItemUoms)
            {
                foreach (var Sku in ItemUom.Skus)
                {
                     var SkuExists = PosService.SkuRepository.ValidateNameAlreadyExist(model.BrandId, Sku);
                    if (SkuExists != null)
                    {
                        SkuAlert = "SkuCode:"+ SkuExists.Code +", ItemNum:"+ SkuExists.ItemUom.Item.ItemNum +
                      Lang =="en" ? " , ItemName:" + SkuExists.ItemUom.Item.ItemName  : " , ItemNameAr:" + SkuExists.ItemUom.Item.ItemNameAr;
                        return -7;
                    }
                }
            }
            return Id;
        }

        public string GetUOMName(int BrandID)
        {
            return PosService.ItemRepository.GetUOMName(BrandID);

        }
    }
}
