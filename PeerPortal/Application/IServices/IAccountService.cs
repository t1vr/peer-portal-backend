using Application.Request_Model;
using Application.ResponseModel;
using Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAccountService
    {
        Task<BaseResponse<UserRegistrationResponseModel>> RegisterUserAsync(RegisterRequest registerRequest);
        Task<BaseResponse<string>> ConfirmEmailAsync(string userId, string token);
        Task<BaseResponse<UserResponseModel>> AuthenticateAsync(AuthenticationRequest authenticationRequest);
    }
}
