using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Sample.CustomerService.Domain;


namespace Sample.CustomerService.Maps {
    
    
    public class ProductMap : ClassMapping<Product> {
        
        public ProductMap() {
			Schema("mydbcopy");
			Lazy(true);
			Id(x => x.Productid, map => map.Generator(Generators.Assigned));
			Property(x => x.Name);
			Property(x => x.AvailCount, map => map.Column("avail_count"));
			Bag(x => x.Component, colmap =>  { colmap.Key(x => x.Column("")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.Supply, colmap =>  { colmap.Key(x => x.Column("")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
