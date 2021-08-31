using NSR.Entities;
using System.Collections.Generic;
namespace NSR.IService
{
    public interface IItemService
    {
        string GetItems(int BrandID, string ImageURL, string Lang);
        string GetActiveItems(int BrandID, string ImageURL, string Lang);
        List<Item> GetItemAll();
        bool ValidateItem(Item Item);
        void AddItem(Item Item);
        void UpdateItem(Item Item);
        int ValidateItemAlreadyExist(Item model);
        int ValidateSkuAlreadyExist(string Lang, Item model, out string SkuAlert);
        string GetUOMName(int BrandID);
        void DeleteSku(long ItemId);

    }
}
