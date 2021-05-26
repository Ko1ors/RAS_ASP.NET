using WebApplication.Data.Entities;
using FluentNHibernate.Mapping;

namespace WebApplication.Maps
{
    public class CuisineMap : ClassMap<CuisineEntity>
    {
        public CuisineMap()
        {
            Table("cuisine");
            Id(e => e.ID).GeneratedBy.Assigned().Column("cuisID");
            Map(e => e.Name).Column("name");
            Map(e => e.CooksNumber).Column("cooks_num");
            Map(e => e.AverageDish).Column("average_dish");
            Map(e => e.DishesSummary).Column("sumDishes");
            References(e => e.Restaurant).ForeignKey().Column("restaurant_restID");
        }
    }
}
