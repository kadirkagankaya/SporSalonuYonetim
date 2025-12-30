using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;

namespace SporSalonuYonetim.Core.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
    }
}
