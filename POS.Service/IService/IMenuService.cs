
using POS.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IMenuService
    {
        List<Menu> GetMenu(int ParentId);
    }
}
