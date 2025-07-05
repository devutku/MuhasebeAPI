using MuhasebeAPI.Application.DTOs;
namespace MuhasebeAPI.Application.Interfaces
{
    public interface IUserService
    {
        public Task<string?> RegisterAsync(UserRegisterDto userRegisterDto);
        public Task<string?> LoginAsync(LoginRequest loginRequest);

    }
}
