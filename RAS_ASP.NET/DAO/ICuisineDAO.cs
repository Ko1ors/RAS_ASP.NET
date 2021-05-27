using RAS_ASP.NET.Models;
using WebApplication.Data.Entities;

namespace WebApplication.Data.DAO
{
    public interface ICuisineDAO : IGenericDAO<CuisineEntity>
    {
        CuisineEntity GetCuisineByRestaurantAndName(long restID, string name);

        CuisineTotalRecord GetTotalPrice(int cuisID);
    }
}
