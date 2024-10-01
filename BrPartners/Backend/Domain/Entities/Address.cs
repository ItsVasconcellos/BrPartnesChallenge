using Backend.Domain.Enum;

namespace Backend.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public AddressType Type { get; set; }  
        public int CustomerId { get; set; }
        public required Client Client  { get; set; }
    }


}
