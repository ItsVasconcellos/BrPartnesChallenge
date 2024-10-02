namespace Backend.Domain.DTOs.Responses
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Sex { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Lista de endereços associados ao cliente
        public List<AddressDTO> Addresses { get; set; } = new();
    }

}
