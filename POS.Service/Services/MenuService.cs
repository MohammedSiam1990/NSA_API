
using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System.Collections.Generic;

namespace POS.Service.Services
{
    public class MenuService : BaseService, IMenuService
    {
        public List<Menu> GetMenu()
        {

            return PosService.MenuRepository.GetMenu();
        }
    }

}
