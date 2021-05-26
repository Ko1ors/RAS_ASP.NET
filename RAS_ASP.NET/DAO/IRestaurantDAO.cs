using WebApplication.Data.Entities;
using System.Collections.Generic;

namespace WebApplication.Data.DAO
{
    public interface IRestaurantDAO : IGenericDAO<RestaurantEntity>
    {
        RestaurantEntity GetRestaurantByID(long restID);

        List<CuisineEntity> GetAllCuisines(long restID);

        void DeleteRestaurantByID(long restID);
    }
}
