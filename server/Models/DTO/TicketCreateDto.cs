using System;

public class TicketCreateDto
{
    [Required]
    public int PrizeId { get; set; }

    [Required]
    public int UserId { get; set; }

    public bool IsDraft { get; set; } = true;
}
