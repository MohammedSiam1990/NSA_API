using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IRoleBrandsRepository
    {
        void SaveRoleBrand(List<RolesBrands> model);
    }
}
