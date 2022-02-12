using AdoNet.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.DAL.Abstract
{
    public interface IInstallmentRepository : IGenericRepository<Installment>
    {
        List<Installment> GetAllInstallments(string Procedure = null);
    }
}
