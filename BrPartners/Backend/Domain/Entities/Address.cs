using Backend.Domain.Enum;

namespace Backend.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required AddressType Type { get; set; }  
        public required Client Client  { get; set; }
    }

}
