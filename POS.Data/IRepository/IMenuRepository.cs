using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface IMenuRepository
    {
        List<Menu> GetMenu(int parentId);
    }
}