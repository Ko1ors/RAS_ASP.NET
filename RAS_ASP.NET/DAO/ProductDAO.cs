using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data.DAO
{
    public class ProductDAO : GenericDAO<ProductEntity>, IProductDAO
    {
        public ProductDAO(ISession session) : base(session) { }
    }
}
