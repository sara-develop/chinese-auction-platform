namespace WebAPI_project.Models
{
    public class Ticket
    {
        public string Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Prize Prize { get; set; }
        public string PrizeId { get; set; } 
        public DateTime DateTime { get; set; }
    }
}
