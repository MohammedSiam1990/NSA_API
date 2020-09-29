﻿using Pos.IService;
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

        public int ValidateNameAlreadyExist(Item model)
        {
            return PosService.ItemRepository.ValidateNameAlreadyExist(model);
        }
    }
}
