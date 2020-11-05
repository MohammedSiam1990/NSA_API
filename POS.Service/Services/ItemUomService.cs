using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Service.Services
{
    public class ItemUomService : BaseService, IItemUomService
    {
        public void AddItemUom(ItemUom itemUom)
        {
            PosService.itemUomRepository.AddItemUom(itemUom);
        }

        public void DeleteItemUom(long itemUomId)
        {
            PosService.itemUomRepository.DeleteItemUom(itemUomId);
        }

        public ItemUom GetItemUom(long itemUomId)
        {
            return PosService.itemUomRepository.GetItemUom(itemUomId);
        }

        public List<ItemUom> GetItemUoms(Expression<Func<ItemUom, bool>> where)
        {
            throw new NotImplementedException();
        }

        public List<ItemUom> GetItemUoms()
        {
            return PosService.itemUomRepository.GetItemUoms();

        }

        public void UpdateItemUom(ItemUom itemUom)
        {
            PosService.itemUomRepository.UpdateItemUom(itemUom);
        }

        public bool ValidateCodeorNameAlreadyExist(long ItemUomid, string Name)
        {
            return PosService.itemUomRepository.ValidateCodeorNameAlreadyExist(e => e.ItemUomid != ItemUomid && (e.Name == Name));
        }


        public bool ValidateitemUom(ItemUom itemUom)
        {
            return PosService.itemUomRepository.ValidateitemUom(itemUom);
        }
    }
}
