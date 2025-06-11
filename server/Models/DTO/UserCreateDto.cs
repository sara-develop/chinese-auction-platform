﻿using System;

public class UserCreateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
