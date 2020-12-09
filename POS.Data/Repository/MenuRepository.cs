using Microsoft.EntityFrameworkCore;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
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
