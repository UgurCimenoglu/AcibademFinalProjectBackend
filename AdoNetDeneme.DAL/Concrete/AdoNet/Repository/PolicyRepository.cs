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
    public class PolicyRepository : Repository<Policies>, IPolicyRepository
    {
        private readonly IConfiguration _configuration;
        public PolicyRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public List<Policies> GetAllPolicies(string Procedure = null)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                List<Policies> dtoAllPolicies = new List<Policies>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new Policies
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                        Description = rdr["Description"].ToString(),
                        Price = (int)Convert.ToDecimal(rdr["Price"]),
                        Status = Convert.ToBoolean(rdr["Status"])
                    };

                    dtoAllPolicies.Add(data);
                }
                return dtoAllPolicies;
            }
        }
    }
}