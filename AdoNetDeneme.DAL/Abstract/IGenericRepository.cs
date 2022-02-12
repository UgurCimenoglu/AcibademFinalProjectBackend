using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.DAL.Abstract
{
    public interface IGenericRepository<T> where T : IEntity
    {
        T Add(T entity, string Procedure=null);
        T Update(T entity, string Procedure = null);
        T Find(int id, string Procedure = null);
        List<T> GetAll(string Procedure = default);
        bool Delete(int id, string Procedure = null);
        bool Delete(T entity, string Procedure = null);
    }
}
