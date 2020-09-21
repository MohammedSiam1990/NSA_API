using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
   public interface IlookUpRepository
    {
        string GetProcLookUp(string Lang);

    }
}
