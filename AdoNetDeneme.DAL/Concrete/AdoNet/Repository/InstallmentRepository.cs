using AdoNet.DAL.Abstract;
using AdoNet.Entities.Entites;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.DAL.Concrete.AdoNet.Repository
{
    public class InstallmentRepository : Repository<Installment>, IInstallmentRepository
    {
        private readonly IConfiguration _configuration;
        public InstallmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public List<Installment> GetAllInstallments(string Procedure = null)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                List<Installment> AllInstallments = new List<Installment>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new Installment
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Installments = Convert.ToInt32(rdr["Installments"]),
                        Description = rdr["Description"].ToString(),
                        Status = Convert.ToBoolean(rdr["Status"])
                    };

                    AllInstallments.Add(data);
                }
                return AllInstallments;
            }
        }
    }
}
