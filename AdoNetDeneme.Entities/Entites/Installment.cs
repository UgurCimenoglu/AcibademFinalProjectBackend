using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Entites
{
    public class Installment : IEntity
    {
        public int Id { get; set; }
        public int Installments { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
