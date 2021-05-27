using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using WebApplication.Data.Entities;

namespace Sample.CustomerService.Maps {
    
    
    public class ComponentMap : ClassMapping<ComponentEntity> {
        
        public ComponentMap() {
			Schema("mydb");
			Lazy(true);
			Id(x => x.ID, map => map.Generator(Generators.Assigned));
			Property(x => x.NeedCount, map => map.Column("need_count"));
			ManyToOne(x => x.Dish, map => { map.Column("Dish_dishID"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.Product, map => { map.Column("Product_productID"); map.Cascade(Cascade.None); });

        }
    }
}
