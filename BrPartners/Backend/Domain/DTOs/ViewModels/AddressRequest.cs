using Backend.Domain.Enum;

namespace Backend.Domain.DTOs.ViewModels
{
    public class AddressRequest
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public AddressType Type { get; set; }
    }
}
