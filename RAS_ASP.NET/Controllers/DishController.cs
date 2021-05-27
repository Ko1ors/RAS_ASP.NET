using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class DishController : Controller
    {
        // GET: DishController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var dishes = new DAOFactory(session).GetDishDAO().GetAll();
                new DishDAO(session).Add(100.20, 1.1, 1, 2);
                return View(dishes);
            }
        }

        // GET: DishController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var dish = new DAOFactory(session).GetDishDAO().GetById(id);
                return View(dish);
            }
        }

        // GET: DishController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DishController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetDishDAO().SaveOrUpdate(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DishController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var dish = new DAOFactory(session).GetDishDAO().GetById(id);
                return View(dish);
            }
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DishEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var dishDAO = new DAOFactory(session).GetDishDAO();
                    var dish = dishDAO.GetById(id);

                    dish.Component = entity.Component;
                    dish.Cuisine = entity.Cuisine;
                    dish.DishName = entity.DishName;
                    dish.Order = entity.Order;
                    dish.Price = entity.Price;
                    dish.Weight = entity.Weight;

                    dishDAO.SaveOrUpdate(dish);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DishController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var dish = new DAOFactory(session).GetDishDAO().GetById(id);
                return View(dish);
            }
        }

        // POST: DishController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DishEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetDishDAO().Delete(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
