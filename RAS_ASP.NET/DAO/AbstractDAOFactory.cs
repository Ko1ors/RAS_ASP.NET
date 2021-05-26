using WebApplication.Data.DAO;

namespace WebApplication.DAO
{
    public abstract class AbstractDAOFactory
    {
        public abstract IRestaurantDAO GetRestaurantDAO();

        public abstract ICuisineDAO GetCuisineDAO();
    }
}
