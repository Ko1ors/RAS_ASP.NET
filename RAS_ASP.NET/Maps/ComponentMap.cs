
using WebApplication.Data.Entities;
using FluentNHibernate.Mapping;


namespace Sample.CustomerService.Maps {
    
    
    public class ComponentMap : ClassMap<ComponentEntity> {
        
        public ComponentMap() {
            Table("component");
            Id(e => e.ID).GeneratedBy.Assigned().Column("componentID");
            Map(e => e.NeedCount).Column("need_count");
            References(e => e.Dish).ForeignKey().Column("Dish_dishID");
            References(e => e.Product).ForeignKey().Column("Product_productID");
        }
    }
}
