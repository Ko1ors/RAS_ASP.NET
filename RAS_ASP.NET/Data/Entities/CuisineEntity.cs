using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Data.Entities
{
    public class CuisineEntity : AbstractEntity
    {
        public virtual string Name { get; set; }

        public virtual int? CooksNumber { get; set; }

        public virtual decimal? AverageDish { get; set; }

        public virtual RestaurantEntity Restaurant { get; set; }

        public virtual int? DishesSummary { get; set; }

    }
}
