using NHibernate;
using RAS_ASP.NET.Models.Data.Entities;
using WebApplication.Data.DAO;

namespace RAS_ASP.NET.DAO
{
    public class OrderSummaryDAO : GenericDAO<OrderSummary>, IOrderSummaryDAO
    {
        public OrderSummaryDAO(ISession session) : base(session) { }
    }
}
