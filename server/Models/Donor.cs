namespace WebAPI_project.Models
{
    public class Donor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List <Prize> Prizes { get; set; }
    }
}
