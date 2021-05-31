using System.Collections.Generic;


namespace WebApplication.Data.Entities
{

    public class DishEntity : AbstractEntity
    {
        public virtual CuisineEntity Cuisine { get; set; }
        public virtual string DishName { get; set; }
        public virtual double? Price { get; set; }
        public virtual double? Weight { get; set; }
        public virtual IList<ComponentEntity> Component { get; set; }
        public virtual IList<OrderEntity> Order { get; set; }
    }
}
