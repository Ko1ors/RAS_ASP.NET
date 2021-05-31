using FluentNHibernate.Mapping;
using RAS_ASP.NET.Models.Data.Entities;

namespace RAS_ASP.NET.Maps
{
    public class OrderSummaryMap : ClassMap<OrderSummary>
    {

        public OrderSummaryMap()
        {
            Table("orderssummary");
            Id(e => e.Dish_dishID).Column("dish_dishID");
            Map(e => e.Apr_total).Column("apr_total");
            Map(e => e.Aug_total).Column("aug_total");
            Map(e => e.Dec_total).Column("dec_total");
            Map(e => e.Feb_total).Column("feb_total");
            Map(e => e.Jan_total).Column("jan_total");
            Map(e => e.Jul_total).Column("jul_total");
            Map(e => e.Jun_total).Column("jun_total");
            Map(e => e.Mar_total).Column("mar_total");
            Map(e => e.May_total).Column("may_total");
            Map(e => e.Nov_total).Column("nov_total");
            Map(e => e.Okt_total).Column("okt_total");
            Map(e => e.Sep_total).Column("sep_total");
            Map(e => e.Total).Column("total");
            ReadOnly();
        }
    }
}
