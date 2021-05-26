using WebApplication.Data.Entities;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data.DAO
{
    public class RestaurantDAO : GenericDAO<RestaurantEntity>, IRestaurantDAO
    {
        public RestaurantDAO(ISession session) : base(session) { }

        public void DeleteRestaurantByID(long restID)
        {
            RestaurantEntity restaurant = GetRestaurantByID(restID);
            Delete(restaurant);
        }

        public List<CuisineEntity> GetAllCuisines(long restID)
        {
            var list = session.CreateSQLQuery("SELECT cuisine.* FROM cuisine JOIN restaurant"
                + " ON cuisine.restaurant_restID = restaurant.restID"
                + " WHERE restaurant.restID=" + restID )
                .AddEntity("CuisineEntity", typeof(CuisineEntity)).List<CuisineEntity>();
            return (List<CuisineEntity>)list;

        }

        public RestaurantEntity GetRestaurantByID(long restID)
        {
            var list = session.Query<RestaurantEntity>().Where(e => e.ID == restID).ToList();
            if(list.Count > 0)
                return list[0];
            return null;
        }
    }
}
