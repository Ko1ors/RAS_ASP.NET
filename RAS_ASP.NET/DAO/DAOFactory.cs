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

        public override IDishDAO GetDishDAO()
        {
            return new DishDAO(session);
        }

        public override IComponentDAO GetComponentDAO()
        {
            return new ComponentDAO(session);
        }

        public override IOrderDAO GetOrderDAO()
        {
            return new OrderDAO(session);
        }

        public override ISupplyDAO GetSupplyDAO()
        {
            return new SupplyDAO(session);
        }

        public override IProductDAO GetProductDAO()
        {
            return new ProductDAO(session);
        }
    }
}
