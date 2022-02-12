using AdoNet.BLL.Abstract;
using AdoNet.DAL.Abstract;
using AdoNet.Entities.Base;
using AdoNet.Entities.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Concrete
{
    public class PolicyManager : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyManager(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public Response<List<Policies>> GetAllPolicies()
        {
            try
            {
                var result = _policyRepository.GetAllPolicies("GetAllPolicies");
                return new Response<List<Policies>>
                {
                    Data = result,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {

                return new Response<List<Policies>>
                {
                    Data = null,
                    Message = $"Error : {ex.Message}",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
