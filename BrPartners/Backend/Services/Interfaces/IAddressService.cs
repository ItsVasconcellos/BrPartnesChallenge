using Backend.Domain.Entities;
namespace Backend.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddress();
        Task<Address?> GetAddressById(int addressId);
        Task<List<Address>?> GetAddressByClientID(int clientID);
        Task<bool> AddAddress(Address address);
        Task<bool> UpdateAddress(Address address);
        Task<bool> DeleteAddress(Address address);
    }
}
