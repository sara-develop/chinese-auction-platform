using System;
namespace WebAPI_project.DTOs
{
    public class DonorGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<int> PrizesId { get; set; }
    }
}
