using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Dtos.ProcedureDto
{
    public class DtoAddSalesQuery : IDto
    {
        public int UserId{ get; set; }
        public int PolicyId{ get; set; }
        public int InstallmentId { get; set; }
    }
}
