using AutoMapper;
using Backend.Domain.DTOs.Responses;
using Backend.Domain.DTOs.ViewModels;
using Backend.Domain.Entities;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;


        public AddressController(IAddressService addressService, IClientService clientService, IMapper mapper)
        {
            _addressService = addressService;
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet("getAllAddress")]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddress()
        {
            Address[] addressDB = (await _addressService.GetAllAddress()).ToArray();

            if (addressDB == null || !addressDB.Any())
            {
                return NotFound();
            }


            List<AddressDTO> addressResponse = new List<AddressDTO>();

            foreach (Address address in addressDB)
            {
                var addressDTO = new AddressDTO
                {
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                };

                addressResponse.Add(addressDTO);
            }
            return Ok(addressResponse);

        }

        [HttpGet("getAddress/{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(int id)
        {
            Address addressDB = await _addressService.GetAddressById(id);

            if (addressDB == null )
            {
                return NotFound();
            }
            return Ok(addressDB);
        }

        [HttpGet("getAddressByCliend/{id}")]
        public async Task<ActionResult<List<AddressDTO>>> GetAddressByClientID(int id)
        {
            List<Address> addressDB = await _addressService.GetAddressByClientId(id);

            List<AddressDTO> addressResponse = new List<AddressDTO>();

            foreach (Address address in addressDB)
            {
                var addressDTO = new AddressDTO
                {
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                };

                addressResponse.Add(addressDTO);
            }
            return (Ok(addressResponse));
        }

        [HttpPut("updateAddress")]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressRequest addressRequest, int addressId)
        {
            Address address = _mapper.Map<Address>(addressRequest);
            address.Id = addressId;
            Client client = await _clientService.GetClientById(addressRequest.ClientId);
            bool update = await _addressService.UpdateAddress(address);
            return update ? Ok() : NotFound();
        }

        [HttpPost]
        [Route("createAddress")]
        public async Task<ActionResult> CreasteAddress([FromBody] AddressRequest addressRequest)
        {
            Address address = _mapper.Map<Address>(addressRequest);
            Client client = await _clientService.GetClientById(addressRequest.ClientId);
            address.Client = client;
            bool update = await _addressService.AddAddress(address);
            return update ? Ok() : BadRequest("Failed to add address."); ;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddres(int id)
        {
            bool update = await _addressService.DeleteAddress(id);
            return update ? Ok() : NotFound();
        }

    }

}
