using AutoMapper;
using WebAPI_project.Models;

namespace WebAPI_project
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCreateDto, User>();

            CreateMap<UserUpdateDto, User>();

            CreateMap<User, UserGetDto>()
                .ForMember(dest => dest.Purchases, opt => opt.MapFrom(src => src.Tickets.Select(t => t.Id).ToList()));

            CreateMap<Ticket, TicketGetDto>()
               .ForMember(dest => dest.PrizeName, opt => opt.MapFrom(src => src.Prize.Name))
               .ForMember(dest => dest.PrizePrice, opt => opt.MapFrom(src => src.Prize.Price))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
               .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<TicketCreateDto, Ticket>().ReverseMap();

            CreateMap<PrizeCreateDto, Prize>();

            CreateMap<PrizeUpdateDto, Prize>().ReverseMap();

            CreateMap<Prize, PrizeGetDto>();

            CreateMap<Prize, PrizeGetPurchasersDto>()
                .ForMember(dest => dest.Purchases, opt => opt.MapFrom(src => src.Tickets));

            CreateMap<DonorCreateDto, Donor>();

            CreateMap<DonorUpdateDto, Donor>()
                .ForMember(dest => dest.Prizes, opt => opt.Ignore());

            CreateMap<Donor, DonorGetDto>()
                .ForMember(dest => dest.PrizesId, opt => opt.MapFrom(src => src.Prizes.Select(p => p.Id).ToList()));

            CreateMap<CategoryCreateDto, Category>();

            CreateMap<CategoryUpdateDto, Category>()
                 .ForMember(dest => dest.Prizes, opt => opt.Ignore());

            CreateMap<Category, CategoryGetDto>();

            CreateMap<Category, CategoryWithPrizesDto>();

        }
    }
}
