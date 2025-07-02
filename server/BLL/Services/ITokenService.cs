using WebAPI_project.Models;

namespace WebAPI_project.BLL.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}


