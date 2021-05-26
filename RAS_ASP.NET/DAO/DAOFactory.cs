using NHibernate;
using WebApplication.DAO;

namespace WebApplication.Data.DAO
{
    public class DAOFactory : AbstractDAOFactory
    {
        protected ISession session = null;

        public DAOFactory(ISession session)
        {
            this.session = session;
        }

        public override ICuisineDAO GetCuisineDAO()
        {
            return new CuisineDAO(session);
        }

        public override IRestaurantDAO GetRestaurantDAO()
        {
            return new RestaurantDAO(session);
        }
    }
}
