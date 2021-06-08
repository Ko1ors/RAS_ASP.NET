using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Services;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class CuisineController : Controller
    {
        private readonly CuisineService _service;

        public CuisineController()
        {
            _service = new CuisineService(this.ModelState, new DAOFactory(NHibernateManager.OpenSession()).GetCuisineDAO());
        }

        // GET: CuisineController
        public ActionResult Index()
        {
            return View(_service.List());
        }

        // GET: CuisineController/Details/5
        public ActionResult Details(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
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
            if (!_service.Create(entity))
                return View();
            return RedirectToAction("Index");
        }

        // GET: CuisineController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: CuisineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CuisineEntity entity)
        {
            if (!_service.Edit(id, entity))
                return View();
            return RedirectToAction(nameof(Index));
        }

        // GET: CuisineController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: CuisineController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CuisineEntity entity)
        {
            if (!_service.Delete(entity))
                return View();
            return RedirectToAction(nameof(Index));
        }
    }
}
