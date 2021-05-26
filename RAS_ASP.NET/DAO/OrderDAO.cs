using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data.DAO
{
    public class OrderDAO : GenericDAO<OrderEntity>, IOrderDAO
    {
        public OrderDAO(ISession session) : base(session) { }
    }
}
