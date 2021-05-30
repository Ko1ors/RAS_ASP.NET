using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAS_ASP.NET.Models
{
    public class CuisineProcedure
    {
        public int ID { get; set; }

        public string Status { get; set; }

        public CuisineTotalRecord CuisineTotalRecord { get; set; }
    }
}
