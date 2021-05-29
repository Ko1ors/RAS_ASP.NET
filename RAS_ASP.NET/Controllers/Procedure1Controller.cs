using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Models;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class Procedure1Controller : Controller
    {

        // GET: Procedure1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedure1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderProcedure entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var factory = new DAOFactory(session);
                    if (entity.UseCheck)
                    {
                        if(factory.GetOrderDAO().CreateWithCheck((int)entity.Dish.ID, entity.PayType))
                            entity.Status = "Successful";
                        else
                            entity.Status = "Error: Not enough products available";
                    } 
                    else
                    {
                        
                        if(factory.GetDishDAO().GetById((int)entity.Dish.ID) == null)
                            entity.Status = "Error: dish with the setted id was not found";
                        else
                        {
                            factory.GetOrderDAO().Create((int)entity.Dish.ID, entity.PayType);
                            entity.Status = "Successful";
                        }
                    }
                }

                return View(entity);
            }
            catch
            {
                entity.Status = "Error";
                return View(entity);
            }
        }
    }
}
