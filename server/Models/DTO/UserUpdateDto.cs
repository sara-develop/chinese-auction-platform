﻿using System;
using WebAPI_project.Models;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_project.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; } // אופציונלי אם את רוצה לאפשר עדכון

        [Required]
        public UserRole Role { get; set; }
    }
}
