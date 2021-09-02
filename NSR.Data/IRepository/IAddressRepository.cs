using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        void UpdateAddress(Address address);

    }
}
