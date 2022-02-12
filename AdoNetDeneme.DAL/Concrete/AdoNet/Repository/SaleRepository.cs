using AdoNet.DAL.Abstract;
using AdoNet.Entities.Dtos.ProcedureDto;
using AdoNet.Entities.Entites;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.DAL.Concrete.AdoNet.Repository
{
    public class SaleRepository : Repository<Sales>, ISaleRepository
    {
        private readonly IConfiguration _configuration;
        public SaleRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public string AddSalesQuery(DtoAddSalesQuery salesQuery, string Procedure = null)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                bool isOkey;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in salesQuery.GetType().GetProperties())
                {
                    cmd.Parameters.AddWithValue(item.Name, item.GetValue(salesQuery, null));
                }
                cmd.ExecuteNonQuery();
                return cmd.ExecuteScalar().ToString();
            }
        }

        public List<DtoGetAllSoldPolicies> GetAllSales(string Procedure = null)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                List<DtoGetAllSoldPolicies> dtoGetSoldList = new List<DtoGetAllSoldPolicies>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new DtoGetAllSoldPolicies
                    {
                        PolicyName = rdr["PolicyName"].ToString(),
                        FullName = rdr["FullName"].ToString(),
                        TotalInstallment = Convert.ToInt32(rdr["TotalInstallment"]),
                        TotalPrice = (int)Convert.ToDecimal(rdr["TotalPrice"]),
                        RemainingInstallment = Convert.ToInt32(rdr["RemainingInstallment"]),
                        PricePerInstallment = (int)Convert.ToDecimal(rdr["PricePerInstallment"])
                    };

                    dtoGetSoldList.Add(data);
                }
                return dtoGetSoldList;
            }
        }

        public List<DtoGetSoldPoliciesByEmail> GetSalesByEmail(string Email, string Procedure = null)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                List<DtoGetSoldPoliciesByEmail> dtoGetSoldList = new List<DtoGetSoldPoliciesByEmail>();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"Email", Email);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var data = new DtoGetSoldPoliciesByEmail
                    {
                        PolicyName = rdr["PolicyName"].ToString(),
                        FullName = rdr["FullName"].ToString(),
                        TotalInstallment = Convert.ToInt32(rdr["TotalInstallment"]),
                        TotalPrice = (int)Convert.ToDecimal(rdr["TotalPrice"]),
                        RemainingInstallment = Convert.ToInt32(rdr["RemainingInstallment"]),
                        PricePerInstallment = (int)Convert.ToDecimal(rdr["PricePerInstallment"])
                    };

                    dtoGetSoldList.Add(data);
                }
                return dtoGetSoldList;
            }
        }

        public void Sale(DtoPay salesGuid,string Procedure=null)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                bool isOkey;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in salesGuid.GetType().GetProperties())
                {
                    cmd.Parameters.AddWithValue(item.Name, item.GetValue(salesGuid, null));
                }
                cmd.ExecuteNonQuery();
            }
        }
    }

}