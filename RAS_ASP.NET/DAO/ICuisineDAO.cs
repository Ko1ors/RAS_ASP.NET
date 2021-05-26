using WebApplication.Data.Entities;

namespace WebApplication.Data.DAO
{
    public interface ICuisineDAO : IGenericDAO<CuisineEntity>
    {
        CuisineEntity GetCuisineByRestaurantAndName(long restID, string name);
    }
}
