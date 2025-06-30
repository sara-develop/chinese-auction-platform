using System;
using WebAPI_project.Models;
using System.ComponentModel.DataAnnotations;


public class TicketCreateDto
{
    [Required]
    public int PrizeId { get; set; }

    [Required]
    public int UserId { get; set; }

    public bool IsDraft { get; set; } = true;
}
