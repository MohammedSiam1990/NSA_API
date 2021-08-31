using Microsoft.EntityFrameworkCore;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public List<Menu> GetMenu()
        {
            var QMenu = base.Table().Include(e => e.InverseMenuParent)
                .ThenInclude(e => e.InverseMenuParent).Where(e => e.MenuParentId == null && e.MenuType == 2 && e.StatusId != 3).OrderBy(e => e.MenuOrder).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return QMenu;
        }

    }
}
