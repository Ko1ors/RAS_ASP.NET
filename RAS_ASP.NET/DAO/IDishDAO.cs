using System.Collections.Generic;
using WebApplication.Data.Entities;

namespace WebApplication.Data.DAO
{
    public interface IDishDAO : IGenericDAO<DishEntity>
    {
        void Add(double price, double weight, int cuisID, int componentCount);
    }
}
