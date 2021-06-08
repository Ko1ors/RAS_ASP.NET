using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Services;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;

        public OrderController()
        {
            _service = new OrderService(this.ModelState, new DAOFactory(NHibernateManager.OpenSession()).GetOrderDAO());
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View(_service.List());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
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
            if (!_service.Create(entity))
                return View();
            return RedirectToAction("Index");
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEntity entity)
        {
            if (!_service.Edit(id, entity))
                return View();
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderEntity entity)
        {
            if (!_service.Delete(entity))
                return View();
            return RedirectToAction(nameof(Index));
        }
    }
}
