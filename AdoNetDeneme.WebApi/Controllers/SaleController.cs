using AdoNet.BLL.Abstract;
using AdoNet.Entities.Base;
using AdoNet.Entities.Dtos.ProcedureDto;
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
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("getSoldPoliciesByEmail")]
        public Response<List<DtoGetSoldPoliciesByEmail>> GetSoldPoliciesByEmail(string email)
        {
            return _saleService.GetSoldPoliciesByEmail(email);
        }

        [HttpGet("GetAllSales")]
        public Response<List<DtoGetAllSoldPolicies>> GetAllSales()
        {
            return _saleService.GetAllSales();
        }

        [HttpPost("AddSalesQuery")]
        public Response<string> AddSalesQuery(DtoAddSalesQuery salesQuery)
        {
            return _saleService.AddSalesQuery(salesQuery);
        }

        [HttpPost("Pay")]
        public Response Pay(DtoPay pay)
        {
            return _saleService.Sale(pay);
        }
    }
}
