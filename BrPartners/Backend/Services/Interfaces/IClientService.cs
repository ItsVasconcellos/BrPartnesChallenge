using Backend.Domain.Entities;

namespace Backend.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client?> GetClientById(int clientId);
        Task<IEnumerable<bool>> GetAllClients();
        Task<bool> CreateClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(int id);

    }
}
