using Backend.Domain.Entities;

namespace Backend.Infra.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddress();
        Task<Address?> GetAddressById(int addressId);

        Task<List<Address>?> GetAddressByClientId(int clientID);

        Task<bool> AddAddress(Address address);
        Task<bool> UpdateAddress(Address address);
        Task<bool> DeleteAddress(Address address);
        Task SaveChangesAsync();
    }
}
