using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Entites
{
    public class Sales : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int PolicyId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PricePerInstallment { get; set; }
        public int RemainingInstallment { get; set; }
        public int TotalInstallment { get; set; }
    }
}
