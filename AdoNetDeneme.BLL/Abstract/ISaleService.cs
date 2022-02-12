using AdoNet.Entities.Base;
using AdoNet.Entities.Dtos.ProcedureDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Abstract
{
    public interface ISaleService
    {
        Response<List<DtoGetSoldPoliciesByEmail>> GetSoldPoliciesByEmail(string email);
        Response<List<DtoGetAllSoldPolicies>> GetAllSales();
        Response<string> AddSalesQuery(DtoAddSalesQuery salesQuery);
        Response Sale(DtoPay salesGuid);
    }
}
