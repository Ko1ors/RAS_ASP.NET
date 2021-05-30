using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Models;
using System.Collections.Generic;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;
namespace RAS_ASP.NET.Controllers
{
    public class Procedure2Controller : Controller
    {

        // GET: Procedure2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedure2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var factory = new DAOFactory(session);
                    factory.GetDishDAO().Add(entity.Price, entity.Weight, 
                        (int)entity.Cuisine.ID, entity.Component.Count);
                }
                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }
    }
}
