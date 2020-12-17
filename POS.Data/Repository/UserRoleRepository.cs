using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void SaveUserRole(List<UserRole> model, int RoleID)
        {
            var UserRoles = GetMany(e => e.RoleId == RoleID).ToList();
            DeleteRange(UserRoles);
            AddRange(model);

        }
    }
}
