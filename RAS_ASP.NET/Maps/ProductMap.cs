using WebApplication.Data.Entities;
using FluentNHibernate.Mapping;

namespace Sample.CustomerService.Maps {
    
    
    public class ProductMap : ClassMap<ProductEntity> {
        
        public ProductMap() {

            Table("product");
            Id(e => e.ID).GeneratedBy.Assigned().Column("productID");
            Map(e => e.Name).Column("name");
            Map(e => e.AvailCount).Column("avail_count");
            HasMany(e => e.Component).Inverse().Cascade.All().KeyColumn("Product_productID");
            HasMany(e => e.Supply).Inverse().Cascade.All().KeyColumn("Product_productID");
        }
    }
}
