using FluentNHibernate.Mapping;
using WebApplication.Data.Entities;

namespace Sample.CustomerService.Maps
{


    public class SupplyMap : ClassMap<SupplyEntity>
    {

        public SupplyMap()
        {
            Table("supply");
            Id(e => e.ID).GeneratedBy.Assigned().Column("supplyID");
            Map(e => e.Date).Column("date");
            Map(e => e.ProdQuantity).Column("prod_quantity");
            References(e => e.Product).ForeignKey().Column("Product_productID");
        }
    }
}
