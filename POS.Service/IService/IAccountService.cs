using POS.Data.Dto;
using POS.Data.Dto.Account;
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

        Task<UserManagerResponse> CreateUserAsync(CreateUserModel model);

        Task<LoginResponseDto> LoginUserAsync(LoginViewModel model);

        Task<bool> ConfirmEmailAsync(string userId, string code);

        Task<UserManagerResponse> ForgetPasswordAsync(String Email, string Lang);
        Task<UserManagerResponse> ResetPassword(ResetPasswordViewModel model);
        IList<ApplicationUser> GetAllUsersAsync(int CompanyID);

        Task<ApplicationUser> GetUserAsync(string Id);
        Task<UserManagerResponse> AddUserAsync(UserModel model);
        Task<UserManagerResponse> UpdateUserAsync(UserModel model);
        Task<UserManagerResponse> DeletetUserAsync(string Id);
        Task<UserManagerResponse> ChangePassword(string UserID, string OldPassword, string NewPassword);
        Task<ApplicationUser> IdentityApplicationUser(string userName);
    }
}