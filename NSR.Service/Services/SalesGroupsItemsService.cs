using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System;
using System.Collections.Generic;

namespace NSR.Service.Services
{
    public class SalesGroupsItemsService : BaseService, ISalesGroupsItemsService
    {
        public void SaveSalesGroupsItems(List<SalesGroupsItems> model, int SalesGroupID)
        {
            for (int i = 0; i < model.Count; ++i)
            {
                model[i].CreateDate = DateTime.Now;
            }

            PosService.SalesGroupsItemsRepository.SaveSalesGroupsItems(model, SalesGroupID);
        }
    }
}
