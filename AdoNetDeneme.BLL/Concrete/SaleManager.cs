using AdoNet.BLL.Abstract;
using AdoNet.DAL.Abstract;
using AdoNet.Entities.Base;
using AdoNet.Entities.Dtos.ProcedureDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Concrete
{
    public class SaleManager : ISaleService
    {
        private readonly ISaleRepository _salesRepository;

        public SaleManager(ISaleRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public Response<string> AddSalesQuery(DtoAddSalesQuery salesQuery)
        {
            try
            {
                var guid = _salesRepository.AddSalesQuery(salesQuery, "addSalesQuery");
                return new Response<string>
                {
                    Data = guid,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Data = null,
                    Message = $"Error {ex.Message}",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

        }

        public Response<List<DtoGetAllSoldPolicies>> GetAllSales()
        {
            try
            {
                var result = _salesRepository.GetAllSales(Procedure: "GetAllSoldPolicies");
                return new Response<List<DtoGetAllSoldPolicies>>
                {
                    Data = result,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<DtoGetAllSoldPolicies>>
                {
                    Data = null,
                    Message = $"Error {ex.Message}",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public Response<List<DtoGetSoldPoliciesByEmail>> GetSoldPoliciesByEmail(string email)
        {
            try
            {
                var result = _salesRepository.GetSalesByEmail(email, Procedure: "GetSoldPoliciesByEmail");
                return new Response<List<DtoGetSoldPoliciesByEmail>>
                {
                    Data = result,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<DtoGetSoldPoliciesByEmail>>
                {
                    Data = null,
                    Message = $"Error {ex.Message}",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public Response Sale(DtoPay salesGuid)
        {
            try
            {
                _salesRepository.Sale(salesGuid, "Pay");
                return new Response
                {
                    Data = null,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Data = null,
                    Message = $"Error {ex.Message}",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

        }
    }
}
