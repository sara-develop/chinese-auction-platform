using System;

public class TicketGetDto
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }

    // פרטי המתנה
    public int PrizeId { get; set; }
    public string PrizeName { get; set; }
    public int PrizePrice { get; set; }

    // פרטי המשתמש
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
}


//CreateMap<Ticket, TicketGetDto>()
//    .ForMember(dest => dest.PrizeName, opt => opt.MapFrom(src => src.Prize.Name))
//    .ForMember(dest => dest.PrizePrice, opt => opt.MapFrom(src => src.Prize.Price))
//    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
//    .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));

