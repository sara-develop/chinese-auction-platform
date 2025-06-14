namespace WebAPI_project.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Prize> Prizes { get; set; } = new();
    }
}
