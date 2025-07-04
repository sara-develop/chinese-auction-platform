﻿using System;
using WebAPI_project.Models;

namespace WebAPI_project.DTOs
{
    public class UserGetDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; }
        public List<int> Purchases { get; set; } = new();
    }
}
