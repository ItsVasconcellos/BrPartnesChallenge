using Backend.Domain.Entities;
using Backend.Infra.Data;
using Backend.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Infra.Repositories { 

    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetClientById(int clientId)
        {
            return await _context.Clients.FindAsync(clientId);
        }

        public async Task<bool> AddClient(Client client)
        {
            try
            {
                await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateClient(Client client)
        {
            try
            {
                 _context.Clients.Update(client);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  async Task<bool>  Delete(Client client)
        {
            try
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
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

