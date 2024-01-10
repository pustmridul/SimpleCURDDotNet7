using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using SimpleCURDDotNet7.Data;
using SimpleCURDDotNet7.DTOs;
using SimpleCURDDotNet7.Interfaces;
using System.Security.Claims;

namespace SimpleCURDDotNet7.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        public UserService(AppDbContext context, ITokenService tokenService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tokenService = tokenService;
        }
        public async Task<LoginRes> UserLogin(LoginReq model)
        {
            try
            {
                var obj = await _context.UserInfos
                    .SingleOrDefaultAsync(q => q.UserName == model.UserName && q.Password==model.Password);
                if (obj == null)
                {
                    throw new Exception();
                }
                else
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.UserName??""),
                            new Claim(ClaimTypes.Role, "Admin")
                        };
                    var accessToken = _tokenService.GenerateAccessToken(claims);
                    var refreshToken = _tokenService.GenerateRefreshToken();

                    obj.RefreshToken = refreshToken;
                    obj.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

                    await  _context.SaveChangesAsync();
                    return new LoginRes
                    {
                        Token = accessToken,
                        RefreshToken = refreshToken,
                    };
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Revok(string username)
        {
           
            var user =await _context.UserInfos.SingleOrDefaultAsync(u => u.UserName == username);
            if (user == null) return false;

            user.RefreshToken = null;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<LoginRes> Refresh(TokenReq model)
        {
            try
            {
                string accessToken = model?.AccessToken??"";
                string refreshToken = model?.RefreshToken ?? "";

                var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken??"");
                var username = principal.Identity?.Name; 

                var user = _context.UserInfos.SingleOrDefault(u => u.UserName == username);

                if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                     throw new Exception("Invalid client request");

                var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;

                await _context.SaveChangesAsync();

                return new LoginRes()
                {
                    Token = newAccessToken,
                    RefreshToken = newRefreshToken
                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           


           
        }
    }
}
