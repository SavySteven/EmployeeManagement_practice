

using BasicLibrary.DTOs;
using BasicLibrary.Responses;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(Register User);
        Task<LoginResponse> SignInAsync(Login User);

    }
}
