using RAS_ASP.NET.Models;
using System.Collections.Generic;
using WebApplication.Data.Entities;

namespace WebApplication.Data.DAO
{
    public interface IOrderDAO : IGenericDAO<OrderEntity>
    {
        void Create(int dishID, PaymentType payType);

        bool CreateWithCheck(int dishID, PaymentType payType);
    }
}
