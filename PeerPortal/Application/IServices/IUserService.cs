using Application.Request_Model;
using Application.ResponseModel;
using Application.Wrapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        public Task<BaseResponse<UserRegistrationResponseModel>> RegisterUserAsync(RegisterRequest registerRequest);
    }
}
