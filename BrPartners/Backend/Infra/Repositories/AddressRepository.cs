using Backend.Domain.Entities;
using Backend.Infra.Data;
using Backend.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        public AddressRepository(DataContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await _context.Addresses.ToListAsync();
        }
        public async Task<Address?> GetAddressById(int addressId)
        {
            return await _context.Addresses.FindAsync(addressId);
        }
        public async Task<List<Address>> GetAddressByClientId(int clientID)
        {
            return await _context.Addresses
                                 .Where(a => a.Client.id == clientID)
                                 .ToListAsync();
        }

        public async Task<bool> AddAddress(Address address)
        {
            try
            {
                await _context.Addresses.AddAsync(address);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            try
            {
                _context.Addresses.Update(address);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAddress(Address address)
        {
            try
            {
                _context.Addresses.Remove(address);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
