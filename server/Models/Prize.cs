namespace WebAPI_project.Models
{
    public class Prize
    {
        public int Id { get; set; }
        
        public int CategoryId { get; set; }
        public int DonorId { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

        public Donor Donor { get; set; }
        public Category Category { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }
}
