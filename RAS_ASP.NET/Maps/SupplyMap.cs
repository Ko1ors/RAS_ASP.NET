using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using WebApplication.Data.Entities;


namespace Sample.CustomerService.Maps
{


    public class SupplyMap : ClassMapping<SupplyEntity>
    {

        public SupplyMap()
        {
            Schema("mydb");
            Lazy(true);
            Id(x => x.ID, map => map.Generator(Generators.Assigned));
            Property(x => x.ProdQuantity, map => map.Column("prod_quantity"));
            Property(x => x.Date);
            ManyToOne(x => x.Product, map => { map.Column("Product_productID"); map.Cascade(Cascade.None); });

        }
    }
}
