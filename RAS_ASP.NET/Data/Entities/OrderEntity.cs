using System;


namespace WebApplication.Data.Entities
{

    public class OrderEntity : AbstractEntity
    {
        public virtual DishEntity Dish { get; set; }
        public virtual string PayType { get; set; }
        public virtual DateTime? Date { get; set; }
    }
}
