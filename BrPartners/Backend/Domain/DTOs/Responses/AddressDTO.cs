using Backend.Domain.Enum;

namespace Backend.Domain.DTOs.Responses
{
    public class AddressDTO
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public AddressType Type { get; set; }  
    }

}
