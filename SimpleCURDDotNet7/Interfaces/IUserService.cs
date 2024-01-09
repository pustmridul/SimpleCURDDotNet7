using SimpleCURDDotNet7.Data;
using SimpleCURDDotNet7.DTOs;

namespace SimpleCURDDotNet7.Interfaces
{
    public interface IUserService
    {
        Task<LoginRes> UserLogin(LoginReq model);
        Task<bool> Revok(string username);

        Task<LoginRes> Refresh(TokenReq model);
    }
}
