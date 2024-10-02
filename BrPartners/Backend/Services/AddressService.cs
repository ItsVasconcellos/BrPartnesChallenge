using Backend.Domain.Entities;
using Backend.Infra.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await _addressRepository.GetAllAddress();
        }
        public async Task<Address?> GetAddressById(int addressId)
        {
            return await _addressRepository.GetAddressById(addressId);
        }
        public async Task<List<Address>?> GetAddressByClientId(int addressId)
        {
            return await _addressRepository.GetAddressByClientId(addressId);
        }


        public async Task<bool> AddAddress(Address address)
        {
            return await _addressRepository.AddAddress(address);
        }
        public async Task<bool> UpdateAddress(Address address)
        {
            return await _addressRepository.UpdateAddress(address);
        }
        public async Task<bool> DeleteAddress(Address address)
        {
            return await _addressRepository.DeleteAddress(address);
        }
    }
}
