using BasicLibrary.DTOs;
using BasicLibrary.Entities;
using BasicLibrary.Responses;



namespace ClientLibrary.Services.Contracts
{
    public interface IUserAccountService
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken user);
        Task<WeatherForecast[]> GetWeatherForecast();

        Task<List<ManageUser>> GetUsers();
        Task<GeneralResponse> UpdateUser(ManageUser user);
        Task<List<SystemRole>> GetRoles();
        Task<GeneralResponse> DeleteUser(int id);
    }
}
