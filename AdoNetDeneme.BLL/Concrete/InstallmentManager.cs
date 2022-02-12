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
    public class InstallmentManager : IInstallmentService
    {
        private readonly IInstallmentRepository _installmentRepository;

        public InstallmentManager(IInstallmentRepository installmentRepository)
        {
            _installmentRepository = installmentRepository;
        }

        public Response<List<Installment>> GetAllInstallments()
        {
            try
            {
                var result = _installmentRepository.GetAllInstallments("GetAllInstallments");
                return new Response<List<Installment>>
                {
                    Data = result,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Installment>>
                {
                    Data = null,
                    Message = $"Error {ex.Message}",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
