using System;
using System.ComponentModel.DataAnnotations;
namespace WebAPI_project.DTOs
{
    public class PrizeCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int DonorId { get; set; }
    }
}
