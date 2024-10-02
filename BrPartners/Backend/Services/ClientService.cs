using Backend.Infra.Repositories.Interfaces;
using Backend.Domain.Entities;
using Backend.Services.Interfaces;
namespace Backend.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client?> GetClientById(int clientId)
        {
            return await _clientRepository.GetClientById(clientId);
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _clientRepository.GetAllClients();
        }

        public async Task<bool> CreateClient(Client client)
        {
            return await _clientRepository.AddClient(client);
        }

        public async Task<bool> UpdateClient(Client client)
        {
            return await _clientRepository.UpdateClient(client);
        }

        public async Task<bool> DeleteClient(Client client)
        {
            return await _clientRepository.Delete(client);
        }
    }
}
