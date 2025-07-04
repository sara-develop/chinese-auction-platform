﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_project.DTOs
{
    public class DonorCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
