using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class ComponentController : Controller
    {
        // GET: ComponentController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var components = new DAOFactory(session).GetComponentDAO().GetAll();
                return View(components);
            }
        }

        // GET: ComponentController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var component = new DAOFactory(session).GetComponentDAO().GetById(id);
                return View(component);
            }
        }

        // GET: ComponentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComponentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComponentEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetComponentDAO().SaveOrUpdate(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComponentController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var component = new DAOFactory(session).GetComponentDAO().GetById(id);
                return View(component);
            }
        }

        // POST: ComponentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComponentEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var componentDAO = new DAOFactory(session).GetComponentDAO();
                    var component = componentDAO.GetById(id);

                    component.Dish = entity.Dish;
                    component.NeedCount = entity.NeedCount;
                    component.Product = entity.Product;
                    componentDAO.SaveOrUpdate(component);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComponentController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var component = new DAOFactory(session).GetComponentDAO().GetById(id);
                return View(component);
            }
        }

        // POST: ComponentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ComponentEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetComponentDAO().Delete(entity);
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
