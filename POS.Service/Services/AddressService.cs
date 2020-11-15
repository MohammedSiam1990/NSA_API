using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class AddressService : BaseService, IAddressService
    {
        public void AddAddress(Address address)
        {
            PosService.AddressRepository.AddAddress(address);
        }

        public void UpdateAddress(Address address)
        {
            PosService.AddressRepository.UpdateAddress(address);
        }
    }
}
