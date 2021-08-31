using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface ISupplierRepository
    {
        void SaveSupplier(Supplier model);
        string GetSupplier(int CompanyID);
        int ValidateNameAlreadyExist(Supplier model);

    }
}
