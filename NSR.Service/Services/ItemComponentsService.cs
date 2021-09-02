using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System;
using System.Collections.Generic;

namespace NSR.Service.Services
{
    public class ItemComponentsService : BaseService, IItemComponentsService
    {

        public void SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID)
        {

            for (int i = 0; i < model.Count; ++i)
            {
                model[i].CreateDate = DateTime.Now;
            }
            PosService.ItemComponentsRepository.SaveItemComponents(model, MainItemID, MainItemUOMID);
        }
    }
}
