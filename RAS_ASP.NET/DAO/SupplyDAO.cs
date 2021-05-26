using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data.DAO
{
    public class SupplyDAO : GenericDAO<SupplyEntity>, ISupplyDAO
    {
        public SupplyDAO(ISession session) : base(session) { }
    }
}
