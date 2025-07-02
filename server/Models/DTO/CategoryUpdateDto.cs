using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_project.DTOs
{
    public class CategoryUpdateDto
    {
        [Required]
        public string Name { get; set; }

        public List<int> PrizesId { get; set; }
    }
}
