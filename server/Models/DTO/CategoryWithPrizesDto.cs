using System;
using WebAPI_project.Models;

namespace WebAPI_project.DTOs
{
    public class CategoryWithPrizesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PrizeGetDto> Prizes { get; set; } = new();
    }
}
