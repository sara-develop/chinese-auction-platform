using System;
using WebAPI_project.Models;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_project.DTOs
{
    public class TicketCreateDto
    {
        [Required]
        public int PrizeId { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool IsDraft { get; set; } = true;
    }
}
