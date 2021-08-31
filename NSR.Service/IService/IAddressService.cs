using NSR.Data.Entities;

namespace NSR.Service.IService
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        void UpdateAddress(Address address);

    }
}
