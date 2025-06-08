namespace WebAPI_project.Models
{
    public enum UserRole
    {
        User=1,Manager=2
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public List<Ticket> Purchases { get; set; }
    }
}
