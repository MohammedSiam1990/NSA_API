using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
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
