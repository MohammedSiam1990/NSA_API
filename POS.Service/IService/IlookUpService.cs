using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;

namespace POS.Service.IService
{
    public interface IlookUpService
    {
        string GetLookUps(string Lang);
    }
}
