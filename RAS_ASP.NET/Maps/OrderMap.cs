using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using WebApplication.Data.Entities;


namespace Sample.CustomerService.Maps {
    
    
    public class OrderMap : ClassMapping<OrderEntity> {
        
        public OrderMap() {
			Schema("mydb");
			Lazy(true);
			Id(x => x.ID, map => map.Generator(Generators.Assigned));
			Property(x => x.PayType, map => map.Column("pay_type"));
			Property(x => x.Date);
			ManyToOne(x => x.Dish, map => { map.Column("dish_dishID"); map.Cascade(Cascade.None); });

        }
    }
}
