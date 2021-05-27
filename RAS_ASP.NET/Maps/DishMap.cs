using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using WebApplication.Data.Entities;


namespace Sample.CustomerService.Maps {
    
    
    public class DishMap : ClassMapping<DishEntity> {
        
        public DishMap() {
			Schema("mydbcopy");
			Lazy(true);
			Id(x => x.ID, map => map.Generator(Generators.Assigned));
			Property(x => x.DishName, map => map.Column("dish_name"));
			Property(x => x.Price);
			Property(x => x.Weight);
			ManyToOne(x => x.Cuisine, map => { map.Column("cuisine_cuisID"); map.Cascade(Cascade.None); });

			Bag(x => x.Component, colmap =>  { colmap.Key(x => x.Column("")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.Order, colmap =>  { colmap.Key(x => x.Column("")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
