using AdoNet.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.DAL.Abstract
{
    public interface IPolicyRepository : IGenericRepository<Policies>
    {
        List<Policies> GetAllPolicies(string Procedure = null);
    }
}
