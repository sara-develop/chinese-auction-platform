using System;

public class DonorGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<int> PrizesIds { get; set; } 
}
