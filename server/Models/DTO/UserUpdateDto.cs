using System;

public class UserUpdateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // אופציונלי אם את רוצה לאפשר עדכון
    public UserRole Role { get; set; }
}
