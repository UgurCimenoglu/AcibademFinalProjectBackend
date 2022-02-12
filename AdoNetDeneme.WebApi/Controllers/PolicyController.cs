using AdoNet.BLL.Abstract;
using AdoNet.Entities.Base;
using AdoNet.Entities.Entites;
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
    [Authorize]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        [AllowAnonymous]
        [HttpGet("getall")]
        public Response<List<Policies>> GetAll()
        {
            return _policyService.GetAllPolicies();
        }
    }
}
