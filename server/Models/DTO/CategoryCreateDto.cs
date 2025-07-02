using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_project.DTOs
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}

