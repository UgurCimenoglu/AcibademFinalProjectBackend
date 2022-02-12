using AdoNet.BLL.Abstract;
using AdoNet.Entities.Base;
using AdoNet.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoNet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IResponse Register(DtoUserForRegister register)
        {
            return _authService.Register(register);
        }

        [HttpPost("login")]
        public IResponse<DtoUserToken> Login(DtoUserLogin login)
        {
            return _authService.Login(login);
        }
    }
}
