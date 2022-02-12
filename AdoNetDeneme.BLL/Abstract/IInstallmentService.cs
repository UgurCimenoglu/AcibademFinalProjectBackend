using AdoNet.Entities.Base;
using AdoNet.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Abstract
{
    public interface IInstallmentService
    {
        Response<List<Installment>> GetAllInstallments();
    }
}
