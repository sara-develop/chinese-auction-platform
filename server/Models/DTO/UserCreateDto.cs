using System;
using WebAPI_project.Models;
using System.ComponentModel.DataAnnotations;


public class UserCreateDto
{
    [Required]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(6)]
    public string Password { get; set; }

    [Required]
    public UserRole Role { get; set; } = UserRole.User;
}
