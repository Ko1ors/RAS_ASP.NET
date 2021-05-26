using WebApplication.Data.Entities;
using FluentNHibernate.Mapping;

namespace WebApplication.Maps
{
    public class RestaurantMap : ClassMap<RestaurantEntity>
    {
        public RestaurantMap()
        {
            Table("restaurant");
            Id(e => e.ID).GeneratedBy.Assigned().Column("restID");
            Map(e => e.Name).Column("name");
            Map(e => e.Address).Column("address");
            Map(e => e.OpenTime).Column("open_time");
            Map(e => e.CloseTime).Column("close_time");
            Map(e => e.SeatCapacity).Column("seat_capacity");
            Map(e => e.CooksSummary).Column("sumCooks");
            HasMany(e => e.Cuisines).Inverse().Cascade.All().KeyColumn("restaurant_restID");
        }
    }
}
