using WebApplication.Data.Entities;
using NHibernate;

namespace WebApplication.Data.DAO
{
    public class CuisineDAO : GenericDAO<CuisineEntity>, ICuisineDAO
    {
        public CuisineDAO(ISession session) : base(session) { }

        public CuisineEntity GetCuisineByRestaurantAndName(long restID, string name)
        {
            var list = session.CreateSQLQuery("SELECT cuisine.* FROM cuisine JOIN restaurant"
                + " ON cuisine.restaurant_restID = restaurant.restID"
                + " WHERE restaurant.restID=" + restID + " and cuisine.name='" + name + "'")
                .AddEntity("Cuisine", typeof(CuisineEntity)).List<CuisineEntity>();
            return list[0];
        }
    }
}
