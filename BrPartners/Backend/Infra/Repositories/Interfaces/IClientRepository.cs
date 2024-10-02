using Backend.Domain.Entities;

namespace Backend.Infra.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<Client?> GetClientById(int clientId);
        Task<IEnumerable<Client>> GetAllClients();
        Task<bool> AddClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> Delete(Client client);
        Task SaveChangesAsync();
    }
}
