﻿using System;
using System.ComponentModel.DataAnnotations;
namespace WebAPI_project.DTOs
{
    public class DonorUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public List<int> PrizesId { get; set; } = new();
    }
}
