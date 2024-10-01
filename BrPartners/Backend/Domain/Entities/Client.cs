namespace Backend.Domain.Entities
{
    public class Client
    {
        public int id { get; set; }
        public required string? name { get; set; }
        public required string? email { get; set; }
        public string? sex { get; set; }
        public string? phone { get; set; }
        public int? age { get; set; }
        public DateTime? created_at { get; set; }
    }
}