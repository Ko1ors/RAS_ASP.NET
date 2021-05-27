using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class CuisineController : Controller
    {
        // GET: CuisineController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var cuisines = new DAOFactory(session).GetCuisineDAO().GetAll();
                return View(cuisines);
            }
        }

        // GET: CuisineController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var cuisine = new DAOFactory(session).GetCuisineDAO().GetById(id);
                return View(cuisine);
            }
        }

        // GET: CuisineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuisineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuisineEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetCuisineDAO().SaveOrUpdate(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuisineController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var cuisine = new DAOFactory(session).GetCuisineDAO().GetById(id);
                return View(cuisine);
            }
        }

        // POST: CuisineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CuisineEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var cuisDAO = new DAOFactory(session).GetCuisineDAO();
                    var cuisine = cuisDAO.GetById(id);

                    cuisine.AverageDish = entity.AverageDish;
                    cuisine.CooksNumber = entity.CooksNumber;
                    cuisine.DishesSummary = entity.DishesSummary;
                    cuisine.Restaurant = entity.Restaurant;
                    cuisine.Name = entity.Name;

                    cuisDAO.SaveOrUpdate(cuisine);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuisineController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var cuisine = new DAOFactory(session).GetCuisineDAO().GetById(id);
                return View(cuisine);
            }
        }

        // POST: CuisineController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CuisineEntity entity)
        {
            try
            {
                using(NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetCuisineDAO().Delete(entity);
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
