

using BasicLibrary.DTOs;
using BasicLibrary.Entities;
using BasicLibrary.Responses;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(Register User);
        Task<LoginResponse> SignInAsync(Login User);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken Token);

        Task<List<ManageUser>> GetUsers();
        Task<GeneralResponse> UpdateUser(ManageUser user);
        Task<List<SystemRole>> GetRoles();
        Task<GeneralResponse> DeleteUser(int id);
    }
}
