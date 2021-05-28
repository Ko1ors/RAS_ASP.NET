using FluentNHibernate.Mapping;
using RAS_ASP.NET.Models;
using WebApplication.Data.Entities;

namespace Sample.CustomerService.Maps
{

    public class OrderMap : ClassMap<OrderEntity>
    {

        public OrderMap()
        {
            Table("``order``");
            Id(e => e.ID).GeneratedBy.Assigned().Column("orderID");
            Map(e => e.PayType).Column("pay_type").CustomType<GenericEnumMapper<PaymentType>>();
            Map(e => e.Date).Column("date");
            References(e => e.Dish).ForeignKey().Column("dish_dishID");

        }
    }
}
