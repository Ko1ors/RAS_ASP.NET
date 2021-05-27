using FluentNHibernate.Mapping;
using WebApplication.Data.Entities;

namespace Sample.CustomerService.Maps
{


    public class DishMap : ClassMap<DishEntity>
    {

        public DishMap()
        {
            Table("dish");
            Id(e => e.ID).GeneratedBy.Assigned().Column("dishID");
            Map(e => e.DishName).Column("dish_name");
            Map(e => e.Price).Column("price");
            Map(e => e.Weight).Column("weight");
            References(e => e.Cuisine).ForeignKey().Column("cuisine_cuisID");
            HasMany(e => e.Component).Inverse().Cascade.All().KeyColumn("Dish_dishID");
            HasMany(e => e.Order).Inverse().Cascade.All().KeyColumn("dish_dishID");
        }
    }
}
