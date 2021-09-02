using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NSR.Data.IRepository
{
    public interface IMenuRepository
    {
        List<Menu> GetMenu();
    }
}