using System.Collections.Generic;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Models
{
    public class DishProcedure : DishEntity
    {
        public int ComponentCount { get; set; }

        public string Status { get; set; }

        public DishProcedure()
        {
            Component = new List<ComponentEntity>();
        }
    }
}
