using System;

public class PrizeGetPurchasersDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public List<TicketGetDto> Purchases { get; set; }
}
