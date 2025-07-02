using WebAPI_project.Models;
using WebAPI_project.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI_project.DAL;


namespace WebAPI_project.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> AuthenticateAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<List<UserGetDto>> GetAllAsync()
        {
            var users = await _context.Users.Include(u => u.Tickets).ToListAsync();
            return _mapper.Map<List<UserGetDto>>(users);
        }

        public async Task<UserGetDto> GetByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Tickets).FirstOrDefaultAsync(u => u.Id == id);
            return user == null ? null : _mapper.Map<UserGetDto>(user);
        }

        public async Task<int> CreateAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _mapper.Map(dto, user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
