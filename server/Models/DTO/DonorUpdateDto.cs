using System;

public class DonorUpdateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<int> PrizesIds { get; set; } = new();
}
