namespace WebAPI_project.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int PrizeId { get; set; }
        public Prize Prize { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public bool IsDraft { get; set; } = true;
    }
}
