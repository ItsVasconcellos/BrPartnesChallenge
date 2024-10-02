namespace Backend.Domain.DTOs.ViewModels
{
    public class ClientRequest
    { 
       public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Sex { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
