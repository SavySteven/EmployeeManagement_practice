﻿using BasicLibrary.DTOs;
using BasicLibrary.Responses;



namespace ClientLibrary.Services.Contracts
{
    public interface IUserAccountService
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken user);
        Task<WeatherForecast[]> GetWeatherForecast();


    }
}
