using System;

public class PrizeUpdateDto
{
    public int Id { get; set; } 

    public string Name { get; set; }

    public int Price { get; set; }

    public int CategoryId { get; set; }
    public int DonorId { get; set; }
}
