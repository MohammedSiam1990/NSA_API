using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSR.Data.Repository
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
