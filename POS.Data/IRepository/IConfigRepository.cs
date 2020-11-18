using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IConfigRepository
    {
        void SaveConfig(List<Config>Added, List<Config>Updated);
    }
}
