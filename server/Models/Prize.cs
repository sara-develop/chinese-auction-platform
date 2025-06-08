namespace WebAPI_project.Models
{
    public class Prize
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Donor Donor { get; set; }
        public int Price { get; set; }
        public List<Ticket> Purchasers { get; set; }
        public User Winner { get; set; }
    }
}
