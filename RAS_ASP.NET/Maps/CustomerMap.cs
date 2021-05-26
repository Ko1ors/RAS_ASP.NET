using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Sample.CustomerService.Domain;


namespace Sample.CustomerService.Maps {
    
    
    public class CustomerMap : ClassMapping<Customer> {
        
        public CustomerMap() {
			Schema("mydbcopy");
			Lazy(true);
			Id(x => x.Customerid, map => map.Generator(Generators.Assigned));
			Property(x => x.Name);
        }
    }
}
