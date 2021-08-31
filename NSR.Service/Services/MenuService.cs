using NSR.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System.Collections.Generic;

namespace NSR.Service.Services
{
    public class MenuService : BaseService, IMenuService
    {
        public List<Menu> GetMenu()
        {
            return PosService.MenuRepository.GetMenu();
        }
    }

}
