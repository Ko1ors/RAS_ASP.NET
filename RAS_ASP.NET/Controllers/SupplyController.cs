using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class SupplyController : Controller
    {
        // GET: SupplyController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var supplies = new DAOFactory(session).GetSupplyDAO().GetAll();
                return View(supplies);
            }
        }

        // GET: SupplyController/Details/5
        public ActionResult Details(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var supply = new DAOFactory(session).GetSupplyDAO().GetById(id);
                return View(supply);
            }
        }

        // GET: SupplyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplyEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetSupplyDAO().SaveOrUpdate(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplyController/Edit/5
        public ActionResult Edit(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var supply = new DAOFactory(session).GetSupplyDAO().GetById(id);
                return View(supply);
            }
        }

        // POST: SupplyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SupplyEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var supplyDAO = new DAOFactory(session).GetSupplyDAO();
                    var supply = supplyDAO.GetById(id);

                    supply.Date = entity.Date;
                    supply.ProdQuantity = entity.ProdQuantity;
                    supply.Product = entity.Product;
                    supplyDAO.SaveOrUpdate(supply);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplyController/Delete/5
        public ActionResult Delete(int id)
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var supply = new DAOFactory(session).GetSupplyDAO().GetById(id);
                return View(supply);
            }
        }

        // POST: SupplyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SupplyEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    new DAOFactory(session).GetSupplyDAO().Delete(entity);
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
