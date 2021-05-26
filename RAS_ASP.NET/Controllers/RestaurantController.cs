using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace WebApplication.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: RestaurantController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var restaurants = new DAOFactory(session).GetRestaurantDAO().GetAll();
                return View(restaurants);
            }
        }

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var restaurant = new DAOFactory(session).GetRestaurantDAO().GetRestaurantByID(id);
                return View(restaurant);
            }
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetRestaurantDAO().SaveOrUpdate(entity);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var restaurant = new DAOFactory(session).GetRestaurantDAO().GetRestaurantByID(id);
                return View(restaurant);
            }
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var restDAO = new DAOFactory(session).GetRestaurantDAO();
                    var restaurant = restDAO.GetRestaurantByID(id);

                    restaurant.Address = entity.Address;
                    restaurant.CloseTime = entity.CloseTime;
                    restaurant.CooksSummary = entity.CooksSummary;
                    restaurant.Cuisines = entity.Cuisines;
                    restaurant.Name = entity.Name;
                    restaurant.OpenTime = entity.OpenTime;
                    restaurant.SeatCapacity = entity.SeatCapacity;

                    restDAO.SaveOrUpdate(restaurant);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var restaurant = new DAOFactory(session).GetRestaurantDAO().GetRestaurantByID(id);
                return View(restaurant);
            }
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RestaurantEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                   new DAOFactory(session).GetRestaurantDAO().Delete(entity); 
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
