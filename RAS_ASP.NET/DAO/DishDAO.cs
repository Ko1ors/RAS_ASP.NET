using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace WebApplication.Data.DAO
{
    public class DishDAO : GenericDAO<DishEntity>, IDishDAO
    {
        public DishDAO(ISession session) : base(session) { }

        public List<ComponentEntity> Add(double price, double weight, int cuisID, int componentCount)
        {
            return session.CreateSQLQuery("Call AddDish (?, ?, ?, ?)")
                 .AddEntity(typeof(ComponentEntity))
                  .SetDouble(0, price)
                  .SetDouble(1, weight)
                  .SetInt32(2, cuisID)
                  .SetInt32(3, componentCount).List<ComponentEntity>().ToList();
        }
    }
}
