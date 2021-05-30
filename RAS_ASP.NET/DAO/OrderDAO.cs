using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using RAS_ASP.NET.Models;
using System.Diagnostics;

namespace WebApplication.Data.DAO
{
    public class OrderDAO : GenericDAO<OrderEntity>, IOrderDAO
    {
        public OrderDAO(ISession session) : base(session) { }

        public void Create(int dishID, PaymentType payType)
        {
            session.CreateSQLQuery("Call CreateOrder (?, ?)")
                 .SetInt32(0, dishID)
                 .SetString(1, payType.ToString()).List();
        }

        public bool CreateWithCheck(int dishID, PaymentType payType)
        {
            var result = session.CreateSQLQuery("Call CreateOrderWithProductCheck (?, ?)")
                 .SetInt32(0, dishID)
                 .SetString(1, payType.ToString()).List();

            return result.Count == 0 ? true : false;
        }
    }
}
