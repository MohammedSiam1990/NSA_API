using POS.Data.Dto;
using Steander.Core.DTOs;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.IService
{
    public interface IAccountService
    {

        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        Task<LoginResponseDto> LoginUserAsync(LoginViewModel model);

        Task<bool> ConfirmEmailAsync(string userId, string code);

        Task<UserManagerResponse> ForgetPasswordAsync(String Email, string Lang);
        Task<UserManagerResponse> ResetPassword(ResetPasswordViewModel model);
        IList<ApplicationUser> GetAllUsersAsync();

        Task<ApplicationUser> GetUserAsync(string Id);
        Task<UserManagerResponse> UpdateUserAsync(string Id, UserDto user);
        Task<UserManagerResponse> DeletetUserAsync(string Id);
        Task<UserManagerResponse> ChangePassword(string userName, string OldPassword, string NewPassword);
        Task<ApplicationUser> IdentityApplicationUser(string userName);
    }
}