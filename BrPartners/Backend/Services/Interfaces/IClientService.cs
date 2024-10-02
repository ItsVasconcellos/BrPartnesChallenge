using Backend.Domain.Entities;

namespace Backend.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client?> GetClientById(int clientId);
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> CreateClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(Client client);

    }
}
