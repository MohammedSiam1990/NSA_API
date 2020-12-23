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
    public class RoleBrandsService : BaseService, IRoleBrandsService
    {
        public void SaveRoleBrand(List<RolesBrands> model,int RollID)
        {
            PosService.RoleBrandsRepository.SaveRoleBrand(model, RollID);
        }
    }
}
