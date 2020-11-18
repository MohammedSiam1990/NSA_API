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
    public class ConfigService : BaseService, IconfigService
    {
        public void SaveConfig(List<Config> model)
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
            PosService.ConfigRepository.SaveConfig(Added, Updated);
        }
    }
}
