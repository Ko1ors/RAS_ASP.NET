using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Models;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
namespace RAS_ASP.NET.Controllers
{
    public class Procedure2Controller : Controller
    {

        // GET: Procedure2Controller/Create
        public ActionResult Create()
        {
            return View(new DishProcedure());
        }

        // POST: Procedure2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishProcedure entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    entity.Component = new DAOFactory(session).GetDishDAO().Add(entity.Price, entity.Weight, (int)entity.Cuisine.ID, entity.ComponentCount);
                    entity.Status = "Successful";
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
