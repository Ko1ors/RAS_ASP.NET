using WebApplication.Data.Entities;
using NHibernate;
using RAS_ASP.NET.Models;
using System.Diagnostics;
using System.Linq;
using System;

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

        public CuisineTotalRecord GetTotalPrice(int cuisID)
        {
            var result = session.CreateSQLQuery("Call GetTotalPriceIN (?)")
                  .SetInt32(0, cuisID).List<object[]>().FirstOrDefault();
            if (result.Length == 2 && result[0] != null)     
                return new CuisineTotalRecord() { TotalPrice = (decimal)result[0], TotalDish = Convert.ToInt32(result[1]) };
            return new CuisineTotalRecord();
        }
    }
}
