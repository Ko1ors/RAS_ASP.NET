using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var orders = new DAOFactory(session).GetOrderDAO().GetAll();
                return View(orders);
            }
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var order = new DAOFactory(session).GetOrderDAO().GetById(id);
                return View(order);
            }
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetOrderDAO().SaveOrUpdate(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var order = new DAOFactory(session).GetOrderDAO().GetById(id);
                return View(order);
            }
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var orderDAO = new DAOFactory(session).GetOrderDAO();
                    var order = orderDAO.GetById(id);

                    order.Date = entity.Date;
                    order.Dish = entity.Dish;
                    order.PayType = entity.PayType;
                    orderDAO.SaveOrUpdate(order);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var order = new DAOFactory(session).GetOrderDAO().GetById(id);
                return View(order);
            }
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetOrderDAO().Delete(entity);
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
