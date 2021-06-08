using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Services;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController()
        {
            _service = new ProductService(this.ModelState, new DAOFactory(NHibernateManager.OpenSession()).GetProductDAO());
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_service.List());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
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
            if (!_service.Create(entity))
                return View();
            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEntity entity)
        {
            if (!_service.Edit(id, entity))
                return View();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductEntity entity)
        {
            if (!_service.Delete(entity))
                return View();
            return RedirectToAction(nameof(Index));
        }
    }
}
