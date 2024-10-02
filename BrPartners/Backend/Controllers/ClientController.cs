using Backend.Domain.Entities;
using Backend.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Services;
using Backend.Domain.DTOs.Responses;


using Backend.Infra.Repositories;
using Backend.Services.Interfaces;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IAddressService _addressService;


        public ClientController(IClientService clientService, IAddressService addressService)
        {
            _clientService = clientService;
            _addressService = addressService;
        }

        [HttpGet("getAllClients")]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        {
            Client[] clients = (await _clientService.GetAllClients()).ToArray();

            if (clients == null || !clients.Any())
            {
                return NotFound();
            }

            List<ClientDTO> clientsResponse = new List<ClientDTO>();

            foreach (Client client in clients) {
                List<Address>? addresses = await _addressService.GetAddressByClientId(client.id);
                var clientDTO = new ClientDTO
                {
                    Id = client.id,
                    Name = client.name,
                    Email = client.email,
                    Sex = client?.sex,
                    Phone = client?.phone,
                    Age = client?.age,
                    CreatedAt = client.created_at,
                    Addresses = addresses?.Select(a => new AddressDTO
                    {
                        Street = a.Street,
                        City = a.City,
                        State = a.State,
                        ZipCode = a.ZipCode,
                        Type = a.Type
                    }).ToList()
                };

                clientsResponse.Add(clientDTO);
            }

            return Ok(clientsResponse);
            
        }

        [HttpGet("getClient/{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            Client client = await _clientService.GetClientById(id);

            if (client == null )
            {
                return NotFound();
            }

            List<Address>? addresses = await _addressService.GetAddressByClientId(client.id);
            var clientDTO = new ClientDTO
            {
                Id = client.id,
                Name = client.name,
                Email = client.email,
                Sex = client?.sex,
                Phone = client?.phone,
                Age = client?.age,
                CreatedAt = client.created_at,
                Addresses = addresses?.Select(a => new AddressDTO
                {
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    ZipCode = a.ZipCode,
                    Type = a.Type
                }).ToList()
            };

            return Ok(clientDTO);
        }

        [HttpPut("updateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            bool update = await _clientService.UpdateClient(client);
            return update ? Ok() : NotFound();
        }

        [HttpPost]
        [Route("createClient")]
        public async Task<ActionResult> CreateClient([FromBody] Client client)
        {
            bool update = await _clientService.CreateClient(client);
            return update ? Ok() : BadRequest("Failed to create client."); ;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            bool update = await _clientService.DeleteClient(id);
            return update ? Ok() : NotFound();
        }

    }

}
