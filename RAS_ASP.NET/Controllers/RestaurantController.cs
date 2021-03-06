using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Services;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly RestaurantService _service;


        public RestaurantController()
        {
            _service = new RestaurantService(this.ModelState, new DAOFactory(NHibernateManager.OpenSession()).GetRestaurantDAO());
        }


        /*public RestaurantController(RestaurantService service)
        {
            _service = service;
        }*/

        public ActionResult Index()
        {
            return View(_service.List());
        }

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
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
            if (!_service.Create(entity))
                return View();
            return RedirectToAction("Index");
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantEntity entity)
        {
            if (!_service.Edit(id, entity))
                return View();
            return RedirectToAction(nameof(Index));
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RestaurantEntity entity)
        {
            if (!_service.Delete(entity))
                return View();
            return RedirectToAction(nameof(Index));
        }
    }
}
