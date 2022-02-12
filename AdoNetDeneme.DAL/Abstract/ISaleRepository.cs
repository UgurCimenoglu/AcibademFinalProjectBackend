using AdoNet.Entities.Base;
using AdoNet.Entities.Dtos.ProcedureDto;
using AdoNet.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.DAL.Abstract
{
    public interface ISaleRepository : IGenericRepository<Sales>
    {
        List<DtoGetSoldPoliciesByEmail> GetSalesByEmail(string Email, string Procedure = null);
        List<DtoGetAllSoldPolicies> GetAllSales(string Procedure = null);
        string AddSalesQuery(DtoAddSalesQuery salesQuery, string Procedure = null);
        void Sale(DtoPay salesGuid, string Procedure = null);
    }
}
