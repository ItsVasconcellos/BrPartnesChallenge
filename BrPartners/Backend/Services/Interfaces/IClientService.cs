using Backend.Domain.Entities;

namespace Backend.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client?> GetClientById(int clientId);
        Task<IEnumerable<Client>> GetAllClients();
    }
}
