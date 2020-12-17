using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IUserRoleRepository
    {
        void SaveUserRole(List<UserRole> model,int RoleID);
    }
}
