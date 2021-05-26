using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data.DAO
{
    public class DishDAO : GenericDAO<DishEntity>, IDishDAO
    {
        public DishDAO(ISession session) : base(session) { }
    }
}
