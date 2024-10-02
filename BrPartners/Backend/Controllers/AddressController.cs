using Backend.Domain.DTOs.Responses;
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


        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
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
        public async Task<ActionResult<List<AddressDTO>>> GetAddress(int id)
        {
            Address[] addressDB = (await _addressService.GetAddressById(id)).ToArray();

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

        [HttpPut("updateAddress")]
        public async Task<IActionResult> UpdateAddress([FromBody] Address address)
        {
            bool update = await _addressService.UpdateAddress(address);
            return update ? Ok() : NotFound();
        }

        [HttpPost]
        [Route("createAddress")]
        public async Task<ActionResult> CreasteAddress([FromBody] Address address)
        {
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
