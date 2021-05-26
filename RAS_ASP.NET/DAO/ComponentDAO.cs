using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data.DAO
{
    public class ComponentDAO : GenericDAO<ComponentEntity>, IComponentDAO
    {
        public ComponentDAO(ISession session) : base(session) { }
    }
}
