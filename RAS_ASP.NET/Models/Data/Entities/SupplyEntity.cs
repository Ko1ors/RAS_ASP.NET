using System;
using System.Collections.Generic;


namespace WebApplication.Data.Entities
{

    public class SupplyEntity : AbstractEntity
    {
        public virtual double? ProdQuantity { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
