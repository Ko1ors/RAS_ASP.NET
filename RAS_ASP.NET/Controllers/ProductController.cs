using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var products = new DAOFactory(session).GetProductDAO().GetAll();
                return View(products);
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var product = new DAOFactory(session).GetProductDAO().GetById(id);
                return View(product);
            }
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetProductDAO().SaveOrUpdate(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var product = new DAOFactory(session).GetProductDAO().GetById(id);
                return View(product);
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var productDAO = new DAOFactory(session).GetProductDAO();
                    var product = productDAO.GetById(id);

                    product.AvailCount = entity.AvailCount;
                    product.Component = entity.Component;
                    product.Name = entity.Name;
                    product.Supply = entity.Supply;
                    productDAO.SaveOrUpdate(product);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var order = new DAOFactory(session).GetOrderDAO().GetById(id);
                return View(order);
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetProductDAO().Delete(entity);
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
