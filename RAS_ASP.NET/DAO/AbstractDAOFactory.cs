using RAS_ASP.NET.DAO;
using WebApplication.Data.DAO;

namespace WebApplication.DAO
{
    public abstract class AbstractDAOFactory
    {
        public abstract IRestaurantDAO GetRestaurantDAO();

        public abstract ICuisineDAO GetCuisineDAO();

        public abstract IDishDAO GetDishDAO();

        public abstract IComponentDAO GetComponentDAO();

        public abstract IOrderDAO GetOrderDAO();

        public abstract ISupplyDAO GetSupplyDAO();

        public abstract IProductDAO GetProductDAO();

        public abstract IOrderSummaryDAO GetOrderSummaryDAO();
    }
}
