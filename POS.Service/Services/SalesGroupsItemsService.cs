﻿using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class SalesGroupsItemsService : BaseService, ISalesGroupsItemsService
    {
        public void SaveSalesGroupsItems(List<SalesGroupsItems> model)
        {
            for (int i = 0; i < model.Count; ++i)
            {
                model[i].CreateDate = DateTime.Now;
            }

            PosService.SalesGroupsItemsRepository.SaveSalesGroupsItems(model);
        }
    }
}
