using System;

public class PrizeGetDto
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public int DonorId { get; set; }

    public string Name { get; set; }
    public int Price { get; set; }

    public List<Ticket> Tickets { get; set; } = new();
}
