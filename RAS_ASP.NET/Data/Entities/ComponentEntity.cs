using System;
using System.Text;
using System.Collections.Generic;


namespace WebApplication.Data.Entities
{

    public class ComponentEntity : AbstractEntity
    {
        public virtual DishEntity Dish { get; set; }
        public virtual ProductEntity Product { get; set; }
        public virtual double? NeedCount { get; set; }
    }
}
