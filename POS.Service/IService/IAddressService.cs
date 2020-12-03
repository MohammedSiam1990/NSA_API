using POS.Data.Entities;

namespace POS.Service.IService
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        void UpdateAddress(Address address);

    }
}
