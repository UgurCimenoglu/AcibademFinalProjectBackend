using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Dtos.ProcedureDto
{
    public class DtoGetAllSoldPolicies : IDto
    {
        public string PolicyName { get; set; }
        public string FullName { get; set; }
        public int TotalInstallment { get; set; }
        public decimal TotalPrice { get; set; }
        public int RemainingInstallment { get; set; }
        public decimal PricePerInstallment { get; set; }
    }
}
