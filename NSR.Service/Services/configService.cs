using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Service.Services
{
    public class ConfigService : BaseService, IconfigService
    {
        public string GetConfig(int TypeID, int? BranchID, int? BrandID)
        {
            return PosService.ConfigRepository.GetConfig(BranchID, BrandID, TypeID);
        }

        public int SaveConfig(List<Config> model)
        {
            List<Config> Added = model.Where(e => e.ConfigID == 0).ToList();
            List<Config> Updated = model.Where(e => e.ConfigID > 0).ToList();
            foreach (Config i in Added)
            {
                i.CreateDate = DateTime.Now;
            }
            foreach (Config i in Updated)
            {
                i.LastModifyDate = DateTime.Now;
            }
            return PosService.ConfigRepository.SaveConfig(Added, Updated);
        }




    }
}
