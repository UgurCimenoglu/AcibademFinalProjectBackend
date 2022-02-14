using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Dtos
{
    public class DtoGetUserrByEmail : IDto
    {
        public string Email { get; set; }
    }
}
