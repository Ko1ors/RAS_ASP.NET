using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Models
{
    public class OrderProcedure : OrderEntity
    {
        public bool UseCheck { get; set; }

        public string Status { get; set; }

    }
}

